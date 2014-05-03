using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        ResultDto GetResultDetail(int scheduleId);

        void BuyTicket(OrderDto order);

        new void Dispose();

        OrderDto Order(ResultDto result);
        
    }
}
