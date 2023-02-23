using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class Transactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
