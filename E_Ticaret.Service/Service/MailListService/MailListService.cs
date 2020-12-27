using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.MailListService
{
    public class MailListService : BaseService<MailList> , IMailListService
    {
        public MailListService(DataContext db)
              : base(db)
        {
        }
    }
}
