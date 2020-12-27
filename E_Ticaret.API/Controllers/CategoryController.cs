using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Category;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Category")]
    [ApiController]
    public class CategoryController : BaseApiController<CategoryController>
    {
        private readonly ICategoryService _cs;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService bs, IMapper mapper)
        {
            _cs = bs;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<WebApiResponse<List<CategoryResponse>>> GetAll()
        {
            var result = _mapper.Map<List<CategoryResponse>>(await _cs.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<CategoryResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<CategoryResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("Special")]
        public async Task<WebApiResponse<List<CategoryResponse>>> GetAllByParam(CategoryRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<CategoryResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<CategoryResponse>>(await _cs.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<CategoryResponse>>(await _cs.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<CategoryResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<CategoryResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<CategoryResponse>> GetById(int id)
        {
            var result = _mapper.Map<CategoryResponse>(await _cs.GetById(id));
            if (result != null)
                return new WebApiResponse<CategoryResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<CategoryResponse>("Bir şeyler ters gitti", false);

        }

        [HttpGet("List")]
        public async Task<WebApiResponse<List<CategoryResponse>>> GetByIds(CategoryRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<Category>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<CategoryResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _cs.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<CategoryResponse>>(entityList);

            return new WebApiResponse<List<CategoryResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> Put(int id, CategoryRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _cs.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _cs.Update(entity, id);
                if (updateResult != null)
                {
                    CategoryResponse rm = _mapper.Map<CategoryResponse>(updateResult);
                    return new WebApiResponse<CategoryResponse>("Success", true, rm);
                }
                return new WebApiResponse<CategoryResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> Post(CategoryRequest request)
        {
            var entity = _mapper.Map<Category>(request);

            var insertResult = await _cs.Add(entity);
            if (insertResult != null)
            {
                CategoryResponse rm = _mapper.Map<CategoryResponse>(insertResult);
                return new WebApiResponse<CategoryResponse>("Success", true, rm);
            }
            return new WebApiResponse<CategoryResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> Delete(int id)
        {
            var result = await _cs.GetById(id);
            if (result != null)
            {
                var deleteResult = await _cs.Delete(_mapper.Map<Category>(result));
                if (deleteResult)
                    return new WebApiResponse<CategoryResponse>("Success", true, _mapper.Map<CategoryResponse>(result));
                else
                    return new WebApiResponse<CategoryResponse>("Error", false);
            }
            return new WebApiResponse<CategoryResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _cs.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [AllowAnonymous]
        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<CategoryResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<CategoryResponse>>(await _cs.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<CategoryResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<CategoryResponse>>("Error", false);
        }
    }
}