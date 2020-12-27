using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Country;
using E_Ticaret.WEBUI.Models.CountryViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.APIs
{
    [Headers("Authorization: Bearer", "Content-type: application/json")]
    public interface ICountryApi
    {
        [Get("/country")]
        Task<ApiResponse<WebApiResponse<List<CountryResponse>>>> GetAll();
        [Get("/country/{id}")]
         Task<ApiResponse<WebApiResponse<CountryResponse>>> GetById(int id);
        [Get("/country/List")]
         Task<ApiResponse<WebApiResponse<List<CountryResponse>>>> GetByIds(CountryRequest request);
        [Put("/country/{id}")]
         Task<ApiResponse<WebApiResponse<CountryResponse>>> Put(int id, CountryRequest request);
        [Post("/country")]
         Task<ApiResponse<WebApiResponse<CountryResponse>>> Post(CountryRequest request);
        [Delete("/country/{id}")]
         Task<ApiResponse<WebApiResponse<CountryResponse>>> Delete(int id);
        [Get("/country/activate/{id}")]
         Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);
        [Get("/country/getactive")]
        Task<ApiResponse<WebApiResponse<List<CountryResponse>>>> GetActive();
    }
}
