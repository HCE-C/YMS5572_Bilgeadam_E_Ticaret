using E_Ticaret.Common.DTOs.Member;

namespace E_Ticaret.Common.Client.Services
{
    public interface IWorkContext
    {
        MemberResponse CurrentUser { get; set; }
    }
}
