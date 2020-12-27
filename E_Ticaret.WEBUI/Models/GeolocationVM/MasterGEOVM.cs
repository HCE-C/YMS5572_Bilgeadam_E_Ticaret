using E_Ticaret.WEBUI.Models.CountryViewModels;
using E_Ticaret.WEBUI.Models.LocationViewModels;
using E_Ticaret.WEBUI.Models.RegionViewModels;
using System.Collections.Generic;

namespace E_Ticaret.WEBUI.Models.GeolocationVM
{
    public class MasterGEOVM
    {
        public List<LocationViewModel> LocationViewModel { get; set; }
        public List<CountryViewModel> CountryViewModel { get; set; }
        public List<RegionViewModel> RegionViewModel { get; set; }
    }
}
