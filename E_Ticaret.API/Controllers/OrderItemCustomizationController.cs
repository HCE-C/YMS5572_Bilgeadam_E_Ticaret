using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.OrderItemCustomization;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.OrderItemCustomizationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("OrderItemCustomization")]
    [ApiController]
    public class OrderItemCustomizationController : BaseApiController<OrderItemCustomizationController>
    {
        private readonly IOrderItemCustomizationService _oics;
        private readonly IMapper _mapper;
        public OrderItemCustomizationController(IOrderItemCustomizationService cs, IMapper mapper)
        {
            _oics = cs;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<OrderItemCustomizationResponse>>> GetAll()
        {
            var result = _mapper.Map<List<OrderItemCustomizationResponse>>(await _oics.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<OrderItemCustomizationResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<OrderItemCustomizationResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<OrderItemCustomizationResponse>> GetById(int id)
        {
            var result = _mapper.Map<OrderItemCustomizationResponse>(await _oics.GetById(id));
            if (result != null)
                return new WebApiResponse<OrderItemCustomizationResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<OrderItemCustomizationResponse>("Bir şeyler ters gitti", false);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemCustomizationResponse>>> PutMember(int id, OrderItemCustomizationRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _oics.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _oics.Update(entity, id);
                if (updateResult != null)
                {
                    OrderItemCustomizationResponse rm = _mapper.Map<OrderItemCustomizationResponse>(updateResult);
                    return new WebApiResponse<OrderItemCustomizationResponse>("Success", true, rm);
                }
                return new WebApiResponse<OrderItemCustomizationResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderItemCustomizationResponse>>> PostUser(OrderItemCustomizationRequest request)
        {
            var entity = _mapper.Map<OrderItemCustomization>(request);

            var insertResult = await _oics.Add(entity);
            if (insertResult != null)
            {
                OrderItemCustomizationResponse rm = _mapper.Map<OrderItemCustomizationResponse>(insertResult);
                return new WebApiResponse<OrderItemCustomizationResponse>("Success", true, rm);
            }
            return new WebApiResponse<OrderItemCustomizationResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemCustomizationResponse>>> DeleteUser(int id)
        {
            var result = _mapper.Map<OrderItemCustomizationResponse>(await _oics.GetById(id));
            if (result != null)
            {
                var deleteResult = await _oics.Delete(_mapper.Map<OrderItemCustomization>(result));
                if (deleteResult)
                    return new WebApiResponse<OrderItemCustomizationResponse>("Success", true, result);
                else
                    return new WebApiResponse<OrderItemCustomizationResponse>("Error", false);
            }
            return new WebApiResponse<OrderItemCustomizationResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _oics.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<OrderItemCustomizationResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<OrderItemCustomizationResponse>>(await _oics.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<OrderItemCustomizationResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<OrderItemCustomizationResponse>>("Error", false);
        }
    }
}
