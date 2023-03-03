using Airbnb.Models;

namespace Airbnb.ViewModels
{
    public class MansionSliderViewModel
    {
        public Mansion Mansion { get; set; }
        public List<MansionCategory> MansionCategories { get; set; }
        public List<ServiceTypeModel> ServiceTypes { get; set; }


    }
}
