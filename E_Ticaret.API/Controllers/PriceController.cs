using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Price;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.PriceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.API.Controllers
{
    [Route("Price")]
    [ApiController]
    public class PriceController : BaseApiController<PriceController>
    {
        private readonly IPriceService _prs;
        private readonly IMapper _mapper;
        public PriceController(IPriceService ps, IMapper mapper)
        {
            _prs = ps;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<PriceResponse>>> GetAll()
        {
            var result = _mapper.Map<List<PriceResponse>>(await _prs.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<PriceResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<PriceResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<PriceResponse>> GetById(int id)
        {
            var result = _mapper.Map<PriceResponse>(await _prs.GetById(id));
            if (result != null)
                return new WebApiResponse<PriceResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<PriceResponse>("Bir şeyler ters gitti", false);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PriceResponse>>> PutMember(int id, PriceRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            try
            {
                var entity = await _prs.GetById(id);
                if (entity == null)
                    return NotFound();
                _mapper.Map(request, entity);

                var updateResult = await _prs.Update(entity, id);
                if (updateResult != null)
                {
                    PriceResponse rm = _mapper.Map<PriceResponse>(updateResult);
                    return new WebApiResponse<PriceResponse>("Success", true, rm);
                }
                return new WebApiResponse<PriceResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PriceResponse>>> PostUser(PriceRequest request)
        {
            var entity = _mapper.Map<Price>(request);

            var insertResult = await _prs.Add(entity);
            if (insertResult != null)
            {
                PriceResponse rm = _mapper.Map<PriceResponse>(insertResult);
                return new WebApiResponse<PriceResponse>("Success", true, rm);
            }
            return new WebApiResponse<PriceResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<PriceResponse>>> DeleteUser(int id)
        {
            var result = _mapper.Map<PriceResponse>(await _prs.GetById(id));
            if (result != null)
            {
                var deleteResult = await _prs.Delete(_mapper.Map<Price>(result));
                if (deleteResult)
                    return new WebApiResponse<PriceResponse>("Success", true, result);
                else
                    return new WebApiResponse<PriceResponse>("Error", false);
            }
            return new WebApiResponse<PriceResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(int id)
        {
            bool result = await _prs.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<PriceResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<PriceResponse>>(await _prs.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<PriceResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<PriceResponse>>("Error", false);
        }
    }
}