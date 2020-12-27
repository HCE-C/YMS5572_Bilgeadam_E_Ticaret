using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Üye Grubu
    public class MemberGroup : CoreEntity
    {
        public MemberGroup()
        {
            Members = new HashSet<Member>();
        }
        public string Name { get; set; }
        public int PriceIndex { get; set; }
        public string AllowedPaymentGateWays { get; set; }

        public ICollection<Member> Members { get; set; }

        public Member CreatedMemberGroup { get; set; }
        public Member ModifiedMemberGroup { get; set; }
    }
}