using E_Ticaret.Common.DTOs.Base;

namespace E_Ticaret.Common.DTOs.MailList
{
    public class MailListRequest : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string LastMailSentDate { get; set; }
        public int MailListGroupId { get; set; }
    }
}
