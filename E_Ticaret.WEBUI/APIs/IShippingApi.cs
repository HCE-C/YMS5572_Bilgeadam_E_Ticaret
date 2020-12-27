using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.ShippingAddress;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IShippingApi
    {
        [Get("/ShippingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingAddressResponse>>> GetById(int id);
        [Put("/ShippingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingAddressResponse>>> Put(int id, ShippingAddressRequest request);
        [Post("/ShippingAddress")]
        Task<ApiResponse<WebApiResponse<ShippingAddressResponse>>> Post(ShippingAddressRequest request);
    }
}
