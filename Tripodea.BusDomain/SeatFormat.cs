using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.BusDomain
{
    public class SeatFormat
    {
        public virtual int SeatFormatId { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
