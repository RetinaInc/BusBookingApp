using System.ComponentModel.DataAnnotations;

namespace Tripodea.BusDomain
{
    public class Seat
    {
        [Key]
        public virtual string SeatId { get; set; }
        [Required]
        public virtual string SeatClass { get; set; }
        [Required]
        public virtual string SeatNumber { get; set; }
        [Required]
        public virtual int SeatFormatId { get; set; }
        public virtual SeatFormat SeatFormat { get; set; }
    }
}
