using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.OrderItemSubscription;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.OrderItemSubscriptionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("OrderItemSubscription")]
    [ApiController]
    public class OrderItemSubscriptionController : BaseApiController<OrderItemSubscriptionController>
    {
        private readonly IOrderItemSubscriptionService _ois;
        private readonly IMapper _mapper;
        public OrderItemSubscriptionController(IOrderItemSubscriptionService ois, IMapper mapper)
        {
            _ois = ois;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<OrderItemSubscriptionResponse>>> GetAll()
        {
            var result = _mapper.Map<List<OrderItemSubscriptionResponse>>(await _ois.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<OrderItemSubscriptionResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<OrderItemSubscriptionResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<OrderItemSubscriptionResponse>> GetById(int id)
        {
            var result = _mapper.Map<OrderItemSubscriptionResponse>(await _ois.GetById(id));
            if (result != null)
                return new WebApiResponse<OrderItemSubscriptionResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<OrderItemSubscriptionResponse>("Bir şeyler ters gitti", false);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemSubscriptionResponse>>> PutMember(int id, OrderItemSubscriptionRequest request)
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
                    OrderItemSubscriptionResponse rm = _mapper.Map<OrderItemSubscriptionResponse>(updateResult);
                    return new WebApiResponse<OrderItemSubscriptionResponse>("Success", true, rm);
                }
                return new WebApiResponse<OrderItemSubscriptionResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderItemSubscriptionResponse>>> PostUser(OrderItemSubscriptionRequest request)
        {
            var entity = _mapper.Map<OrderItemSubscription>(request);

            var insertResult = await _ois.Add(entity);
            if (insertResult != null)
            {
                OrderItemSubscriptionResponse rm = _mapper.Map<OrderItemSubscriptionResponse>(insertResult);
                return new WebApiResponse<OrderItemSubscriptionResponse>("Success", true, rm);
            }
            return new WebApiResponse<OrderItemSubscriptionResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemSubscriptionResponse>>> DeleteUser(int id)
        {
            var result = _mapper.Map<OrderItemSubscriptionResponse>(await _ois.GetById(id));
            if (result != null)
            {
                var deleteResult = await _ois.Delete(_mapper.Map<OrderItemSubscription>(result));
                if (deleteResult)
                    return new WebApiResponse<OrderItemSubscriptionResponse>("Success", true, result);
                else
                    return new WebApiResponse<OrderItemSubscriptionResponse>("Error", false);
            }
            return new WebApiResponse<OrderItemSubscriptionResponse>("Error", false);
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
        public async Task<ActionResult<WebApiResponse<List<OrderItemSubscriptionResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<OrderItemSubscriptionResponse>>(await _ois.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<OrderItemSubscriptionResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<OrderItemSubscriptionResponse>>("Error", false);
        }
    }
}