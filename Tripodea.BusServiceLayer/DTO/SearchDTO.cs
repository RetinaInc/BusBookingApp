using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.ServiceLayer.DTO
{
    public class SearchDTO
    {
        [Required(ErrorMessage = "Required Field")]
        public virtual string JourneyFrom { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public virtual string JourneyTo { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.DateTime, ErrorMessage = "You must select a date.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy  H:mm}")]
        public virtual DateTime Departure { get; set; }
    }
}
