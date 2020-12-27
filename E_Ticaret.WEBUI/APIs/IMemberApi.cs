using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Member;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-type: application/json")]
    public interface IMemberApi
    {
        [Get("/Member")]
        Task<ApiResponse<WebApiResponse<List<MemberResponse>>>> GetAll();

        [Get("/Member/Special")]
        Task<ApiResponse<WebApiResponse<List<MemberResponse>>>> GetAllByParam([FromQuery]MemberRequest request);

        [Get("/Member/{id}")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> GetById(int id);

        [Get("/Member/List")]
        Task<ApiResponse<WebApiResponse<List<MemberResponse>>>> GetByIds(MemberRequest request);

        [Put("/Member/{id}")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> PutMember(int id, MemberRequest request);

        [Post("/Member")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> PostMember(MemberRequest request);

        [Delete("/Member/{id}")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> DeleteMember(int id);

        [Get("/Member/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);

        [Get("/Member/getactive")]
        Task<ApiResponse<WebApiResponse<List<MemberResponse>>>> GetActive();
    }
}
