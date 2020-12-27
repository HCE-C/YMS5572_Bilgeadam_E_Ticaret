using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.MailListGroup;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.MailListGroupService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("MailListGroup")]
    [ApiController]
    public class MailListGroupController : BaseApiController<MailListGroupController>
    {
        private readonly IMailListGroupService _mlg;
        private readonly IMapper _mapper;
        public MailListGroupController(IMailListGroupService mlg, IMapper mapper)
        {
            _mlg = mlg;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<MailListGroupResponse>>> GetAll()
        {
            var result = _mapper.Map<List<MailListGroupResponse>>(await _mlg.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<MailListGroupResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<MailListGroupResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<MailListGroupResponse>> GetById(int id)
        {
            var result = _mapper.Map<MailListGroupResponse>(await _mlg.GetById(id));
            if (result != null)
                return new WebApiResponse<MailListGroupResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<MailListGroupResponse>("Bir şeyler ters gitti", false);

        }

        [HttpPut("{id}")]
        public async Task<WebApiResponse<MailListGroupResponse>> PutMailListGroup(int id, MailListGroupRequest request)
        {
            if (id != request.Id)
                return new WebApiResponse<MailListGroupResponse>("Error", false);
            try
            {
                var entity = await _mlg.GetById(id);
                if (entity == null)
                    return new WebApiResponse<MailListGroupResponse>("Error", false);
                _mapper.Map(request, entity);

                var updateResult = await _mlg.Update(entity, id);
                if (updateResult != null)
                {
                    MailListGroupResponse rm = _mapper.Map<MailListGroupResponse>(updateResult);
                    return new WebApiResponse<MailListGroupResponse>("Success", true, rm);
                }
                return new WebApiResponse<MailListGroupResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<WebApiResponse<MailListGroupResponse>> PostMailListGroup(MailListGroupRequest request)
        {
            var entity = _mapper.Map<MailListGroup>(request);

            var insertResult = await _mlg.Add(entity);
            if (insertResult != null)
            {
                MailListGroupResponse rm = _mapper.Map<MailListGroupResponse>(insertResult);
                return new WebApiResponse<MailListGroupResponse>("Success", true, rm);
            }
            return new WebApiResponse<MailListGroupResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<WebApiResponse<MailListGroupResponse>> DeleteMailListGroup(int id)
        {
            var result = _mapper.Map<MailListGroupResponse>(await _mlg.TableNoTracking.FirstOrDefaultAsync(x=>x.Id == id));
            if (result != null)
            {
                var deleteResult = await _mlg.Delete(_mapper.Map<MailListGroup>(result));
                if (deleteResult)
                    return new WebApiResponse<MailListGroupResponse>("Success", true, result);
                else
                    return new WebApiResponse<MailListGroupResponse>("Error", false);
            }
            return new WebApiResponse<MailListGroupResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<WebApiResponse<bool>> Activate(int id)
        {
            bool result = await _mlg.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<WebApiResponse<List<MailListGroupResponse>>> GetActive()
        {
            var result = _mapper.Map<List<MailListGroupResponse>>(await _mlg.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<MailListGroupResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<MailListGroupResponse>>("Error", false);
        }
    }
}