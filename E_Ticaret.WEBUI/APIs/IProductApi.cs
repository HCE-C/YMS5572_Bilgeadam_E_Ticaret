using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Product;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IProductApi
    {
        [Get("/Product")]
        Task<ApiResponse<WebApiResponse<List<ProductResponse>>>> GetAll();
        [Get("/Product/Special")]
        Task<ApiResponse<WebApiResponse<List<ProductResponse>>>> GetAllByParam(ProductRequest request);
        [Get("/Product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> GetById(int id);
        [Get("/Product/List")]
        Task<ApiResponse<WebApiResponse<List<ProductResponse>>>> GetByIds(ProductRequest request);
        [Put("/Product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Put(int id, ProductRequest request);
        [Post("/Product")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Post(ProductRequest request);
        [Delete("/Product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Delete(int id);
        [Get("/Product/activate/{id}")]
        Task<ApiResponse<ActionResult<WebApiResponse<bool>>>> Activate(int id);
        [Get("/Product/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductResponse>>>> GetActive();


    }
}
