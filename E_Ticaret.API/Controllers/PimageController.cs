using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Pimage;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.PimageService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Pimage")]
    [ApiController]
    public class PimageController : BaseApiController<PimageController>
    {
        private readonly IPimageService _pis;
        private readonly IMapper _mapper;
        public PimageController(IPimageService pis, IMapper mapper)
        {
            _pis = pis;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<WebApiResponse<List<PimageResponse>>> GetAll()
        {
            var result = _mapper.Map<List<PimageResponse>>(await _pis.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<PimageResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<PimageResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<PimageResponse>>> GetAllByParam(PimageRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<PimageResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<PimageResponse>>(await _pis.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<PimageResponse>>(await _pis.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<PimageResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<PimageResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<PimageResponse>> GetById(int id)
        {
            var result = _mapper.Map<PimageResponse>(await _pis.GetById(id));
            if (result != null)
                return new WebApiResponse<PimageResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<PimageResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<PimageResponse>>> GetByIds(PimageRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<Pimage>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<PimageResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _pis.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<PimageResponse>>(entityList);

            return new WebApiResponse<List<PimageResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PimageResponse>>> Put(int id, PimageRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _pis.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _pis.Update(entity, id);
                if (updateResult != null)
                {
                    PimageResponse rm = _mapper.Map<PimageResponse>(updateResult);
                    return new WebApiResponse<PimageResponse>("Success", true, rm);
                }
                return new WebApiResponse<PimageResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<WebApiResponse<PimageResponse>> Post(PimageRequest request)
        {
            var entity = _mapper.Map<Pimage>(request);

            var insertResult = await _pis.Add(entity);
            if (insertResult != null)
            {
                PimageResponse rm = _mapper.Map<PimageResponse>(insertResult);
                return new WebApiResponse<PimageResponse>("Success", true, rm);
            }
            return new WebApiResponse<PimageResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<PimageResponse>>> Delete(int id)
        {
            var result = _mapper.Map<PimageResponse>(await _pis.GetById(id));
            if (result != null)
            {
                var deleteResult = await _pis.Delete(_mapper.Map<Pimage>(result));
                if (deleteResult)
                    return new WebApiResponse<PimageResponse>("Success", true, result);
                else
                    return new WebApiResponse<PimageResponse>("Error", false);
            }
            return new WebApiResponse<PimageResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _pis.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<PimageResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<PimageResponse>>(await _pis.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<PimageResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<PimageResponse>>("Error", false);
        }
    }
}