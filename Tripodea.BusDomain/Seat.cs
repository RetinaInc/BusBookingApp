using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
