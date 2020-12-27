using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Mail Listesi Grubu
    public class MailListGroup : CoreEntity
    {
        public MailListGroup()
        {
            MailLists = new HashSet<MailList>();
        }
        public string Name { get; set; }
        public ICollection<MailList> MailLists { get; set; }

        public Member CreatedMemberMailListGroup { get; set; }
        public Member ModifiedMemberMailListGroup { get; set; }
    }
}