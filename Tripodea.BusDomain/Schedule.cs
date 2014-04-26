using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.BusDomain
{
    public class Schedule
    {
        public virtual int ScheduleId { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy  H:mm}")]
        public virtual DateTime DepartureTime { get; set; }
        
        [Required]
        public virtual int JourneyFromId { get; set; }
        public virtual Location JourneyFrom { get; set; }
        
        [Required]
        public virtual int JourneyToId { get; set; }        
        public virtual Location JourneyTo { get; set; }
        
        [Required]
        public virtual int BusTypeId { get; set; }
        public virtual BusType BusType { get; set; }
        
        [Required]
        public virtual int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
