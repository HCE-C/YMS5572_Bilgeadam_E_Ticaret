using AutoMapper;
using E_Ticaret.Common.DTOs.Country;
using E_Ticaret.Common.DTOs.Location;
using E_Ticaret.WEBUI.APIs;
using E_Ticaret.WEBUI.Models.CountryViewModels;
using E_Ticaret.WEBUI.Models.GeolocationVM;
using E_Ticaret.WEBUI.Models.LocationViewModels;
using E_Ticaret.WEBUI.Models.RegionViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GeolocationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILocationApi _locationApi;
        private readonly ICountryApi _countryApi;
        private readonly IRegionApi _regionApi;

        public GeolocationController(ILocationApi locationApi, ICountryApi countryApi, IRegionApi regionApi, IMapper mapper)
        {
            _locationApi = locationApi;
            _countryApi = countryApi;
            _regionApi = regionApi;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "Geolocation";

            var VM = new MasterGEOVM();
            var location = new List<LocationViewModel>();
            var country = new List<CountryViewModel>();
            var region = new List<RegionViewModel>();

            var locationResult = await _locationApi.GetAll();
            if (locationResult.IsSuccessStatusCode && locationResult.Content.IsSuccess && locationResult.Content.ResultData != null)
                location = _mapper.Map<List<LocationViewModel>>(locationResult.Content.ResultData);

            var countryResult = await _countryApi.GetAll();
            if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content.ResultData != null)
                country = _mapper.Map<List<CountryViewModel>>(countryResult.Content.ResultData);

            var regionResult = await _regionApi.GetAll();
            if (regionResult.IsSuccessStatusCode && regionResult.Content.IsSuccess && regionResult.Content.ResultData != null)
                region = regionResult.Content.ResultData;

            VM.LocationViewModel = location;
            VM.CountryViewModel = country;
            VM.RegionViewModel = region;

            return View(VM);
        }

        public async Task<IActionResult> Delete(int id, string name)
        {
            ViewData["Active"] = "Geolocation";

            if (id > 0)
            {
                switch (name)
                {
                    case "Country":
                        var countryResult = await _countryApi.Delete(id);
                        if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content.ResultData != null)
                            break;
                        break;
                    case "Location":
                        var locationResult = await _locationApi.Delete(id);
                        if (locationResult.IsSuccessStatusCode && locationResult.Content.IsSuccess && locationResult.Content.ResultData != null)
                            break;
                        break;
                    case "Region":
                        var regionResult = await _regionApi.Delete(id);
                        if (regionResult.IsSuccessStatusCode && regionResult.Content.IsSuccess && regionResult.Content.ResultData != null)
                            break;
                        break;

                    default:
                        break;
                }

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCountry(int id)
        {
            ViewData["Active"] = "Geolocation";

            CountryViewModel model = new CountryViewModel();
            if (id > 0)
            {
                var countryResult = await _countryApi.GetById(id);
                if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content.ResultData != null)
                    model = _mapper.Map<CountryViewModel>(countryResult.Content.ResultData);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCountry(CountryViewModel model)
        {
            if (model.Id > 0 && ModelState.IsValid)
            {
                var countryResult = await _countryApi.Put(model.Id,_mapper.Map<CountryRequest>(model));
                if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);                
            }
            else if (ModelState.IsValid)
            {
                var countryResult = await _countryApi.Post(_mapper.Map<CountryRequest>(model));
                if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            ViewData["Active"] = "Geolocation";

            var countryResult = await _countryApi.GetAll();
            if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content.ResultData != null)
                ViewBag.Country = _mapper.Map<List<CountryViewModel>>(countryResult.Content.ResultData);

            var regionResult = await _regionApi.GetAll();
            if (regionResult.IsSuccessStatusCode && regionResult.Content.IsSuccess && regionResult.Content.ResultData != null)
                ViewBag.Region = regionResult.Content.ResultData;

            LocationViewModel model = new LocationViewModel();
            if (id > 0)
            {
                var locationResult = await _locationApi.GetById(id);
                if (locationResult.IsSuccessStatusCode && locationResult.Content.IsSuccess && locationResult.Content.ResultData != null)
                    model = _mapper.Map<LocationViewModel>(locationResult.Content.ResultData);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(LocationViewModel model)
        {
            var countryResult = await _countryApi.GetAll();
            if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content.ResultData != null)
                ViewBag.Country = _mapper.Map<List<CountryViewModel>>(countryResult.Content.ResultData);

            var regionResult = await _regionApi.GetAll();
            if (regionResult.IsSuccessStatusCode && regionResult.Content.IsSuccess && regionResult.Content.ResultData != null)
                ViewBag.Region = regionResult.Content.ResultData;

            if (model.Id > 0 && ModelState.IsValid)
            {
                var locationResult = await _locationApi.Put(model.Id, _mapper.Map<LocationRequest>(model));
                if (locationResult.IsSuccessStatusCode && locationResult.Content.IsSuccess && locationResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);
            }
            else if (ModelState.IsValid)
            {
                var locationResult = await _locationApi.Post(_mapper.Map<LocationRequest>(model));
                if (locationResult.IsSuccessStatusCode && locationResult.Content.IsSuccess && locationResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRegion(int id)
        {
            ViewData["Active"] = "Geolocation";

            RegionViewModel model = new RegionViewModel();
            if (id > 0)
            {
                var regionResult = await _regionApi.GetById(id);
                if (regionResult.IsSuccessStatusCode && regionResult.Content.IsSuccess && regionResult.Content.ResultData != null)
                    model = regionResult.Content.ResultData;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRegion(RegionViewModel model)
        {
            if (model.Id > 0 && ModelState.IsValid)
            {
                var regionResult = await _regionApi.Put(model.Id, model);
                if (regionResult.IsSuccessStatusCode && regionResult.Content.IsSuccess && regionResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);
            }
            else if (ModelState.IsValid)
            {
                var regionResult = await _regionApi.Post(model);
                if (regionResult.IsSuccessStatusCode && regionResult.Content.IsSuccess && regionResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);
            }
            return View(model);
        }
    }
}
