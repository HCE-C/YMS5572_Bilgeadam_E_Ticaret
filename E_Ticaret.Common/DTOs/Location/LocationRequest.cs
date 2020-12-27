using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Model.Enums.GeneralEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.Location
{
    public class LocationRequest : BaseDto
    {
        public string Name { get; set; }
        public Predefined Predefined { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
    }
}
