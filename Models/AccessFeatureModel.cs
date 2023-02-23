using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class AccessFeatureModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public virtual ICollection<Mansion> Mansion { get; set; } = new HashSet<Mansion>();
        public virtual AccessFeatureType AccessFeatureType { get; set; }
    }
}
