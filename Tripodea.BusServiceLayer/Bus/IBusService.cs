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
        IEnumerable<Schedule> SearchBus(SearchDto searchBus);
        ResultDto GetResultDetail(int scheduleId);

        List<string> GetLocations();

        void BuyTicket(OrderDto order);

        new void Dispose();

        OrderDto Order(ResultDto result);
    }
}
