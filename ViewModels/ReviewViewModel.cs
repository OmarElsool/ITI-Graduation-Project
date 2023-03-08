using System.ComponentModel.DataAnnotations;

namespace Airbnb.ViewModels
{
    public class ReviewViewModel
    {
        [Range(1, 5)]
        public int ReviewRating { get; set; }
        [Required]
        public string ReviewComment { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public int MansionId { get; set; }

    }
}
