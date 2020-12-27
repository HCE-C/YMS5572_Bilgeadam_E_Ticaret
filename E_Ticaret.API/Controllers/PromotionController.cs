using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Promotion;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.PromotionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Promotion")]
    [ApiController]
    public class PromotionController : BaseApiController<PromotionController>
    {
        private readonly IPromotionService _proms;
        private readonly IMapper _mapper;
        public PromotionController(IPromotionService proms, IMapper mapper)
        {
            _proms = proms;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<PromotionResponse>>> GetAll()
        {
            var result = _mapper.Map<List<PromotionResponse>>(await _proms.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<PromotionResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<PromotionResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<PromotionResponse>>> GetAllByParam(PromotionRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<PromotionResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<PromotionResponse>>(await _proms.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<PromotionResponse>>(await _proms.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<PromotionResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<PromotionResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<PromotionResponse>> GetById(int id)
        {
            var result = _mapper.Map<PromotionResponse>(await _proms.GetById(id));
            if (result != null)
                return new WebApiResponse<PromotionResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<PromotionResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<PromotionResponse>>> GetByIds(PromotionRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<Promotion>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<PromotionResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _proms.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<PromotionResponse>>(entityList);

            return new WebApiResponse<List<PromotionResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PromotionResponse>>> PutMember(int id, PromotionRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _proms.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _proms.Update(entity, id);
                if (updateResult != null)
                {
                    PromotionResponse rm = _mapper.Map<PromotionResponse>(updateResult);
                    return new WebApiResponse<PromotionResponse>("Success", true, rm);
                }
                return new WebApiResponse<PromotionResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PromotionResponse>>> PostUser(PromotionRequest request)
        {
            var entity = _mapper.Map<Promotion>(request);

            var insertResult = await _proms.Add(entity);
            if (insertResult != null)
            {
                PromotionResponse rm = _mapper.Map<PromotionResponse>(insertResult);
                return new WebApiResponse<PromotionResponse>("Success", true, rm);
            }
            return new WebApiResponse<PromotionResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<PromotionResponse>>> DeleteUser(int id)
        {
            var result = _mapper.Map<PromotionResponse>(await _proms.GetById(id));
            if (result != null)
            {
                var deleteResult = await _proms.Delete(_mapper.Map<Promotion>(result));
                if (deleteResult)
                    return new WebApiResponse<PromotionResponse>("Success", true, result);
                else
                    return new WebApiResponse<PromotionResponse>("Error", false);
            }
            return new WebApiResponse<PromotionResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _proms.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<PromotionResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<PromotionResponse>>(await _proms.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<PromotionResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<PromotionResponse>>("Error", false);
        }
    }
}