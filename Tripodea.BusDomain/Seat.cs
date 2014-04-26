using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.BusDomain
{
    public class Seat
    {
        public virtual int SeatId { get; set; }
        public virtual string SeatClass { get; set; }
        public virtual string SeatNumber { get; set; }
        public virtual int SeatFormatId { get; set; }
        public virtual SeatFormat SeatFormat { get; set; }
    }
}
