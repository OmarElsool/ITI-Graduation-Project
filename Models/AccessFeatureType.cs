using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class AccessFeatureType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; } = "";
        public virtual ICollection<AccessFeatureModel> AccessFeature { get; set; } = new HashSet<AccessFeatureModel>();
    }
}