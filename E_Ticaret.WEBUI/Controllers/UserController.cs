using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.BillingAddress;
using E_Ticaret.Common.DTOs.Member;
using E_Ticaret.Common.DTOs.ShippingAddress;
using E_Ticaret.WEBUI.APIs;
using E_Ticaret.WEBUI.Models.AdressViewModels;
using E_Ticaret.WEBUI.Models.AdressViewModels.BillingAdressVM;
using E_Ticaret.WEBUI.Models.AdressViewModels.ShippingAdressVM;
using E_Ticaret.WEBUI.Models.MemberViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Linq;

namespace E_Ticaret.WEBUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMemberApi _memberApi;
        private readonly ICountryApi _countryApi;
        private readonly ILocationApi _locationApi;
        private readonly IBillingApi _billingApi;
        private readonly IShippingApi _shippingApi;


        public UserController(IMapper mapper, IMemberApi memberapi,
            ICountryApi countryApi, ILocationApi locationApi, IShippingApi shippingApi, IBillingApi billingApi)
        {
            _mapper = mapper;
            _memberApi = memberapi;
            _countryApi = countryApi;
            _locationApi = locationApi;
            _billingApi = billingApi;
            _shippingApi = shippingApi;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var requestResult = await _memberApi.GetById(id);
            if (requestResult.IsSuccessStatusCode && requestResult.Content.IsSuccess && requestResult.Content.ResultData != null)
            {
                var countryResult = await _countryApi.GetActive();
                var locationResult = await _locationApi.GetActive();
                ViewBag.Country = countryResult.Content.ResultData;
                ViewBag.Location = locationResult.Content.ResultData;
                var member = _mapper.Map<UpdateMemberViewModel>(requestResult.Content.ResultData);
                return View(member);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateMemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var memberResult = await _memberApi.PutMember(model.Id, _mapper.Map<MemberRequest>(model));

                if (memberResult.IsSuccessStatusCode && memberResult.Content.IsSuccess && memberResult.Content?.ResultData != null)
                {
                    return RedirectToAction("Index", new { id = model.Id });
                }
            }
            return RedirectToAction("Index", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Address(int? id)
        {
            UpdateAddressVM VM = new UpdateAddressVM();
            var UpdateBillingAdressVM = new UpdateBillingAdressVM();
            var UpdateShippingViewModel = new UpdateShippingViewModel();
            
            var countryResult = await _countryApi.GetActive();
            var locationResult = await _locationApi.GetActive();
            ViewBag.Country = countryResult.Content.ResultData;
            ViewBag.Location = locationResult.Content.ResultData;
            UpdateBillingAdressVM.Firstname = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            UpdateShippingViewModel.Firstname = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            UpdateBillingAdressVM.Surname = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value;
            UpdateShippingViewModel.Surname = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value;

            if (id > 0)
            {
                var bAddressResult = await _billingApi.GetById(id ?? 0);
                var sAddressResult = await _shippingApi.GetById(id ?? 0);
                if (bAddressResult.IsSuccessStatusCode && bAddressResult.Content.IsSuccess && bAddressResult.Content.ResultData != null)
                    UpdateBillingAdressVM = _mapper.Map<UpdateBillingAdressVM>(bAddressResult.Content.ResultData);

                if (sAddressResult.IsSuccessStatusCode && sAddressResult.Content.IsSuccess && sAddressResult.Content.ResultData != null)
                    UpdateShippingViewModel = _mapper.Map<UpdateShippingViewModel>(sAddressResult.Content.ResultData);
            }

            VM.UpdateBillingAdressVM = UpdateBillingAdressVM;
            VM.UpdateShippingViewModel = UpdateShippingViewModel;
            return View(VM);
        }

        [HttpPost]
        public async Task<IActionResult> billingAddress(UpdateAddressVM model)
        {
                Refit.ApiResponse<WebApiResponse<BillingAddressResponse>> bAddressResult;

                if (model.UpdateBillingAdressVM.Id > 0)
                {
                    bAddressResult = await _billingApi.Put(model.UpdateBillingAdressVM.Id, _mapper.Map<BillingAddressRequest>(model.UpdateBillingAdressVM));
                }
                else
                {
                    bAddressResult = await _billingApi.Post(_mapper.Map<BillingAddressRequest>(model.UpdateBillingAdressVM));
                }
                if (bAddressResult.IsSuccessStatusCode && bAddressResult.Content.IsSuccess && bAddressResult.Content.ResultData != null)
                {
                    model.UpdateBillingAdressVM = _mapper.Map<UpdateBillingAdressVM>(bAddressResult.Content.ResultData);
                }

            return RedirectToAction("Address");
        }

        [HttpPost]
        public async Task<IActionResult> shippingAddress(UpdateAddressVM model)
        {
                Refit.ApiResponse<WebApiResponse<ShippingAddressResponse>> bAddressResult;

                if (model.UpdateShippingViewModel.Id > 0)
                {
                    bAddressResult = await _shippingApi.Put(model.UpdateShippingViewModel.Id, _mapper.Map<ShippingAddressRequest>(model.UpdateShippingViewModel));
                }
                else
                {
                    bAddressResult = await _shippingApi.Post(_mapper.Map<ShippingAddressRequest>(model.UpdateShippingViewModel));
                }
                if (bAddressResult.IsSuccessStatusCode && bAddressResult.Content.IsSuccess && bAddressResult.Content.ResultData != null)
                {
                    model.UpdateShippingViewModel = _mapper.Map<UpdateShippingViewModel>(bAddressResult.Content.ResultData);
                }

            return RedirectToAction("Address");
        }
    }
}
