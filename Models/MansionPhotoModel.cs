using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class MansionPhotoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string MansionPhoto { get; set; } = "";
        [ForeignKey("Mansion")]
        public virtual int MansionId { get; set; }
        public virtual Mansion Mansion { get; set; }
    }
}
