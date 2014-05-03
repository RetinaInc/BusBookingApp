using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tripodea.BusDomain
{
    public class Location
    {
        public virtual int LocationId { get; set; }
        
        [Required]
        public virtual string Name { get; set; }
        public virtual ICollection<Schedule> FromSchedules { get; set; }
        public virtual ICollection<Schedule> ToSchedules { get; set; }
    }
}
