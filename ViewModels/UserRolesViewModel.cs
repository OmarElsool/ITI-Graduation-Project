namespace Airbnb.ViewModels
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public List<RolesViewModel> Roles { get; set; } = new List<RolesViewModel>();

    }
}
