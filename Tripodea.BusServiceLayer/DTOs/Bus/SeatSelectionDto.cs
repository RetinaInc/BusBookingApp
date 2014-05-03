using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.ServiceLayer.DTOs.Bus
{
    public class SeatSelectionDto
    {
        public int ScheduleId { get; set; }
        public string LocationInfo { get; set; }
        public string BusInfo { get; set; }
        public ICollection<SeatDto> Seats { get; set; }
    }
}
