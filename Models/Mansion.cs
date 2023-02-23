using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class Mansion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";

        //[Required]
        //public string guestPlacetype { get; set; }
        [Required]
        public int NoGuest { get; set; }
        [Required]
        public int NoBedroom { get; set; }
        [Required]
        public int NoBed { get; set; }
        [Required]
        public int NoBathroom { get; set; }
        public bool Approved { get; set; } = false;
        [Required]
        public int Price { get; set; }
        public string Street { get; set; } = "";
        [Required]
        public string City { get; set; } = "";
        [Required]
        public int Build_No { get; set; }
        [Required, StringLength(15, MinimumLength = 2)]
        public string Zipcode { get; set; } = "";
        public DateTime PostDate { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<MansionPhotoModel> MansionPhotos { get; set; } = new HashSet<MansionPhotoModel>();
        public virtual ICollection<ServiceModel> Services { get; set; } = new HashSet<ServiceModel>();
        public virtual ICollection<AccessFeatureModel> AccessFeatures { get; set; } = new HashSet<AccessFeatureModel>();
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual MansionCategory Category { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
