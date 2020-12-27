using E_Ticaret.Core.Entity.Enums;

namespace E_Ticaret.WEBUI.Models.LocationViewModels
{
    public class CreateLocationVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Predefined { get; set; }
        public Status Status { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
    }
}
