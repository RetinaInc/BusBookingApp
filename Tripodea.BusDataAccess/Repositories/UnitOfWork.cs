using System;
using Tripodea.BusDomain;

namespace Tripodea.BusDataAccess.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly BusContext _context = new BusContext();
        private GenericRepository<Company> _companyRepository;
        private GenericRepository<BusType> _busTypeRepository;        
        private GenericRepository<SeatFormat> _seatFormatRepository;
        private GenericRepository<Seat> _seatRepository;
        private GenericRepository<Schedule> _scheduleRepository;
        private GenericRepository<Location> _locationRepository;
        private GenericRepository<Ticket> _ticketRepository;
        private GenericRepository<Order> _orderRepository;

        public GenericRepository<Company> CompanyRepository
        {
            get
            {
                if (this._companyRepository == null)
                {
                    this._companyRepository = new GenericRepository<Company>(_context);
                }
                return _companyRepository;
            }
        }

        public GenericRepository<BusType> BusTypeRepository
        {
            get
            {
                if (this._busTypeRepository == null)
                {
                    this._busTypeRepository = new GenericRepository<BusType>(_context);
                }
                return _busTypeRepository;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this._orderRepository == null)
                {
                    this._orderRepository = new GenericRepository<Order>(_context);
                }
                return _orderRepository;
            }
        }

        public GenericRepository<SeatFormat> SeatFormatRepository
        {
            get
            {
                if (this._seatFormatRepository == null)
                {
                    this._seatFormatRepository = new GenericRepository<SeatFormat>(_context);
                }
                return _seatFormatRepository;
            }
        }

        public GenericRepository<Seat> SeatRepository
        {
            get
            {
                if (this._seatRepository == null)
                {
                    this._seatRepository = new GenericRepository<Seat>(_context);
                }
                return _seatRepository;
            }
        }

        public GenericRepository<Schedule> ScheduleRepository
        {
            get
            {
                if (this._scheduleRepository == null)
                {
                    this._scheduleRepository = new GenericRepository<Schedule>(_context);
                }
                return _scheduleRepository;
            }
        }

        public GenericRepository<Location> LocationRepository
        {
            get
            {
                if (this._locationRepository == null)
                {
                    this._locationRepository = new GenericRepository<Location>(_context);
                }
                return _locationRepository;
            }
        }

        public GenericRepository<Ticket> TicketRepository
        {
            get
            {

                if (this._ticketRepository == null)
                {
                    this._ticketRepository = new GenericRepository<Ticket>(_context);
                }
                return _ticketRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
