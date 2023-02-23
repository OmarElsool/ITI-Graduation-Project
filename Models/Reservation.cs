using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Check_in { get; set; }
        [Required]
        public DateTime Check_out { get; set; }
        public int NoGuests { get; set; } = 1;
        public DateTime PostDate { get; set; } = DateTime.Now;

        public bool Approved = false;
        public virtual Transactions Transaction { get; set; }
        [ForeignKey("Mansion")]
        public int MansionId { get; set; }
        public virtual Mansion Mansion { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

    }
}
