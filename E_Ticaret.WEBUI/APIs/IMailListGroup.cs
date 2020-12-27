using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.MailListGroup;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IMailListGroup
    {
        [Get("/MailListGroup")]
        Task<ApiResponse<WebApiResponse<List<MailListGroupResponse>>>> GetAll();
        [Get("/MailListGroup/{id}")]
        Task<ApiResponse<WebApiResponse<MailListGroupResponse>>> GetById(int id);
        [Put("/MailListGroup/{id}")]
        Task<ApiResponse<WebApiResponse<MailListGroupResponse>>> PutMailListGroup(int id, MailListGroupRequest request);
        [Post("/MailListGroup")]
        Task<ApiResponse<WebApiResponse<MailListGroupResponse>>> PostMailListGroup(MailListGroupRequest request);
        [Delete("/MailListGroup/{id}")]
        Task<ApiResponse<WebApiResponse<MailListGroupResponse>>> DeleteMailListGroup(int id);
    }
}
