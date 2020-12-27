using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.ProductToCategory;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.ProductToCategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("ProductToCategory")]
    [ApiController]
    public class ProductToCategoryController : BaseApiController<ProductToCategoryController>
    {
        private readonly IProductToCategoryService _pgs;
        private readonly IMapper _mapper;
        public ProductToCategoryController(IProductToCategoryService pgs, IMapper mapper)
        {
            _pgs = pgs;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<ProductToCategoryResponse>>> GetAll()
        {
            var result = _mapper.Map<List<ProductToCategoryResponse>>(await _pgs.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<ProductToCategoryResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ProductToCategoryResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<ProductToCategoryResponse>>> GetAllByParam(ProductToCategoryRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<ProductToCategoryResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<ProductToCategoryResponse>>(await _pgs.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<ProductToCategoryResponse>>(await _pgs.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<ProductToCategoryResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ProductToCategoryResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<ProductToCategoryResponse>> GetById(int id)
        {
            var result = _mapper.Map<ProductToCategoryResponse>(await _pgs.GetById(id));
            if (result != null)
                return new WebApiResponse<ProductToCategoryResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<ProductToCategoryResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<ProductToCategoryResponse>>> GetByIds(ProductToCategoryRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<ProductToCategory>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<ProductToCategoryResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _pgs.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<ProductToCategoryResponse>>(entityList);

            return new WebApiResponse<List<ProductToCategoryResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductToCategoryResponse>>> Put(int id, ProductToCategoryRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _pgs.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _pgs.Update(entity, id);
                if (updateResult != null)
                {
                    ProductToCategoryResponse rm = _mapper.Map<ProductToCategoryResponse>(updateResult);
                    return new WebApiResponse<ProductToCategoryResponse>("Success", true, rm);
                }
                return new WebApiResponse<ProductToCategoryResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductToCategoryResponse>>> Post(ProductToCategoryRequest request)
        {
            var entity = _mapper.Map<ProductToCategory>(request);

            var insertResult = await _pgs.Add(entity);
            if (insertResult != null)
            {
                ProductToCategoryResponse rm = _mapper.Map<ProductToCategoryResponse>(insertResult);
                return new WebApiResponse<ProductToCategoryResponse>("Success", true, rm);
            }
            return new WebApiResponse<ProductToCategoryResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductToCategoryResponse>>> Delete(int id)
        {
            var result = _mapper.Map<ProductToCategoryResponse>(await _pgs.GetById(id));
            if (result != null)
            {
                var deleteResult = await _pgs.Delete(_mapper.Map<ProductToCategory>(result));
                if (deleteResult)
                    return new WebApiResponse<ProductToCategoryResponse>("Success", true, result);
                else
                    return new WebApiResponse<ProductToCategoryResponse>("Error", false);
            }
            return new WebApiResponse<ProductToCategoryResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _pgs.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<ProductToCategoryResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<ProductToCategoryResponse>>(await _pgs.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<ProductToCategoryResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<ProductToCategoryResponse>>("Error", false);
        }
    }
}