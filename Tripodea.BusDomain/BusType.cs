using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.BusDomain
{
    public class BusType
    {
        public virtual int BusTypeId { get; set; }
        
        [Required]        
        public virtual string Name { get; set; }
        
        [Required]
        public virtual int SeatFormatId { get; set; }
        public virtual SeatFormat SeatFormat { get; set; }
    }
}
