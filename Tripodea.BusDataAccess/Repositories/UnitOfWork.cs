using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripodea.BusDomain;

namespace Tripodea.BusDataAccess.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private BusContext context = new BusContext();
        private GenericRepository<Company> companyRepository;
        private GenericRepository<BusType> busTypeRepository;        
        private GenericRepository<SeatFormat> seatFormatRepository;
        private GenericRepository<Seat> seatRepository;
        private GenericRepository<Schedule> scheduleRepository;
        private GenericRepository<Location> locationRepository;
        private GenericRepository<Ticket> ticketRepository;
        private GenericRepository<Order> orderRepository;

        public GenericRepository<Company> CompanyRepository
        {
            get
            {

                if (this.companyRepository == null)
                {
                    this.companyRepository = new GenericRepository<Company>(context);
                }
                return companyRepository;
            }
        }

        public GenericRepository<BusType> BusTypeRepository
        {
            get
            {
                if (this.busTypeRepository == null)
                {
                    this.busTypeRepository = new GenericRepository<BusType>(context);
                }
                return busTypeRepository;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        public GenericRepository<SeatFormat> SeatFormatRepository
        {
            get
            {
                if (this.seatFormatRepository == null)
                {
                    this.seatFormatRepository = new GenericRepository<SeatFormat>(context);
                }
                return seatFormatRepository;
            }
        }

        public GenericRepository<Seat> SeatRepository
        {
            get
            {
                if (this.seatRepository == null)
                {
                    this.seatRepository = new GenericRepository<Seat>(context);
                }
                return seatRepository;
            }
        }

        public GenericRepository<Schedule> ScheduleRepository
        {
            get
            {
                if (this.scheduleRepository == null)
                {
                    this.scheduleRepository = new GenericRepository<Schedule>(context);
                }
                return scheduleRepository;
            }
        }

        public GenericRepository<Location> LocationRepository
        {
            get
            {
                if (this.locationRepository == null)
                {
                    this.locationRepository = new GenericRepository<Location>(context);
                }
                return locationRepository;
            }
        }

        public GenericRepository<Ticket> TicketRepository
        {
            get
            {

                if (this.ticketRepository == null)
                {
                    this.ticketRepository = new GenericRepository<Ticket>(context);
                }
                return ticketRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
