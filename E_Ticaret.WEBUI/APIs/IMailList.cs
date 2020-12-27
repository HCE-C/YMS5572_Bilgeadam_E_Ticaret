using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.MailList;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IMailList
    {
        [Get("/MailList")]
        Task<ApiResponse<WebApiResponse<List<MailListResponse>>>> GetAll();
        [Get("/MailList/{id}")]
        Task<ApiResponse<WebApiResponse<MailListResponse>>> GetById(int id);
        [Put("/MailList/{id}")]
        Task<ApiResponse<WebApiResponse<MailListResponse>>> PutMailList(int id, MailListRequest request);
        [Post("/MailList")]
        Task<ApiResponse<WebApiResponse<MailListResponse>>> PostMailList(MailListRequest request);
        [Delete("/MailList/{id}")]
        Task<ApiResponse<WebApiResponse<MailListResponse>>> DeleteMailList(int id);
    }
}
