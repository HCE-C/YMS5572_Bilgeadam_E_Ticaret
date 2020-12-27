using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Product;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : BaseApiController<ProductController>
    {
        private readonly IProductService _ps;
        private readonly IMapper _mapper;
        public ProductController(IProductService ps, IMapper mapper)
        {
            _ps = ps;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<WebApiResponse<List<ProductResponse>>> GetAll()
        {
            var result = _mapper.Map<List<ProductResponse>>(await _ps.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<ProductResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ProductResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("Special")]
        public async Task<WebApiResponse<List<ProductResponse>>> GetAllByParam(ProductRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<ProductResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<ProductResponse>>(await _ps.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<ProductResponse>>(await _ps.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<ProductResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ProductResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<ProductResponse>> GetById(int id)
        {
            var result = _mapper.Map<ProductResponse>(await _ps.GetById(id));
            if (result != null)
                return new WebApiResponse<ProductResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<ProductResponse>("Bir şeyler ters gitti", false);

        }

        [HttpGet("List")]
        public async Task<WebApiResponse<List<ProductResponse>>> GetByIds(ProductRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<Product>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<ProductResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _ps.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<ProductResponse>>(entityList);

            return new WebApiResponse<List<ProductResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }

        [HttpPut("{id}")]
        public async Task<WebApiResponse<ProductResponse>> Put(int id, ProductRequest request)
        {
            if (id != request.Id)
                return new WebApiResponse<ProductResponse>("Bad Requet", false);
            try
            {
                var entity = await _ps.GetById(id);
                if (entity == null)
                    return new WebApiResponse<ProductResponse>("Not Found", false);
                entity.Status = Core.Entity.Enums.Status.Updated;
                _mapper.Map(request, entity);

                var updateResult = await _ps.Update(entity, id);
                if (updateResult != null)
                {
                    ProductResponse rm = _mapper.Map<ProductResponse>(updateResult);
                    return new WebApiResponse<ProductResponse>("Success", true, rm);
                }
                return new WebApiResponse<ProductResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<WebApiResponse<ProductResponse>> Post(ProductRequest request)
        {
            var entity = _mapper.Map<Product>(request);

            var insertResult = await _ps.Add(entity);
            if (insertResult != null)
            {
                ProductResponse rm = _mapper.Map<ProductResponse>(insertResult);
                return new WebApiResponse<ProductResponse>("Success", true, rm);
            }
            return new WebApiResponse<ProductResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> Delete(int id)
        {
            var result = _mapper.Map<ProductResponse>(await _ps.TableNoTracking.FirstOrDefaultAsync(x=>x.Id == id));
            if (result != null)
            {
                var deleteResult = await _ps.Delete(_mapper.Map<Product>(result));
                if (deleteResult)
                    return new WebApiResponse<ProductResponse>("Success", true, result);
                else
                    return new WebApiResponse<ProductResponse>("Error", false);
            }
            return new WebApiResponse<ProductResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _ps.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [AllowAnonymous]
        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<ProductResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<ProductResponse>>(await _ps.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<ProductResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<ProductResponse>>("Error", false);
        }
    }
}