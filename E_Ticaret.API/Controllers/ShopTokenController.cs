using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.ShopToken;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.ShopTokenService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Shoptoken")]
    [ApiController]
    public class ShopTokenController : BaseApiController<ShopTokenController>
    {
        private readonly IShopTokenService _sts;
        private readonly IMapper _mapper;
        public ShopTokenController(IShopTokenService sts, IMapper mapper)
        {
            _sts = sts;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<ShopTokenResponse>>> GetAll()
        {
            var result = _mapper.Map<List<ShopTokenResponse>>(await _sts.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<ShopTokenResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ShopTokenResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<ShopTokenResponse>>> GetAllByParam(ShopTokenRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<ShopTokenResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<ShopTokenResponse>>(await _sts.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<ShopTokenResponse>>(await _sts.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<ShopTokenResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<ShopTokenResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<ShopTokenResponse>> GetById(int id)
        {
            var result = _mapper.Map<ShopTokenResponse>(await _sts.GetById(id));
            if (result != null)
                return new WebApiResponse<ShopTokenResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<ShopTokenResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<ShopTokenResponse>>> GetByIds(ShopTokenRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<ShopToken>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<ShopTokenResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _sts.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<ShopTokenResponse>>(entityList);

            return new WebApiResponse<List<ShopTokenResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ShopTokenResponse>>> PutMember(int id, ShopTokenRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _sts.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _sts.Update(entity, id);
                if (updateResult != null)
                {
                    ShopTokenResponse rm = _mapper.Map<ShopTokenResponse>(updateResult);
                    return new WebApiResponse<ShopTokenResponse>("Success", true, rm);
                }
                return new WebApiResponse<ShopTokenResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ShopTokenResponse>>> PostUser(ShopTokenRequest request)
        {
            var entity = _mapper.Map<ShopToken>(request);

            var insertResult = await _sts.Add(entity);
            if (insertResult != null)
            {
                ShopTokenResponse rm = _mapper.Map<ShopTokenResponse>(insertResult);
                return new WebApiResponse<ShopTokenResponse>("Success", true, rm);
            }
            return new WebApiResponse<ShopTokenResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ShopTokenResponse>>> DeleteUser(int id)
        {
            var result = _mapper.Map<ShopTokenResponse>(await _sts.GetById(id));
            if (result != null)
            {
                var deleteResult = await _sts.Delete(_mapper.Map<ShopToken>(result));
                if (deleteResult)
                    return new WebApiResponse<ShopTokenResponse>("Success", true, result);
                else
                    return new WebApiResponse<ShopTokenResponse>("Error", false);
            }
            return new WebApiResponse<ShopTokenResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _sts.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<ShopTokenResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<ShopTokenResponse>>(await _sts.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<ShopTokenResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<ShopTokenResponse>>("Error", false);
        }
    }
}