using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
