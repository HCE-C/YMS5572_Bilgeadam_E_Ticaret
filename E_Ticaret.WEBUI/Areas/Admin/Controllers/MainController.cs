using AutoMapper;
using E_Ticaret.Common.DTOs.Member;
using E_Ticaret.WEBUI.APIs;
using E_Ticaret.WEBUI.Areas.Admin.Models.AdminViewModels;
using E_Ticaret.WEBUI.Models.MemberViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        private readonly IMemberApi _memberApi;
        private readonly IMapper _mapper;
        private readonly ILocationApi _locationApi;
        private readonly ICountryApi _countryApi;

        public MainController(IMemberApi memberApi, IMapper mapper, ILocationApi locationApi, ICountryApi countryApi)
        {
            _memberApi = memberApi;
            _mapper = mapper;
            _locationApi = locationApi;
            _countryApi = countryApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sort,int limit,int page,string ids)
        {
            ViewData["Active"] = "User";
            MemberRequest request = new MemberRequest
            {
                Ids = ids,
                Sort = sort,
                Limit = 5,
                SinceId = -1,
                Page = page,                
            };

            var response = await _memberApi.GetAllByParam(request);
            if (response.IsSuccessStatusCode && response.Content.IsSuccess && response.Content?.ResultData != null)
            {
                var list = _mapper.Map<List<AdminViewModel>>(response.Content.ResultData);
                return View(list);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Active"] = "User";
            var memberResult = await _memberApi.GetById(id);
            var locationResult = await _locationApi.GetActive();
            var countryResult = await _countryApi.GetActive();

            if (locationResult.IsSuccessStatusCode && locationResult.Content.IsSuccess && locationResult.Content?.ResultData != null)
                ViewBag.ListOfLocation = locationResult.Content.ResultData;

            if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content?.ResultData != null)
                ViewBag.ListOfCountry = countryResult.Content.ResultData;

            if (memberResult.IsSuccessStatusCode && memberResult.Content.IsSuccess && memberResult.Content?.ResultData != null)
            {
                var result = _mapper.Map<UpdateMemberViewModel>(memberResult.Content.ResultData);
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateMemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var memberResult = await _memberApi.PutMember(model.Id, _mapper.Map<MemberRequest>(model));

                if (memberResult.IsSuccessStatusCode && memberResult.Content.IsSuccess && memberResult.Content?.ResultData != null)
                {
                    return RedirectToAction("Index");
                }
            }
            var locationResult = await _locationApi.GetActive();
            var countryResult = await _countryApi.GetActive();

            if (locationResult.IsSuccessStatusCode && locationResult.Content.IsSuccess && locationResult.Content?.ResultData != null)
                ViewBag.ListOfLocation = locationResult.Content.ResultData;

            if (countryResult.IsSuccessStatusCode && countryResult.Content.IsSuccess && countryResult.Content?.ResultData != null)
                ViewBag.ListOfCountry = countryResult.Content.ResultData;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Active(int id)
        {
            ViewData["Active"] = "User";
            var result = await _memberApi.Activate(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content?.ResultData != null)
            {
                TempData["Durum"] = "Başarılı";
            }
            return Json(new { durum = "Başarılı" });
        }

        [HttpGet]
        public async Task<IActionResult> Passive(int id)
        {
            ViewData["Active"] = "User";
            var result = await _memberApi.DeleteMember(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content?.ResultData != null)
            {
                TempData["Durum"] = "Başarılı";
            }
            return Json(new {durum = "Başarılı" });
        }
    }
}
