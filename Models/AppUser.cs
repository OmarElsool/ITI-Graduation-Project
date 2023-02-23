using Airbnb.ModelsValidations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class AppUser : IdentityUser
    {
        [StringLength(50), Required]
        public string FName { get; set; } = "";
        [StringLength(50), Required]
        public string LName { get; set; } = "";
        [DateValidation, Required]
        public DateOnly BirthDate { get; set; }
        [StringLength(200), Required]
        public string City { get; set; } = "";
        [StringLength(200)]
        public string Street { get; set; } = "";
        [StringLength(20), MinLength(4)]
        public string ZipCode { get; set; } = "";
        [Required]
        public Gender Gender { get; set; }
        [StringLength(2000)]
        public string Photo { get; set; } = "";
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<Chat> Chats { get; set; } = new HashSet<Chat>();
        public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public virtual ICollection<Mansion> Mansions { get; set; } = new HashSet<Mansion>();

    }
}
