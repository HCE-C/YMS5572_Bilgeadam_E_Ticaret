using E_Ticaret.Common.Client.Enums;

namespace E_Ticaret.WEBUI.Areas.Admin.Models.MailListViewModels
{
    public class MailListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public string LastMailSentDate { get; set; }
        public int MailListGroupId { get; set; }
    }
}
