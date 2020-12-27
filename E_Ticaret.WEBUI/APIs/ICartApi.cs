using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Cart;
using Refit;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICartApi
    {
        [Get("/Cart/{id}")]
         Task<ApiResponse<WebApiResponse<CartResponse>>> GetById(int id);
        [Put("/Cart/{id}")]
         Task<ApiResponse<WebApiResponse<CartResponse>>> Put(int id, CartRequest request);
        [Post("/Cart")]
         Task<ApiResponse<WebApiResponse<CartResponse>>> Post(CartRequest request);
        [Delete("/Cart/{id}")]
         Task<ApiResponse<WebApiResponse<CartResponse>>> Delete(int id);
        [Get("/Cart/anyCart")]
        Task<ApiResponse<WebApiResponse<CartResponse>>> GetCartByMemberId(int memberId);
    }
}
