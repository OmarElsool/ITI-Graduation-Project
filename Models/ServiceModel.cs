using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class ServiceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public virtual ICollection<Mansion> Mansion { get; set; } = new HashSet<Mansion>();
        [ForeignKey("ServiceType")]
        public int ServiceTypeId { get; set; }
        public virtual ServiceTypeModel? ServiceType { get; set; }
    }
}
