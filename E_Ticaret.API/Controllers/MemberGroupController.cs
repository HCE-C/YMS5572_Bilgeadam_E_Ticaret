using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.MemberGroup;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.MemberGroupService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("MemberGroup")]
    [ApiController]
    public class MemberGroupController : BaseApiController<MemberGroupController>
    {
        private readonly IMemberGroupService _mg;
        private readonly IMapper _mapper;
        public MemberGroupController(IMemberGroupService mg, IMapper mapper)
        {
            _mg = mg;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<MemberGroupResponse>>> GetAll()
        {
            var result = _mapper.Map<List<MemberGroupResponse>>(await _mg.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<MemberGroupResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<MemberGroupResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<MemberGroupResponse>> GetById(int id)
        {
            var result = _mapper.Map<MemberGroupResponse>(await _mg.GetById(id));
            if (result != null)
                return new WebApiResponse<MemberGroupResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<MemberGroupResponse>("Bir şeyler ters gitti", false);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberGroupResponse>>> Put(int id, MemberGroupRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _mg.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _mg.Update(entity, id);
                if (updateResult != null)
                {
                    MemberGroupResponse rm = _mapper.Map<MemberGroupResponse>(updateResult);
                    return new WebApiResponse<MemberGroupResponse>("Success", true, rm);
                }
                return new WebApiResponse<MemberGroupResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<MemberGroupResponse>>> Post(MemberGroupRequest request)
        {
            var entity = _mapper.Map<MemberGroup>(request);

            var insertResult = await _mg.Add(entity);
            if (insertResult != null)
            {
                MemberGroupResponse rm = _mapper.Map<MemberGroupResponse>(insertResult);
                return new WebApiResponse<MemberGroupResponse>("Success", true, rm);
            }
            return new WebApiResponse<MemberGroupResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberGroupResponse>>> Delete(int id)
        {
            var result = _mapper.Map<MemberGroupResponse>(await _mg.GetById(id));
            if (result != null)
            {
                var deleteResult = await _mg.Delete(_mapper.Map<MemberGroup>(result));
                if (deleteResult)
                    return new WebApiResponse<MemberGroupResponse>("Success", true, result);
                else
                    return new WebApiResponse<MemberGroupResponse>("Error", false);
            }
            return new WebApiResponse<MemberGroupResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _mg.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<MemberGroupResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<MemberGroupResponse>>(await _mg.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<MemberGroupResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<MemberGroupResponse>>("Error", false);
        }
    }
}