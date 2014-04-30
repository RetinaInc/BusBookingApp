using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripodea.BusDomain;

namespace Tripodea.ServiceLayer.DTOs.Bus
{
    public class ResultDto
    {
        public int ScheduleId { get; set; }
        public int JourneyFromId { get; set; }
        public int JourneyToId { get; set; }
        public string Bus { get; set; }
        public int AvailableSeats { get; set; }
    }
}
