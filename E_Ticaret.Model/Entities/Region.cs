using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Bölge
    public class Region : CoreEntity
    {
        public Region()
        {
            Locations = new HashSet<Location>();
        }
        public string Name { get; set; }
        public ICollection<Location> Locations { get; set; }

        public Member CreatedMemberRegion { get; set; }
        public Member ModifiedMemberRegion { get; set; }
    }
}