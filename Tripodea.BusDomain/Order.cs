using System.Collections.Generic;

namespace Tripodea.BusDomain
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual string Customer { get; set; }
        public int ScheduleId { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
