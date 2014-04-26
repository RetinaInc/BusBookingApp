using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tripodea.BusDataAccess.Repositories;
using Tripodea.BusDomain;
using Tripodea.ServiceLayer.DTO;

namespace Tripodea.ServiceLayer.Bus
{
    public class BusService : IBusService, IDisposable
    {
        private UnitOfWork unit_of_work = new UnitOfWork();

        public List<string> GetLocations()
        {
            var locations = unit_of_work.LocationRepository.Get().Select(l => l.Name).ToList();
            return locations;
            //var LocationList = unit_of_work.LocationRepository.Get();
            //string locations = "[";

            //// create location array for view
            //foreach (var location in LocationList)
            //{
            //    locations += "\"" + location.Name + "\"";

            //    if (LocationList.Last().Name != location.Name)
            //    {
            //        locations += ", ";
            //    }
            //    else
            //    {
            //        locations += "]";
            //    }
            //}
            //return locations;
        }

        public IEnumerable<Schedule> SearchBus(SearchDTO searchBus)
        {
            var schedules = unit_of_work.ScheduleRepository.Get(
                filter:
                s => s.JourneyFrom.Name == searchBus.JourneyFrom &&
                s.JourneyTo.Name == searchBus.JourneyTo,
                includeProperties: "Company, JourneyFrom, JourneyTo, BusType");

            // filter for date and time
            TimeSpan timeDif = DateTime.Now.TimeOfDay - searchBus.Departure.TimeOfDay;
            searchBus.Departure += timeDif;
            schedules = schedules.Where(s => s.DepartureTime.Date == searchBus.Departure.Date
                                            && s.DepartureTime.TimeOfDay < searchBus.Departure.TimeOfDay);

            return schedules;
        }

        public ResultDTO GetResultDetail(int scheduleId)
        {
            // the result variable initiated
            ResultDTO result = new ResultDTO();
            result.SelectedSeats = "";

            // get schedule info
            result.Schedule = unit_of_work.ScheduleRepository.Get(
                filter: s => s.ScheduleId == scheduleId).
                FirstOrDefault();

            // get all the seats in this schedule
            List<string> allSeats = unit_of_work.SeatRepository.Get(
                filter: s => s.SeatFormatId == result.Schedule.BusType.SeatFormatId)
                .Select(s => s.SeatNumber).ToList();

            // get booked seats
            List<string> bookedSeats = unit_of_work.TicketRepository.Get(
                filter: t => t.ScheduleId == scheduleId)
                .Select(t => t.SeatNumber).ToList();

            // set availableSeats to allSeats
            List<string> availableSeats = allSeats;

            // initiate result.Seats 
            result.Seats = new List<SeatDTO>();

            // if there are booked seats
            if (bookedSeats.Count > 0)
            {
                // availableSeats = allSeats - bookedSeats
                availableSeats = allSeats.Except(bookedSeats).ToList();

                // create seats for the result
                foreach (var seat in bookedSeats)
                {
                    // iniitate SeatDTO
                    SeatDTO newSeat = new SeatDTO();
                    // set seat number as bookedSeat number
                    newSeat.SeatNumber = seat;
                    // status is 0 for booked seats
                    newSeat.Status = 0;
                    // add the seat to the result
                    result.Seats.Add(newSeat);
                }
            }

            // add available seats
            foreach (var seat in availableSeats)
            {
                SeatDTO newSeat = new SeatDTO();
                newSeat.SeatNumber = seat;
                // status is 1 for available seats
                newSeat.Status = 1;
                result.Seats.Add(newSeat);
            }

            return result;
        }
        // create an order for confirmation
        public OrderDTO Order(ResultDTO result)
        {
            OrderDTO order_dto = new OrderDTO();

            order_dto.PassengerName = "Demo User";
            order_dto.Schedule = unit_of_work.ScheduleRepository.Get(
                                    filter: s => s.ScheduleId == result.Schedule.ScheduleId)
                                    .FirstOrDefault();

            order_dto.SelectedSeats = new List<SeatDTO>();
            order_dto.SeatList = result.SelectedSeats;

            List<string> seats = result.SelectedSeats.Split(' ').ToList();
            foreach (string seat in seats)
            {
                SeatDTO seat_dto = new SeatDTO();
                seat_dto.SeatNumber = seat;

                // get seat class
                seat_dto.SeatClass = unit_of_work.SeatRepository.Get(
                    filter: s => s.SeatNumber == seat &&
                            s.SeatFormatId == result.Schedule.BusType.SeatFormatId)
                            .Select(s => s.SeatClass).FirstOrDefault();

                order_dto.SelectedSeats.Add(seat_dto);
            }

            return order_dto;
        }

        public void BuyTicket(OrderDTO order)
        {
            //create the tickets for the order
            order.Schedule = unit_of_work.ScheduleRepository.GetByID(order.Schedule.ScheduleId);

            Order ticket_order = new Order();
            ticket_order.PassengerName = order.PassengerName;

            //get the list of selected seats
            List<string> seats = order.SeatList.Split(' ').ToList();
            string firstSeat = seats.FirstOrDefault();
            //check if any of the tickets are already sold
            var existingTicket = unit_of_work.TicketRepository.Get(
                filter: t => t.ScheduleId == order.Schedule.ScheduleId
                             && t.SeatNumber == firstSeat);
            
            if (existingTicket.Count()==0)
            {
                //create the order
                unit_of_work.OrderRepository.Create(ticket_order);
                unit_of_work.Save();

                List<Ticket> tickets = new List<Ticket>();
                foreach (var seat in seats)
                {
                    Ticket ticket = new Ticket();
                    ticket.SeatNumber = seat;
                    ticket.Schedule = order.Schedule;
                    ticket.Order = ticket_order;
                    ticket.OrderId = ticket_order.OrderId;

                    unit_of_work.TicketRepository.Create(ticket);
                }
                unit_of_work.Save();
            }
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    unit_of_work.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
