using System;
using System.Collections.Generic;
using System.Linq;
using Tripodea.BusDataAccess.Repositories;
using Tripodea.BusDomain;
using Tripodea.ServiceLayer.DTOs.Bus;

namespace Tripodea.ServiceLayer.Bus
{
    public class BusService : IBusService, IDisposable
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public List<Location> GetLocations()
        {
            var locations = _unitOfWork.LocationRepository.Get().OrderBy(l => l.Name).ToList();
            return locations;
        }
        public List<ResultDto> GetSchedules()
        {
            var schedules = _unitOfWork.ScheduleRepository.Get();
            var result = GetResult(schedules);
            return result;
        }

        public List<ResultDto> SearchBus(SearchDto searchBus)
        {
            var schedules = _unitOfWork.ScheduleRepository.Get(
                filter:
                s => s.JourneyFromId == searchBus.JourneyFromId &&
                s.JourneyToId == searchBus.JourneyToId,
                includeProperties: "Company, JourneyFrom, JourneyTo, BusType");

            // filter for date and time
            schedules = schedules.Where(s => s.DepartureTime.Date == searchBus.Departure.Date);
            var result = GetResult(schedules);
            return result;
        }

        private List<ResultDto> GetResult(IEnumerable<Schedule> schedules)
        {
            return (from sched in schedules
                    let soldSeats = _unitOfWork.TicketRepository.Get(filter: t => t.ScheduleId == sched.ScheduleId).Count()
                    select new ResultDto
                    {
                        ScheduleId = sched.ScheduleId,
                        Bus = sched.Company.Name + " - " + sched.BusType.Name,
                        AvailableSeats = sched.BusType.SeatFormat.Seats.Count() - soldSeats,
                        Departure = sched.DepartureTime,
                        Description = sched.Description,
                        JourneyFrom = sched.JourneyFrom.Name,
                        JourneyTo = sched.JourneyTo.Name
                    }).ToList();
        }

        public SeatSelectionDto GetSeats(int scheduleId)
        {
            var schedule = _unitOfWork.ScheduleRepository.GetById(scheduleId);

            //get all the seats in the schedule
            var seats = schedule.BusType.SeatFormat.Seats.
                        Select(seat => new SeatDto
                                {
                                    SeatClass = seat.SeatClass,
                                    SeatNumber = seat.SeatNumber,
                                    Available = true
                                }).ToList();

            //get the booked seats
            var bookedSeats =
                _unitOfWork.TicketRepository.Get(filter: t => t.ScheduleId == scheduleId)
                    .ToList();

            //if there are sold seats then update availableSeats
            if (bookedSeats.Count > 0)
                foreach (var seat in from bookedSeat in bookedSeats
                    from seat in seats
                    where seat.SeatNumber == bookedSeat.SeatNumber
                    select seat)
                    seat.Available = false;

            //return the results
            return new SeatSelectionDto
            {
                ScheduleId = scheduleId,
                BusInfo = schedule.Company.Name + " - " + schedule.BusType.Name,
                LocationInfo = schedule.JourneyFrom.Name + " to " + schedule.JourneyTo.Name,
                Seats = seats
            };
        }

        public ResultDto GetResultDetail(int scheduleId)
        {
            //// the result variable initiated
            //ResultDto result = new ResultDto();
            //result.SelectedSeats = "";

            //// get schedule info
            //result.Schedule = unit_of_work.ScheduleRepository.Get(
            //    filter: s => s.ScheduleId == scheduleId).
            //    FirstOrDefault();

            //// get all the seats in this schedule
            //List<string> allSeats = unit_of_work.SeatRepository.Get(
            //    filter: s => s.SeatFormatId == result.Schedule.BusType.SeatFormatId)
            //    .Select(s => s.SeatNumber).ToList();

            //// get booked seats
            //List<string> bookedSeats = unit_of_work.TicketRepository.Get(
            //    filter: t => t.ScheduleId == scheduleId)
            //    .Select(t => t.SeatNumber).ToList();

            //// set availableSeats to allSeats
            //List<string> availableSeats = allSeats;

            //// initiate result.Seats 
            //result.Seats = new List<SeatDto>();

            //// if there are booked seats
            //if (bookedSeats.Count > 0)
            //{
            //    // availableSeats = allSeats - bookedSeats
            //    availableSeats = allSeats.Except(bookedSeats).ToList();

            //    // create seats for the result
            //    foreach (var seat in bookedSeats)
            //    {
            //        // iniitate SeatDTO
            //        SeatDto newSeat = new SeatDto();
            //        // set seat number as bookedSeat number
            //        newSeat.SeatNumber = seat;
            //        // status is 0 for booked seats
            //        newSeat.Status = 0;
            //        // add the seat to the result
            //        result.Seats.Add(newSeat);
            //    }
            //}

            //// add available seats
            //foreach (var seat in availableSeats)
            //{
            //    SeatDto newSeat = new SeatDto();
            //    newSeat.SeatNumber = seat;
            //    // status is 1 for available seats
            //    newSeat.Status = 1;
            //    result.Seats.Add(newSeat);
            //}

            return null;
        }
        // create an order for confirmation
        public OrderDto Order(ResultDto result)
        {
            //OrderDto order_dto = new OrderDto();

            //order_dto.PassengerName = "Demo User";
            //order_dto.Schedule = unit_of_work.ScheduleRepository.Get(
            //                        filter: s => s.ScheduleId == result.Schedule.ScheduleId)
            //                        .FirstOrDefault();

            //order_dto.SelectedSeats = new List<SeatDto>();
            //order_dto.SeatList = result.SelectedSeats;

            //List<string> seats = result.SelectedSeats.Split(' ').ToList();
            //foreach (string seat in seats)
            //{
            //    SeatDto seat_dto = new SeatDto();
            //    seat_dto.SeatNumber = seat;

            //    // get seat class
            //    seat_dto.SeatClass = unit_of_work.SeatRepository.Get(
            //        filter: s => s.SeatNumber == seat &&
            //                s.SeatFormatId == result.Schedule.BusType.SeatFormatId)
            //                .Select(s => s.SeatClass).FirstOrDefault();

            //    order_dto.SelectedSeats.Add(seat_dto);
            //}

            return null;
        }

        public void BuyTicket(OrderDto order)
        {
            //create the tickets for the order
            order.Schedule = _unitOfWork.ScheduleRepository.GetById(order.Schedule.ScheduleId);

            Order ticket_order = new Order();
            ticket_order.PassengerName = order.PassengerName;

            //get the list of selected seats
            List<string> seats = order.SeatList.Split(' ').ToList();
            string firstSeat = seats.FirstOrDefault();
            //check if any of the tickets are already sold
            var existingTicket = _unitOfWork.TicketRepository.Get(
                filter: t => t.ScheduleId == order.Schedule.ScheduleId
                             && t.SeatNumber == firstSeat);

            if (existingTicket.Count() == 0)
            {
                //create the order
                _unitOfWork.OrderRepository.Create(ticket_order);
                _unitOfWork.Save();

                List<Ticket> tickets = new List<Ticket>();
                foreach (var seat in seats)
                {
                    Ticket ticket = new Ticket();
                    ticket.SeatNumber = seat;
                    ticket.Schedule = order.Schedule;
                    ticket.Order = ticket_order;
                    ticket.OrderId = ticket_order.OrderId;

                    _unitOfWork.TicketRepository.Create(ticket);
                }
                _unitOfWork.Save();
            }
        }


        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
