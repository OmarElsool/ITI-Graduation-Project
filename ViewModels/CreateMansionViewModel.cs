using Airbnb.Models;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.ViewModels
{
    public class CreateMansionViewModel
    {
        public int placeType { get; set; }
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";

        [Required]
        public int NoGuest { get; set; }
        [Required]
        public int NoBedroom { get; set; }
        [Required]
        public int NoBed { get; set; }
        [Required]
        public int NoBathroom { get; set; }

        [Required]
        public int Price { get; set; }
        public string Street { get; set; } = "";
        [Required]
        public string City { get; set; } = "";
        [Required]
        public int Build_No { get; set; }
        [Required, StringLength(15, MinimumLength = 2)]
        public string Zipcode { get; set; } = "";
        public List<int> mansionService { get; set; }
        public List<IFormFile> photos { get; set; }
    }
}
