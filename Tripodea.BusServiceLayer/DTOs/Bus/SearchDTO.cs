using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.ServiceLayer.DTOs.Bus
{
    public class SearchDto
    {
        [Required(ErrorMessage = "Where are you starting from?")]
        [Display(Name = "From")]
        public int JourneyFromId { get; set; }
        [Required(ErrorMessage = "Where are you going to?")]
        [Display(Name = "To")]
        public int JourneyToId { get; set; }
        [Required(ErrorMessage = "When are you going?")]
        [DataType(DataType.DateTime, ErrorMessage = "You must select a date.")]
        [Display(Name = "Departure Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy  H:mm}")]
        public DateTime Departure { get; set; }
    }
}
