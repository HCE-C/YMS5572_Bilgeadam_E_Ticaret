using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Common.DTOs.MailListGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.MailList
{
    public class MailListResponse : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string LastMailSentDate { get; set; }
        public int MailListGroupId { get; set; }
        public MailListGroupResponse MailListGroup { get; set; }
    }
}
