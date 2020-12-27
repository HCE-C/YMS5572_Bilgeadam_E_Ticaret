using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.MailListGroupService
{
    public class MailListGroupService : BaseService<MailListGroup> , IMailListGroupService
    {
        public MailListGroupService(DataContext db)
           : base(db)
        {
        }
    }
}
