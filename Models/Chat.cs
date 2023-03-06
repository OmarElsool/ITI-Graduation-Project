using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ChatName { get; set; } = "";
        public virtual ICollection<AppUser> User { get; set; } = new HashSet<AppUser>();
        public virtual ICollection<Message> Message { get; set; } = new HashSet<Message>();

    }
}
