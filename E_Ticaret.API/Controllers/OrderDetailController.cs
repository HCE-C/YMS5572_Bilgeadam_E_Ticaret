using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.OrderDetail;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.OrderDetailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.API.Controllers
{
    [Route("OrderDetail")]
    [ApiController]
    public class OrderDetailController : BaseApiController<OrderDetailController>
    {
        private readonly IOrderDetailService _ods;
        private readonly IMapper _mapper;
        public OrderDetailController(IOrderDetailService ods, IMapper mapper)
        {
            _ods = ods;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<OrderDetailResponse>>> GetAll()
        {
            var result = _mapper.Map<List<OrderDetailResponse>>(await _ods.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<OrderDetailResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<OrderDetailResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<OrderDetailResponse>>> GetAllByParam(OrderDetailRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<OrderDetailResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<OrderDetailResponse>>(await _ods.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<OrderDetailResponse>>(await _ods.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<OrderDetailResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<OrderDetailResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<OrderDetailResponse>> GetById(int id)
        {
            var result = _mapper.Map<OrderDetailResponse>(await _ods.GetById(id));
            if (result != null)
                return new WebApiResponse<OrderDetailResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<OrderDetailResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<OrderDetailResponse>>> GetByIds(OrderDetailRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<OrderDetail>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<OrderDetailResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _ods.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<OrderDetailResponse>>(entityList);

            return new WebApiResponse<List<OrderDetailResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderDetailResponse>>> Put(int id, OrderDetailRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _ods.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _ods.Update(entity, id);
                if (updateResult != null)
                {
                    OrderDetailResponse rm = _mapper.Map<OrderDetailResponse>(updateResult);
                    return new WebApiResponse<OrderDetailResponse>("Success", true, rm);
                }
                return new WebApiResponse<OrderDetailResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderDetailResponse>>> Post(OrderDetailRequest request)
        {
            var entity = _mapper.Map<OrderDetail>(request);

            var insertResult = await _ods.Add(entity);
            if (insertResult != null)
            {
                OrderDetailResponse rm = _mapper.Map<OrderDetailResponse>(insertResult);
                return new WebApiResponse<OrderDetailResponse>("Success", true, rm);
            }
            return new WebApiResponse<OrderDetailResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderDetailResponse>>> Delete(int id)
        {
            var result = _mapper.Map<OrderDetailResponse>(await _ods.GetById(id));
            if (result != null)
            {
                var deleteResult = await _ods.Delete(_mapper.Map<OrderDetail>(result));
                if (deleteResult)
                    return new WebApiResponse<OrderDetailResponse>("Success", true, result);
                else
                    return new WebApiResponse<OrderDetailResponse>("Error", false);
            }
            return new WebApiResponse<OrderDetailResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _ods.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<OrderDetailResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<OrderDetailResponse>>(await _ods.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<OrderDetailResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<OrderDetailResponse>>("Error", false);
        }
    }
}