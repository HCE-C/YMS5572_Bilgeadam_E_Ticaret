using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Login;
using E_Ticaret.Common.DTOs.Member;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Content-type: application/json")]
    public interface IAccountApi
    {
        [Get("/account/login")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> Login(LoginRequest request);
    }
}
