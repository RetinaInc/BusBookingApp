using System.ComponentModel.DataAnnotations;

namespace Tripodea.BusDomain
{
    public class Ticket
    {
        public virtual int TicketId { get; set; }

        [Required]
        public virtual string SeatNumber { get; set; }
        [Required]
        public virtual string SeatClass { get; set; }
        
        [Required]
        public virtual int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

        [Required]
        public virtual int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
