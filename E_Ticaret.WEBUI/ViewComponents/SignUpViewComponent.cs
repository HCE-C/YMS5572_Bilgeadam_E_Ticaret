using AutoMapper;
using E_Ticaret.Common.DTOs.Location;
using E_Ticaret.WEBUI.APIs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.ViewComponents
{
    public class SignUpViewComponent : ViewComponent
    {
        private readonly ILocationApi _locationApi;
        private readonly ICountryApi _countryApi;
        private readonly IMapper _mapper;

        public SignUpViewComponent(ILocationApi locationApi, ICountryApi countryApi , IMapper mapper)
        {
            _locationApi = locationApi;
            _countryApi = countryApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var locationResult = await  _locationApi.GetActive();
            var countryResult = await _countryApi.GetActive();
            if (locationResult.IsSuccessStatusCode && locationResult.Content.IsSuccess && locationResult.Content?.ResultData != null)
            {
                ViewBag.ListOfLocation = locationResult.Content.ResultData;
            }
            if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content?.ResultData != null)
            {
                ViewBag.ListOfCountry = countryResult.Content.ResultData;
            }
            return View();
        }
    }
}
