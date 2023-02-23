using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(2500)]
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }

    }
}
