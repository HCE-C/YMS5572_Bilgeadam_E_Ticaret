using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.ProductToCountDown;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.ProductToCountDownService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("ProductToCountDown")]
    [ApiController]
    public class ProductToCountDownController : BaseApiController<ProductToCountDownController>
    {
        private readonly IProductToCountDownService _pcs;
        private readonly IMapper _mapper;
        public ProductToCountDownController(IProductToCountDownService pcs, IMapper mapper)
        {
            _pcs = pcs;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<ProductToCountDownResponse>>> GetAll()
        {
            var result = _mapper.Map<List<ProductToCountDownResponse>>(await _pcs.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<ProductToCountDownResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ProductToCountDownResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<ProductToCountDownResponse>>> GetAllByParam(ProductToCountDownRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<ProductToCountDownResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<ProductToCountDownResponse>>(await _pcs.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<ProductToCountDownResponse>>(await _pcs.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<ProductToCountDownResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ProductToCountDownResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<ProductToCountDownResponse>> GetById(int id)
        {
            var result = _mapper.Map<ProductToCountDownResponse>(await _pcs.GetById(id));
            if (result != null)
                return new WebApiResponse<ProductToCountDownResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<ProductToCountDownResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<ProductToCountDownResponse>>> GetByIds(ProductToCountDownRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<ProductToCountDown>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<ProductToCountDownResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _pcs.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<ProductToCountDownResponse>>(entityList);

            return new WebApiResponse<List<ProductToCountDownResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductToCountDownResponse>>> Put(int id, ProductToCountDownRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _pcs.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _pcs.Update(entity, id);
                if (updateResult != null)
                {
                    ProductToCountDownResponse rm = _mapper.Map<ProductToCountDownResponse>(updateResult);
                    return new WebApiResponse<ProductToCountDownResponse>("Success", true, rm);
                }
                return new WebApiResponse<ProductToCountDownResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductToCountDownResponse>>> Post(ProductToCountDownRequest request)
        {
            var entity = _mapper.Map<ProductToCountDown>(request);

            var insertResult = await _pcs.Add(entity);
            if (insertResult != null)
            {
                ProductToCountDownResponse rm = _mapper.Map<ProductToCountDownResponse>(insertResult);
                return new WebApiResponse<ProductToCountDownResponse>("Success", true, rm);
            }
            return new WebApiResponse<ProductToCountDownResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductToCountDownResponse>>> Delete(int id)
        {
            var result = _mapper.Map<ProductToCountDownResponse>(await _pcs.GetById(id));
            if (result != null)
            {
                var deleteResult = await _pcs.Delete(_mapper.Map<ProductToCountDown>(result));
                if (deleteResult)
                    return new WebApiResponse<ProductToCountDownResponse>("Success", true, result);
                else
                    return new WebApiResponse<ProductToCountDownResponse>("Error", false);
            }
            return new WebApiResponse<ProductToCountDownResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _pcs.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<ProductToCountDownResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<ProductToCountDownResponse>>(await _pcs.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<ProductToCountDownResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<ProductToCountDownResponse>>("Error", false);
        }
    }
}