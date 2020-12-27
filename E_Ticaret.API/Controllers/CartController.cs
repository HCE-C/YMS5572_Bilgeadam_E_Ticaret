using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Cart;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.CartService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Cart")]
    [ApiController]
    [AllowAnonymous]
    public class CartController : BaseApiController<CartController>
    {
        private readonly ICartService _cs;
        private readonly IMapper _mapper;
        public CartController(ICartService cs, IMapper mapper)
        {
            _cs = cs;
            _mapper = mapper;
        }
        
      
        [HttpGet("{id}")]
        public async Task<WebApiResponse<CartResponse>> GetById(int id)
        {
            var result = _mapper.Map<CartResponse>(await _cs.GetByDefault(x=>x.MemberId == id));
            if (result != null)
                return new WebApiResponse<CartResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<CartResponse>("Bir şeyler ters gitti", false);

        }
       
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> Put(int id, CartRequest request)
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
                    CartResponse rm = _mapper.Map<CartResponse>(updateResult);
                    return new WebApiResponse<CartResponse>("Success", true, rm);
                }
                return new WebApiResponse<CartResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> Post(CartRequest request)
        {
            var entity = _mapper.Map<Cart>(request);
            entity.Status = Core.Entity.Enums.Status.Active;
            entity.PromotionId = 3;
            entity.ShopTokenId = 1;
            var insertResult = await _cs.Add(entity);
            if (insertResult != null)
            {
                CartResponse rm = _mapper.Map<CartResponse>(insertResult);
                return new WebApiResponse<CartResponse>("Success", true, rm);
            }
            return new WebApiResponse<CartResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> Delete(int id)
        {
            var result = _mapper.Map<CartResponse>(await _cs.GetById(id));
            if (result != null)
            {
                var deleteResult = await _cs.Delete(_mapper.Map<Cart>(result));
                if (deleteResult)
                    return new WebApiResponse<CartResponse>("Success", true, result);
                else
                    return new WebApiResponse<CartResponse>("Error", false);
            }
            return new WebApiResponse<CartResponse>("Error", false);
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

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<CartResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<CartResponse>>(await _cs.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<CartResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<CartResponse>>("Error", false);
        }

        [HttpGet("anyCart")]
        public async Task<WebApiResponse<CartResponse>> GetCartByMemberId(int memberId)
        {
            var result = await _cs.Any(x=>x.MemberId == memberId);
            if (result)
            {
                var cartResult = _mapper.Map<CartResponse>(await _cs.GetByDefault(x => x.MemberId == memberId));
                return new WebApiResponse<CartResponse>("Success", true, cartResult);
            }
            return new WebApiResponse<CartResponse>("Error", false);
        }
    }
}