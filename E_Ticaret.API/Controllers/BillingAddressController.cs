using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.BillingAddress;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.BillingAddressService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("BillingAddress")]
    [ApiController]
    public class BillingAddressController : BaseApiController<BillingAddressController>
    {
        private readonly IBillingAddressService _bs;
        private readonly IMapper _mapper;
        public BillingAddressController(IBillingAddressService bs, IMapper mapper)
        {
            _bs = bs;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<WebApiResponse<List<BillingAddressResponse>>> GetAll()
        {
            var result = _mapper.Map<List<BillingAddressResponse>>(await _bs.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<BillingAddressResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<BillingAddressResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("Special")]
        public async Task<WebApiResponse<List<BillingAddressResponse>>> GetAllByParam(BillingAddressRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<BillingAddressResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<BillingAddressResponse>>(await _bs.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<BillingAddressResponse>>(await _bs.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<BillingAddressResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<BillingAddressResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<BillingAddressResponse>> GetById(int id)
        {
            var result = _mapper.Map<BillingAddressResponse>(await _bs.GetByDefault(x=>x.CreatedMemberId == id));
            if (result != null)
                return new WebApiResponse<BillingAddressResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<BillingAddressResponse>("Bir şeyler ters gitti", false);

        }

        [HttpGet("List")]
        public async Task<WebApiResponse<List<BillingAddressResponse>>> GetByIds(BillingAddressRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<BillingAddress>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<BillingAddressResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _bs.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<BillingAddressResponse>>(entityList);

            return new WebApiResponse<List<BillingAddressResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<BillingAddressResponse>>> Put(int id, BillingAddressRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _bs.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _bs.Update(entity, id);
                if (updateResult != null)
                {
                    BillingAddressResponse rm = _mapper.Map<BillingAddressResponse>(updateResult);
                    return new WebApiResponse<BillingAddressResponse>("Success", true, rm);
                }
                return new WebApiResponse<BillingAddressResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<BillingAddressResponse>>> Post(BillingAddressRequest request)
        {
            var entity = _mapper.Map<BillingAddress>(request);

            var insertResult = await _bs.Add(entity);
            if (insertResult != null)
            {
                BillingAddressResponse rm = _mapper.Map<BillingAddressResponse>(insertResult);
                return new WebApiResponse<BillingAddressResponse>("Success", true, rm);
            }
            return new WebApiResponse<BillingAddressResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<BillingAddressResponse>>> Delete(int id)
        {
            var result = _mapper.Map<BillingAddressResponse>(await _bs.GetById(id));
            if (result != null)
            {
                var deleteResult = await _bs.Delete(_mapper.Map<BillingAddress>(result));
                if (deleteResult)
                    return new WebApiResponse<BillingAddressResponse>("Success", true, result);
                else
                    return new WebApiResponse<BillingAddressResponse>("Error", false);
            }
            return new WebApiResponse<BillingAddressResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _bs.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<BillingAddressResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<BillingAddressResponse>>(await _bs.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<BillingAddressResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<BillingAddressResponse>>("Error", false);
        }
    }
}