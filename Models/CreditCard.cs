using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class CreditCard
    {
        [Key]
        public int CardNumber { get; set; }
        [Required]
        public int CVV { get; set; }
        [Required]
        public DateOnly Expiration { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

    }
}
