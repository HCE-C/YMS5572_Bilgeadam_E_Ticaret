using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Pimage;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IPimageApi
    {
        [Get("/Pimage")]
        Task<ApiResponse<WebApiResponse<List<PimageResponse>>>> GetAll();
        [Get("/Pimage/{id}")]
        Task<ApiResponse<WebApiResponse<PimageResponse>>> GetById(int id);
        [Post("/Pimage")]
        Task<ApiResponse<WebApiResponse<PimageResponse>>> Post(PimageRequest request);
    }
}
