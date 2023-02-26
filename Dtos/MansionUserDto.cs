namespace Airbnb.Dtos
{
    public class MansionUserDto
    {
        public int MansionId { get; set; }
        public string ClientName { get; set; } = "";
        public string MansionTitle { get; set; } = "";
        public string MansionCategory { get; set; } = "";
        public int Price { get; set; }
        public DateTime PostDate { get; set; }

    }
}
