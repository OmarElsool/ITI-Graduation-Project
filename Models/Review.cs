using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        [ForeignKey("Mansion")]
        public int MansionId { get; set; }
        public virtual Mansion Mansion { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
