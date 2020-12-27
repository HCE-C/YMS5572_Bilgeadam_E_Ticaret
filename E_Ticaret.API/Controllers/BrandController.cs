using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Brand;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.BrandService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Brand")]
    [ApiController]
    public class BrandController : BaseApiController<BrandController>
    {
        private readonly IBrandService _brandservice;
        private readonly IMapper _mapper;
        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandservice = brandService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<BrandResponse>>> GetAll()
        {
            var memberResult = _mapper.Map<List<BrandResponse>>(await _brandservice.Table.ToListAsync());
            if (memberResult.Count > 0)
                return new WebApiResponse<List<BrandResponse>>("Sonuç başarılı", true, memberResult);
            return new WebApiResponse<List<BrandResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<BrandResponse>>> GetAllByParam(BrandRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<BrandResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<BrandResponse>>(await _brandservice.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<BrandResponse>>(await _brandservice.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<BrandResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<BrandResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<BrandResponse>> GetById(int id)
        {
            var result = _mapper.Map<BrandResponse>(await _brandservice.GetById(id));
            if (result != null)
                return new WebApiResponse<BrandResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<BrandResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<BrandResponse>>> GetByIds(BrandRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            List<Brand> entityList = new List<Brand>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<BrandResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _brandservice.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<BrandResponse>>(entityList);

            return new WebApiResponse<List<BrandResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> PutBrand(int id, BrandRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _brandservice.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _brandservice.Update(entity, id);
                if (updateResult != null)
                {
                    BrandResponse rm = _mapper.Map<BrandResponse>(updateResult);
                    return new WebApiResponse<BrandResponse>("Success", true, rm);
                }
                return new WebApiResponse<BrandResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> Post(BrandRequest request)
        {
            Brand entity = _mapper.Map<Brand>(request);

            var insertResult = await _brandservice.Add(entity);
            if (insertResult != null)
            {
                BrandResponse rm = _mapper.Map<BrandResponse>(insertResult);
                return new WebApiResponse<BrandResponse>("Success", true, rm);
            }
            return new WebApiResponse<BrandResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> Delete(int id)
        {
            var entity = _mapper.Map<BrandResponse>(await _brandservice.GetById(id));
            if (entity != null)
            {
                var deleteResult = await _brandservice.Delete(_mapper.Map<Brand>(entity));
                if (deleteResult)
                    return new WebApiResponse<BrandResponse>("Success", true, entity);
                else
                    return new WebApiResponse<BrandResponse>("Error", false);
            }
            return new WebApiResponse<BrandResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _brandservice.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<BrandResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<BrandResponse>>(await _brandservice.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<BrandResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<BrandResponse>>("Error", false);
        }
    }
}