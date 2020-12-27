using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Region;
using E_Ticaret.WEBUI.Models.RegionViewModels;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IRegionApi
    {
        [Get("/Region")]
        Task<ApiResponse<WebApiResponse<List<RegionViewModel>>>> GetAll();
        [Get("/Region/{id}")]
        Task<ApiResponse<WebApiResponse<RegionViewModel>>> GetById(int id);
        [Put("/Region/{id}")]
        Task<ApiResponse<WebApiResponse<RegionViewModel>>> Put(int id, RegionViewModel request);
        [Post("/Region")]
        Task<ApiResponse<WebApiResponse<RegionViewModel>>> Post(RegionViewModel request);
        [Delete("/Region/{id}")]
        Task<ApiResponse<WebApiResponse<RegionViewModel>>> Delete(int id);
    }
}