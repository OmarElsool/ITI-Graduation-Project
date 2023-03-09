using Airbnb.Models;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.ViewModels
{
    public class ReservationViewModel
    {
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public int GuestNo { get; set; }
        public int Price { get; set; }
        public int MansionId { get; set; }
        public string UserId { get; set; }

    }
}
