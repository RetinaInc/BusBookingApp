using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.ServiceLayer.DTOs.Bus
{
    public class SeatDTO
    {
        public virtual string SeatNumber { get; set; }
        public virtual string SeatClass { get; set; }
        
        // status = 1 for availbable seats, status = 0 for booked seats
        public virtual int Status { get; set; }
    }
}
