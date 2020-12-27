using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Mail Listesi
    public class MailList : CoreEntity
    {
        public MailList()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LastMailSentDate { get; set; }

        public ICollection<Order> Orders { get; set; }

        public int MailListGroupId { get; set; }
        public MailListGroup MailListGroup { get; set; }

        public Member CreatedMemberMailList { get; set; }
        public Member ModifiedMemberMailList { get; set; }
    }
}