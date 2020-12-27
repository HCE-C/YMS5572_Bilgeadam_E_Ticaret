using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.OrderItem;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.OrderItemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.API.Controllers
{
    [Route("OrderItem")]
    [ApiController]
    public class OrderItemController : BaseApiController<OrderItemController>
    {
        private readonly IOrderItemService _ois;
        private readonly IMapper _mapper;
        public OrderItemController(IOrderItemService ois, IMapper mapper)
        {
            _ois = ois;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<OrderItemResponse>>> GetAll()
        {
            var memberResult = _mapper.Map<List<OrderItemResponse>>(await _ois.Table.ToListAsync());
            if (memberResult.Count > 0)
                return new WebApiResponse<List<OrderItemResponse>>("Sonuç başarılı", true, memberResult);
            return new WebApiResponse<List<OrderItemResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<OrderItemResponse>>> GetAllByParam(OrderItemRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<OrderItemResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<OrderItemResponse>>(await _ois.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<OrderItemResponse>>(await _ois.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<OrderItemResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<OrderItemResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<OrderItemResponse>> GetById(int id)
        {
            var result = _mapper.Map<OrderItemResponse>(await _ois.GetById(id));
            if (result != null)
                return new WebApiResponse<OrderItemResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<OrderItemResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<OrderItemResponse>>> GetByIds(OrderItemRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<OrderItem>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<OrderItemResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _ois.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<OrderItemResponse>>(entityList);

            return new WebApiResponse<List<OrderItemResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> PutBrand(int id, OrderItemRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _ois.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _ois.Update(entity, id);
                if (updateResult != null)
                {
                    OrderItemResponse rm = _mapper.Map<OrderItemResponse>(updateResult);
                    return new WebApiResponse<OrderItemResponse>("Success", true, rm);
                }
                return new WebApiResponse<OrderItemResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> Post(OrderItemRequest request)
        {
            var entity = _mapper.Map<OrderItem>(request);

            var insertResult = await _ois.Add(entity);
            if (insertResult != null)
            {
                OrderItemResponse rm = _mapper.Map<OrderItemResponse>(insertResult);
                return new WebApiResponse<OrderItemResponse>("Success", true, rm);
            }
            return new WebApiResponse<OrderItemResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> Delete(int id)
        {
            var entity = _mapper.Map<OrderItemResponse>(await _ois.GetById(id));
            if (entity != null)
            {
                var deleteResult = await _ois.Delete(_mapper.Map<OrderItem>(entity));
                if (deleteResult)
                    return new WebApiResponse<OrderItemResponse>("Success", true, entity);
                else
                    return new WebApiResponse<OrderItemResponse>("Error", false);
            }
            return new WebApiResponse<OrderItemResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _ois.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<OrderItemResponse>>(await _ois.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<OrderItemResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<OrderItemResponse>>("Error", false);
        }
    }
}
