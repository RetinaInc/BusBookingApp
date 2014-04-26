using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripodea.BusDomain;

namespace Tripodea.ServiceLayer.DTO
{
    public class ResultDTO
    {
        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<SeatDTO> Seats { get; set; }
        public virtual string SelectedSeats { get; set; }
    }
}
