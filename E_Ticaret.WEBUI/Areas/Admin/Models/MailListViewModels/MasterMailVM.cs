using System.Collections.Generic;

namespace E_Ticaret.WEBUI.Areas.Admin.Models.MailListViewModels
{
    public class MasterMailVM
    {
        public List<MailListVM> MailListVMs { get; set; }
        public List<MailListGroupVM> MailListGroupVMs { get; set; }
    }
}
