using System;
using System.Collections.Generic;

namespace Tripodea.ServiceLayer.DTOs.Bus
{
    public class OrderDto
    {
        public string BusInfo { get; set; }
        public string LocationDetail { get; set; }
        public DateTime Departure { get; set; }
        public ICollection<SeatDto> Seats { get; set; }
        public string CustomerName { get; set; }
    }
}
