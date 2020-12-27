using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Location;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-type: application/json")]
    public interface ILocationApi
    {
        [Get("/Location")]
        Task<ApiResponse<WebApiResponse<List<LocationResponse>>>> GetAll();
        [Get("/Location/Special")]
        Task<ApiResponse<WebApiResponse<List<LocationResponse>>>> GetAllByParam(LocationRequest request);
        [Get("/Location/{id}")]
        Task<ApiResponse<WebApiResponse<LocationResponse>>> GetById(int id);
        [Get("/Location/List")]
        Task<ApiResponse<WebApiResponse<List<LocationResponse>>>> GetByIds(LocationRequest request);
        [Put("/Location/{id}")]
        Task<ApiResponse<WebApiResponse<LocationResponse>>> Put(int id, LocationRequest request);
        [Post("/Location")]
        Task<ApiResponse<WebApiResponse<LocationResponse>>> Post(LocationRequest request);
        [Delete("/Location/{id}")]
        Task<ApiResponse<WebApiResponse<LocationResponse>>> Delete(int id);
        [Get("/Location/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);
        [Get("/Location/getactive")]
        Task<ApiResponse<WebApiResponse<List<LocationResponse>>>> GetActive();
        //[Get("/Location/join")]
        //Task<ApiResponse<WebApiResponse<List<LocationResponse>>>> GetJoinLocation();
    }
}
