using E_Ticaret.Common.Client.Enums;
using E_Ticaret.Common.DTOs.Country;
using E_Ticaret.Common.DTOs.Region;
using E_Ticaret.Model.Enums.GeneralEnums;

namespace E_Ticaret.WEBUI.Models.LocationViewModels
{
    public class LocationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Predefined Predefined { get; set; }
        public Status Status { get; set; }
        public CountryResponse Country { get; set; }
        public RegionResponse Region { get; set; }
    }
}
