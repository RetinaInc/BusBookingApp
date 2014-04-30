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
        IEnumerable<Schedule> SearchBus(SearchDTO searchBus);
        ResultDTO GetResultDetail(int scheduleId);

        List<string> GetLocations();

        void BuyTicket(OrderDTO order);

        void Dispose();

        OrderDTO Order(ResultDTO result);
    }
}
