using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.ServiceLayer.DTOs.Bus
{
    public class SeatDto
    {
        public string SeatNumber { get; set; }
        public string SeatClass { get; set; }
        public Boolean Available { get; set; }
    }
}
