using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripodea.BusDomain;

namespace Tripodea.ServiceLayer.DTOs.Bus
{
    public class OrderDto
    {
        public virtual ICollection<SeatDto> SelectedSeats { get; set; }
        public virtual string SeatList { get; set; }
        public virtual Schedule Schedule { get; set; }
        [Required]
        public virtual string PassengerName { get; set; }
    }
}
