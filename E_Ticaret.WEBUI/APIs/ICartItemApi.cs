using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.CartItem;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICartItemApi
    {
        [Get("/CartItem/{id}")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponse>>>> GetById(int id);
        [Put("/CartItem/{id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponse>>> Put(int id, CartItemRequest request);
        [Post("/CartItem")]
        Task<ApiResponse<WebApiResponse<CartItemResponse>>> Post(CartItemRequest request);
        [Delete("/CartItem/{id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponse>>> Delete(int id);
    }
}
