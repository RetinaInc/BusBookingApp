using System;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace Tripodea.ServiceLayer.DTOs.Bus
{
    public class SearchDto
    {
        [Required(ErrorMessage = "Where are you starting from?")]
        [Display(Name = "From")]
        public int JourneyFromId { get; set; }
        [Required(ErrorMessage = "Where are you going to?")]
        [Display(Name = "To")]
        [NotEqualTo("JourneyFromId", ErrorMessage = "You cannot go to the same place you start from. Please choose a different location.")]
        public int JourneyToId { get; set; }
        [Required(ErrorMessage = "When are you going?")]
        [DataType(DataType.DateTime, ErrorMessage = "You must select a dpearture date.")]
        [Display(Name = "Departure Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy  H:mm}")]
        public DateTime Departure { get; set; }
    }
}
