using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.MailList;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.MailListService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.API.Controllers
{
    [Route("MailList")]
    [ApiController]
    public class MailListController : BaseApiController<MailListController>
    {
        private readonly IMailListService _ml;
        private readonly IMapper _mapper;
        public MailListController(IMailListService cs, IMapper mapper)
        {
            _ml = cs;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<MailListResponse>>> GetAll()
        {
            var result = _mapper.Map<List<MailListResponse>>(await _ml.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<MailListResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<MailListResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<MailListResponse>> GetById(int id)
        {
            var result = _mapper.Map<MailListResponse>(await _ml.GetById(id));
            if (result != null)
                return new WebApiResponse<MailListResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<MailListResponse>("Bir şeyler ters gitti", false);

        }

        [HttpPut("{id}")]
        public async Task<WebApiResponse<MailListResponse>> PutMailList(int id, MailListRequest request)
        {
            if (id != request.Id)
                return new WebApiResponse<MailListResponse>("Error", false);
            try
            {
                var entity = await _ml.GetById(id);
                if (entity == null)
                    return new WebApiResponse<MailListResponse>("Error", false);
                _mapper.Map(request, entity);

                var updateResult = await _ml.Update(entity, id);
                if (updateResult != null)
                {
                    MailListResponse rm = _mapper.Map<MailListResponse>(updateResult);
                    return new WebApiResponse<MailListResponse>("Success", true, rm);
                }
                return new WebApiResponse<MailListResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<WebApiResponse<MailListResponse>> PostMailList(MailListRequest request)
        {
            var entity = _mapper.Map<MailList>(request);

            var insertResult = await _ml.Add(entity);
            if (insertResult != null)
            {
                MailListResponse rm = _mapper.Map<MailListResponse>(insertResult);
                return new WebApiResponse<MailListResponse>("Success", true, rm);
            }
            return new WebApiResponse<MailListResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<WebApiResponse<MailListResponse>> DeleteMailList(int id)
        {
            var result = _mapper.Map<MailListResponse>(await _ml.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
            if (result != null)
            {
                var deleteResult = await _ml.Delete(_mapper.Map<MailList>(result));
                if (deleteResult)
                    return new WebApiResponse<MailListResponse>("Success", true, result);
                else
                    return new WebApiResponse<MailListResponse>("Error", false);
            }
            return new WebApiResponse<MailListResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _ml.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<WebApiResponse<List<MailListResponse>>> GetActive()
        {
            var result = _mapper.Map<List<MailListResponse>>(await _ml.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<MailListResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<MailListResponse>>("Error", false);
        }
    }
}