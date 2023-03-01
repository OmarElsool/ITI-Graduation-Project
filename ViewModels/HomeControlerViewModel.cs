using Airbnb.Models;

namespace Airbnb.ViewModels
{
    public class HomeControlerViewModel
    {
        public List<Mansion> Mansion { get; set; } = new List<Mansion>();
        public List<MansionCategory> MansionCategories { get; set; } = new List<MansionCategory>();
    }
}
