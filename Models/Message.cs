using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(2500)]
        public string MsgText { get; set; } = "";
        public DateTime MsgDate { get; set; } = DateTime.Now;

        public virtual Chat Chat { get; set; }

        public virtual AppUser AppUser { get; set; }

    }
}
