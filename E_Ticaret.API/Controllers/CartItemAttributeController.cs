using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.CartItemAttribute;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.CartItemAttributeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("CartItemAttribute")]
    [ApiController]
    public class CartItemAttributeController : BaseApiController<CartItemAttributeController>
    {
        private readonly ICartItemAttributeService _cas;
        private readonly IMapper _mapper;
        public CartItemAttributeController(ICartItemAttributeService cas, IMapper mapper)
        {
            _cas = cas;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<WebApiResponse<List<CartItemAttributeResponse>>> GetAll()
        {
            var result = _mapper.Map<List<CartItemAttributeResponse>>(await _cas.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<CartItemAttributeResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<CartItemAttributeResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<CartItemAttributeResponse>> GetById(int id)
        {
            var result = _mapper.Map<CartItemAttributeResponse>(await _cas.GetById(id));
            if (result != null)
                return new WebApiResponse<CartItemAttributeResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<CartItemAttributeResponse>("Bir şeyler ters gitti", false);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CartItemAttributeResponse>>> Put(int id, CartItemAttributeRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _cas.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _cas.Update(entity, id);
                if (updateResult != null)
                {
                    CartItemAttributeResponse rm = _mapper.Map<CartItemAttributeResponse>(updateResult);
                    return new WebApiResponse<CartItemAttributeResponse>("Success", true, rm);
                }
                return new WebApiResponse<CartItemAttributeResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CartItemAttributeResponse>>> Post(CartItemAttributeRequest request)
        {
            var entity = _mapper.Map<CartItemAttribute>(request);

            var insertResult = await _cas.Add(entity);
            if (insertResult != null)
            {
                CartItemAttributeResponse rm = _mapper.Map<CartItemAttributeResponse>(insertResult);
                return new WebApiResponse<CartItemAttributeResponse>("Success", true, rm);
            }
            return new WebApiResponse<CartItemAttributeResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CartItemAttributeResponse>>> Delete(int id)
        {
            var result = _mapper.Map<CartItemAttributeResponse>(await _cas.GetById(id));
            if (result != null)
            {
                var deleteResult = await _cas.Delete(_mapper.Map<CartItemAttribute>(result));
                if (deleteResult)
                    return new WebApiResponse<CartItemAttributeResponse>("Success", true, result);
                else
                    return new WebApiResponse<CartItemAttributeResponse>("Error", false);
            }
            return new WebApiResponse<CartItemAttributeResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _cas.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<CartItemAttributeResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<CartItemAttributeResponse>>(await _cas.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<CartItemAttributeResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<CartItemAttributeResponse>>("Error", false);
        }
    }
}
