using System.Collections.Generic;

namespace Tripodea.BusDomain
{
    public class SeatFormat
    {
        public virtual int SeatFormatId { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
