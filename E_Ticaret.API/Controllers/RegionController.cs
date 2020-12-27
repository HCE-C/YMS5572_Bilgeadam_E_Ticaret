using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Region;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.RegionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Region")]
    [ApiController]
    public class RegionController : BaseApiController<RegionController>
    {
        private readonly IRegionService _rs;
        private readonly IMapper _mapper;
        public RegionController(IRegionService rs, IMapper mapper)
        {
            _rs = rs;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<RegionResponse>>> GetAll()
        {
            var result = _mapper.Map<List<RegionResponse>>(await _rs.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<RegionResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<RegionResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<RegionResponse>>> GetAllByParam(RegionRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<RegionResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<RegionResponse>>(await _rs.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<RegionResponse>>(await _rs.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<RegionResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<RegionResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<RegionResponse>> GetById(int id)
        {
            var result = _mapper.Map<RegionResponse>(await _rs.GetById(id));
            if (result != null)
                return new WebApiResponse<RegionResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<RegionResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<RegionResponse>>> GetByIds(RegionRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<Region>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<RegionResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _rs.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<RegionResponse>>(entityList);

            return new WebApiResponse<List<RegionResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<WebApiResponse<RegionResponse>> PutMember(int id, RegionRequest request)
        {
            if (id != request.Id)
                return new WebApiResponse<RegionResponse>("Error", false);
            try
            {
                var entity = await _rs.GetById(id);
                if (entity == null)
                    return new WebApiResponse<RegionResponse>("Error", false);
                _mapper.Map(request, entity);

                var updateResult = await _rs.Update(entity, id);
                if (updateResult != null)
                {
                    RegionResponse rm = _mapper.Map<RegionResponse>(updateResult);
                    return new WebApiResponse<RegionResponse>("Success", true, rm);
                }
                return new WebApiResponse<RegionResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<WebApiResponse<RegionResponse>> PostUser(RegionRequest request)
        {
            var entity = _mapper.Map<Region>(request);

            var insertResult = await _rs.Add(entity);
            if (insertResult != null)
            {
                RegionResponse rm = _mapper.Map<RegionResponse>(insertResult);
                return new WebApiResponse<RegionResponse>("Success", true, rm);
            }
            return new WebApiResponse<RegionResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<WebApiResponse<RegionResponse>> DeleteUser(int id)
        {
            var result = _mapper.Map<RegionResponse>(await _rs.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
            if (result != null)
            {
                var deleteResult = await _rs.Delete(_mapper.Map<Region>(result));
                if (deleteResult)
                    return new WebApiResponse<RegionResponse>("Success", true, result);
                else
                    return new WebApiResponse<RegionResponse>("Error", false);
            }
            return new WebApiResponse<RegionResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _rs.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<RegionResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<RegionResponse>>(await _rs.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<RegionResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<RegionResponse>>("Error", false);
        }
    }
}