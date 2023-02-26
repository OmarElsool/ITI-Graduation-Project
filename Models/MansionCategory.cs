using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class MansionCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public virtual List<Mansion> Mansion { get; set; } = new List<Mansion>();
    }
}
