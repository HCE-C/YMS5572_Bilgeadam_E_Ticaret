using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Order;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.OrderService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Order")]
    [ApiController]
    public class OrderController : BaseApiController<OrderController>
    {
        private readonly IOrderService _os;
        private readonly IMapper _mapper;
        public OrderController(IOrderService os, IMapper mapper)
        {
            _os = os;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<OrderResponse>>> GetAll()
        {
            var result = _mapper.Map<List<OrderResponse>>(await _os.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<OrderResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<OrderResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<OrderResponse>>> GetAllByParam(OrderRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<OrderResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<OrderResponse>>(await _os.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<OrderResponse>>(await _os.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<OrderResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<OrderResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<OrderResponse>> GetById(int id)
        {
            var result = _mapper.Map<OrderResponse>(await _os.GetById(id));
            if (result != null)
                return new WebApiResponse<OrderResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<OrderResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<OrderResponse>>> GetByIds(OrderRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<Order>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<OrderResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _os.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<OrderResponse>>(entityList);

            return new WebApiResponse<List<OrderResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> Put(int id, OrderRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _os.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _os.Update(entity, id);
                if (updateResult != null)
                {
                    OrderResponse rm = _mapper.Map<OrderResponse>(updateResult);
                    return new WebApiResponse<OrderResponse>("Success", true, rm);
                }
                return new WebApiResponse<OrderResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> Post(OrderRequest request)
        {
            var entity = _mapper.Map<Order>(request);

            var insertResult = await _os.Add(entity);
            if (insertResult != null)
            {
                OrderResponse rm = _mapper.Map<OrderResponse>(insertResult);
                return new WebApiResponse<OrderResponse>("Success", true, rm);
            }
            return new WebApiResponse<OrderResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> Delete(int id)
        {
            var result = _mapper.Map<OrderResponse>(await _os.GetById(id));
            if (result != null)
            {
                var deleteResult = await _os.Delete(_mapper.Map<Order>(result));
                if (deleteResult)
                    return new WebApiResponse<OrderResponse>("Success", true, result);
                else
                    return new WebApiResponse<OrderResponse>("Error", false);
            }
            return new WebApiResponse<OrderResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _os.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<OrderResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<OrderResponse>>(await _os.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<OrderResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<OrderResponse>>("Error", false);
        }
    }
}