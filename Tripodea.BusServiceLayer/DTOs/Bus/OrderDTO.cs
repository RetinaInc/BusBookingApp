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
        public string BusInfo { get; set; }
        public string LocationDetail { get; set; }
        public DateTime Departure { get; set; }
        public List<string> SelectedSeats { get; set; }
        public string CustomerName { get; set; }
    }
}
