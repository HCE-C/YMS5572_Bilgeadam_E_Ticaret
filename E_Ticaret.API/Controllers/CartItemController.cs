using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.CartItem;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.CartItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [AllowAnonymous]
    [Route("CartItem")]
    [ApiController]
    public class CartItemController : BaseApiController<CartItemController>
    {
        private readonly ICartItemService _cis;
        private readonly IMapper _mapper;
        public CartItemController(ICartItemService cs, IMapper mapper)
        {
            _cis = cs;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<WebApiResponse<List<CartItemResponse>>> GetById(int id)
        {
            var result = _mapper.Map<List<CartItemResponse>>(await _cis.GetDefault(x=>x.CartId == id,x=>x.Product).ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<CartItemResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<CartItemResponse>>("Bir şeyler ters gitti", false);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> Put(int id, CartItemRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _cis.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _cis.Update(entity, id);
                if (updateResult != null)
                {
                    CartItemResponse rm = _mapper.Map<CartItemResponse>(updateResult);
                    return new WebApiResponse<CartItemResponse>("Success", true, rm);
                }
                return new WebApiResponse<CartItemResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> Post(CartItemRequest request)
        {
            var entity = _mapper.Map<CartItem>(request);
            entity.Status = Core.Entity.Enums.Status.Active;
            var insertResult = await _cis.Add(entity);
            if (insertResult != null)
            {
                CartItemResponse rm = _mapper.Map<CartItemResponse>(insertResult);
                return new WebApiResponse<CartItemResponse>("Success", true, rm);
            }
            return new WebApiResponse<CartItemResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> Delete(int id)
        {
            var result = _mapper.Map<CartItemResponse>(await _cis.GetById(id));
            if (result != null)
            {
                var deleteResult = await _cis.Delete(_mapper.Map<CartItem>(result));
                if (deleteResult)
                    return new WebApiResponse<CartItemResponse>("Success", true, result);
                else
                    return new WebApiResponse<CartItemResponse>("Error", false);
            }
            return new WebApiResponse<CartItemResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _cis.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<CartItemResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<CartItemResponse>>(await _cis.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<CartItemResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<CartItemResponse>>("Error", false);
        }
    }
}