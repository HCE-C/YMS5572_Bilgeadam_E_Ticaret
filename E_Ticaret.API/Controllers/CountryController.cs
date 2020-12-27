using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Country;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.CountryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Country")]
    [ApiController]
    public class CountryController : BaseApiController<CountryController>
    {
        private readonly ICountryService _cs;
        private readonly IMapper _mapper;

        public CountryController(ICountryService cs, IMapper mapper)
        {
            _cs = cs;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<CountryResponse>>> GetAll()
        {
            var result = _mapper.Map<List<CountryResponse>>(await _cs.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<CountryResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<CountryResponse>>("Bir şeyler ters gitti", false);

        }
      
        [HttpGet("{id}")]
        public async Task<WebApiResponse<CountryResponse>> GetById(int id)
        {
            var result = _mapper.Map<CountryResponse>(await _cs.GetById(id));
            if (result != null)
                return new WebApiResponse<CountryResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<CountryResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<CountryResponse>>> GetByIds(CountryRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<Country>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<CountryResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _cs.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort !=null && request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if(request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<CountryResponse>>(entityList);

            return new WebApiResponse<List<CountryResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CountryResponse>>> Put(int id, CountryRequest request)
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
                    var rm = _mapper.Map<CountryResponse>(updateResult);
                    return new WebApiResponse<CountryResponse>("Success", true, rm);
                }
                return new WebApiResponse<CountryResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CountryResponse>>> Post(CountryRequest request)
        {
            var entity = _mapper.Map<Country>(request);

            var insertResult = await _cs.Add(entity);
            if (insertResult != null)
            {
                var rm = _mapper.Map<CountryResponse>(insertResult);
                return new WebApiResponse<CountryResponse>("Success", true, rm);
            }
            return new WebApiResponse<CountryResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CountryResponse>>> Delete(int id)
        {
            var entity = _mapper.Map<CountryResponse>(await _cs.TableNoTracking.FirstOrDefaultAsync(x=>x.Id == id));
            if (entity != null)
            {
                var deleteResult = await _cs.Delete(_mapper.Map<Country>(entity));
                if (deleteResult)
                    return new WebApiResponse<CountryResponse>("Success", true, entity);
                else
                    return new WebApiResponse<CountryResponse>("Error", false);
            }
            return new WebApiResponse<CountryResponse>("Error", false);
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
        public async Task<WebApiResponse<List<CountryRequest>>> GetActive()
        {
            var result = _mapper.Map<List<CountryRequest>>(await _cs.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<CountryRequest>>("Success", true, result);
            }
            return new WebApiResponse<List<CountryRequest>>("Error", false);
        }
    }
}