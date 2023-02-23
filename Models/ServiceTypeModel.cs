using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class ServiceTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ServiceType { get; set; } = "";
        public virtual ICollection<ServiceModel> Service { get; set; } = new HashSet<ServiceModel>();
    }
}
