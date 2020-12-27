using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Model.Entities
{
    public class LocationSp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public int CountryId{ get; set; }
        public string RegionName { get; set; }
        public int RegionId { get; set; }
    }
}
