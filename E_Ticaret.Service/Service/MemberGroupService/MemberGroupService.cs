using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.MemberGroupService
{
    public class MemberGroupService : BaseService<MemberGroup>, IMemberGroupService
    {
        public MemberGroupService(DataContext db)
              : base(db)
        {
        }
    }
}
