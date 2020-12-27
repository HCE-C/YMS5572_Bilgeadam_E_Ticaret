using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.BillingAddress;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IBillingApi
    {
        [Get("/BillingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<BillingAddressResponse>>> GetById(int id);
        [Put("/BillingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<BillingAddressResponse>>> Put(int id, BillingAddressRequest request);
        [Post("/BillingAddress")]
        Task<ApiResponse<WebApiResponse<BillingAddressResponse>>> Post(BillingAddressRequest request);
    }
}
