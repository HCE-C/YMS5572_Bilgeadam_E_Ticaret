using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_Ticaret.Common.DTOs.MailList;
using E_Ticaret.Common.DTOs.MailListGroup;
using E_Ticaret.WEBUI.APIs;
using E_Ticaret.WEBUI.Areas.Admin.Models.MailListViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailListController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMailList _mailList;
        private readonly IMailListGroup _mailListGroup;
        public MailListController(IMapper mapper, IMailList mailList, IMailListGroup mailListGroup)
        {
            _mapper = mapper;
            _mailList = mailList;
            _mailListGroup = mailListGroup;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "MailList";

            var vm = new MasterMailVM();
            var mailList = new List<MailListVM>();
            var mailListGroup = new List<MailListGroupVM>();

            var mailListResult = await _mailList.GetAll();
            if (mailListResult.IsSuccessStatusCode && mailListResult.Content.IsSuccess && mailListResult.Content.ResultData != null)
                mailList = _mapper.Map<List<MailListVM>>(mailListResult.Content.ResultData);

            var mailListGroupResult = await _mailListGroup.GetAll();
            if (mailListGroupResult.IsSuccessStatusCode && mailListGroupResult.Content.IsSuccess && mailListGroupResult.Content.ResultData != null)
                mailListGroup = _mapper.Map<List<MailListGroupVM>>(mailListGroupResult.Content.ResultData);

            vm.MailListVMs = mailList;
            vm.MailListGroupVMs = mailListGroup;

            return View(vm);
        }
        public async Task<IActionResult> Delete(int id, string name)
        {
            if (id > 0)
            {
                switch (name)
                {
                    case "MailList":
                        var mailListResult = await _mailList.DeleteMailList(id);
                        if (mailListResult.IsSuccessStatusCode && mailListResult.Content.IsSuccess && mailListResult.Content.ResultData != null)
                            break;
                        break;
                    case "MailListGroup":
                        var mailListGroupResult = await _mailListGroup.DeleteMailListGroup(id);
                        if (mailListGroupResult.IsSuccessStatusCode && mailListGroupResult.Content.IsSuccess && mailListGroupResult.Content.ResultData != null)
                            break;
                        break;

                    default:
                        break;
                }

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMailList(int id)
        {
            ViewData["Active"] = "MailList";

            MailListVM model = new MailListVM();
            if (id > 0)
            {
                var mailListResult = await _mailList.GetById(id);
                if (mailListResult.IsSuccessStatusCode && mailListResult.Content.IsSuccess && mailListResult.Content.ResultData != null)
                    model = _mapper.Map<MailListVM>(mailListResult.Content.ResultData);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMailList(MailListVM model)
        {
            if (model.Id > 0 && ModelState.IsValid)
            {
                var mailListResult = await _mailList.PutMailList(model.Id, _mapper.Map<MailListRequest>(model));
                if (mailListResult.IsSuccessStatusCode && mailListResult.Content.IsSuccess && mailListResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);
            }
            else if (ModelState.IsValid)
            {
                var mailListResult = await _mailList.PostMailList(_mapper.Map<MailListRequest>(model));
                if (mailListResult.IsSuccessStatusCode && mailListResult.Content.IsSuccess && mailListResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMailListGroup(int id)
        {
            ViewData["Active"] = "MailList";

            MailListGroupVM model = new MailListGroupVM();
            if (id > 0)
            {
                var mailListGroupResult = await _mailListGroup.GetById(id);
                if (mailListGroupResult.IsSuccessStatusCode && mailListGroupResult.Content.IsSuccess && mailListGroupResult.Content.ResultData != null)
                    model = _mapper.Map<MailListGroupVM>(mailListGroupResult.Content.ResultData);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMailListGroup(MailListGroupVM model)
        {
            if (model.Id > 0 && ModelState.IsValid)
            {
                var mailListGroupResult = await _mailListGroup.PutMailListGroup(model.Id, _mapper.Map<MailListGroupRequest>(model));
                if (mailListGroupResult.IsSuccessStatusCode && mailListGroupResult.Content.IsSuccess && mailListGroupResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);
            }
            else if (ModelState.IsValid)
            {
                var mailListGroupResult = await _mailListGroup.PostMailListGroup(_mapper.Map<MailListGroupRequest>(model));
                if (mailListGroupResult.IsSuccessStatusCode && mailListGroupResult.Content.IsSuccess && mailListGroupResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                return View(model);
            }
            return View(model);
        }
    }
}
