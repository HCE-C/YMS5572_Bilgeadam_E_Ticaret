using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.MemberService
{
    public class MemberService : BaseService<Member> , IMemberService
    {
        public MemberService(DataContext db)
              : base(db)
        {
        }
    }
}
