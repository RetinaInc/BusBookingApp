using System.ComponentModel.DataAnnotations;

namespace Tripodea.BusDomain
{
    public class Seat
    {
        public virtual int SeatId { get; set; }
        public virtual string UniqueId { get; set; }
        [Required]
        public virtual string SeatClass { get; set; }
        [Required]
        public virtual string SeatNumber { get; set; }
        [Required]
        public virtual int SeatFormatId { get; set; }
        public virtual SeatFormat SeatFormat { get; set; }
    }
}
