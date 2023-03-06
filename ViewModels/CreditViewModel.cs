using System.ComponentModel.DataAnnotations;

namespace Airbnb.ViewModels
{
    public class CreditViewModel
    {
        public int CardNumber { get; set; }
        public DateTime Expiration { get; set; }
        public int CVV { get; set; }
        public string UserId { get; set; }
    }
}
