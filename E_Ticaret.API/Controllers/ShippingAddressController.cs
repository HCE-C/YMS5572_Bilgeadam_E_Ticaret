using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.ShippingAddress;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.ShippingAddressService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("ShippingAddress")]
    [ApiController]
    public class ShippingAddressController : BaseApiController<ShippingAddressController>
    {
        private readonly IShippingAddressService _ss;
        private readonly IMapper _mapper;
        public ShippingAddressController(IShippingAddressService ss, IMapper mapper)
        {
            _ss = ss;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<ShippingAddressResponse>>> GetAll()
        {
            var result = _mapper.Map<List<ShippingAddressResponse>>(await _ss.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<ShippingAddressResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ShippingAddressResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<ShippingAddressResponse>>> GetAllByParam(ShippingAddressRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<ShippingAddressResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<ShippingAddressResponse>>(await _ss.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<ShippingAddressResponse>>(await _ss.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<ShippingAddressResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ShippingAddressResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<ShippingAddressResponse>> GetById(int id)
        {
            var result = _mapper.Map<ShippingAddressResponse>(await _ss.GetByDefault(x => x.CreatedMemberId == id,x=>x.Country,x=>x.Location));
            if (result != null)
                return new WebApiResponse<ShippingAddressResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<ShippingAddressResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<ShippingAddressResponse>>> GetByIds(ShippingAddressRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<ShippingAddress>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<ShippingAddressResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _ss.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<ShippingAddressResponse>>(entityList);

            return new WebApiResponse<List<ShippingAddressResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponse>>> Put(int id, ShippingAddressRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _ss.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _ss.Update(entity, id);
                if (updateResult != null)
                {
                    ShippingAddressResponse rm = _mapper.Map<ShippingAddressResponse>(updateResult);
                    return new WebApiResponse<ShippingAddressResponse>("Success", true, rm);
                }
                return new WebApiResponse<ShippingAddressResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponse>>> Post(ShippingAddressRequest request)
        {
            var entity = _mapper.Map<ShippingAddress>(request);

            var insertResult = await _ss.Add(entity);
            if (insertResult != null)
            {
                ShippingAddressResponse rm = _mapper.Map<ShippingAddressResponse>(insertResult);
                return new WebApiResponse<ShippingAddressResponse>("Success", true, rm);
            }
            return new WebApiResponse<ShippingAddressResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponse>>> Delete(int id)
        {
            var result = _mapper.Map<ShippingAddressResponse>(await _ss.GetById(id));
            if (result != null)
            {
                var deleteResult = await _ss.Delete(_mapper.Map<ShippingAddress>(result));
                if (deleteResult)
                    return new WebApiResponse<ShippingAddressResponse>("Success", true, result);
                else
                    return new WebApiResponse<ShippingAddressResponse>("Error", false);
            }
            return new WebApiResponse<ShippingAddressResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _ss.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<ShippingAddressResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<ShippingAddressResponse>>(await _ss.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<ShippingAddressResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<ShippingAddressResponse>>("Error", false);
        }
    }
}