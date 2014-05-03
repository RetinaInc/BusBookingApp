using System.ComponentModel.DataAnnotations;

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
