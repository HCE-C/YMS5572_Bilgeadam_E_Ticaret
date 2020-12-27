using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Category;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICategoryApi
    {
        [Get("/Category")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponse>>>> GetAll();
        [Get("/Category/Special")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponse>>>> GetAllByParam(CategoryRequest request);
        [Get("/Category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> GetById(int id);
        [Get("/Category/List")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponse>>>> GetByIds(CategoryRequest request);
        [Put("/Category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Put(int id, CategoryRequest request);
        [Post("/Category")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Post(CategoryRequest request);
        [Delete("/Category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Delete(int id);
        [Get("/Category/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);
        [Get("/Category/getactive")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponse>>>> GetActive();
    }
}
