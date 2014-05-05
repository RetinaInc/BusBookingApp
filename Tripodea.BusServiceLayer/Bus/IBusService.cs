using System;
using System.Collections.Generic;
using System.Security.Principal;
using Tripodea.BusDomain;
using Tripodea.ServiceLayer.DTOs.Bus;

namespace Tripodea.ServiceLayer.Bus
{
    public interface IBusService : IDisposable
    {
        List<ResultDto> GetSchedules();
        List<Location> GetLocations();
        List<ResultDto> SearchBus(SearchDto searchBus);
        SeatSelectionDto GetSeats(int scheduleId);
        new void Dispose();
        void BuyTicket(string seats, int scheduleId, string customer);
        OrderDto Order(string seats, int scheduleId, string customer);
    }
}
