using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.BusDomain
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual string PassengerName { get; set; }
        public virtual  ICollection<Ticket> Tickets { get; set; }

    }
}
