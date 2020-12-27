using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Currency;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.CurrencyService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Currency")]
    [ApiController]
    public class CurrencyController : BaseApiController<CurrencyController>
    {
        private readonly ICurrencyService _cs;
        private readonly IMapper _mapper;
        public CurrencyController(ICurrencyService cs, IMapper mapper)
        {
            _cs = cs;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<CurrencyResponse>>> GetAll()
        {
            var result = _mapper.Map<List<CurrencyResponse>>(await _cs.Table.ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<CurrencyResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<CurrencyResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<CurrencyResponse>> GetById(int id)
        {
            var result = _mapper.Map<CurrencyResponse>(await _cs.GetById(id));
            if (result != null)
                return new WebApiResponse<CurrencyResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<CurrencyResponse>("Bir şeyler ters gitti", false);

        }
       
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CurrencyResponse>>> PutMember(int id, CurrencyRequest request)
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
                    CurrencyResponse rm = _mapper.Map<CurrencyResponse>(updateResult);
                    return new WebApiResponse<CurrencyResponse>("Success", true, rm);
                }
                return new WebApiResponse<CurrencyResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CurrencyResponse>>> PostUser(CurrencyRequest request)
        {
            var entity = _mapper.Map<Currency>(request);

            var insertResult = await _cs.Add(entity);
            if (insertResult != null)
            {
                CurrencyResponse rm = _mapper.Map<CurrencyResponse>(insertResult);
                return new WebApiResponse<CurrencyResponse>("Success", true, rm);
            }
            return new WebApiResponse<CurrencyResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CurrencyResponse>>> DeleteUser(int id)
        {
            var result = _mapper.Map<CurrencyResponse>(await _cs.GetById(id));
            if (result != null)
            {
                var deleteResult = await _cs.Delete(_mapper.Map<Currency>(result));
                if (deleteResult)
                    return new WebApiResponse<CurrencyResponse>("Success", true, result);
                else
                    return new WebApiResponse<CurrencyResponse>("Error", false);
            }
            return new WebApiResponse<CurrencyResponse>("Error", false);
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
        public async Task<ActionResult<WebApiResponse<List<CurrencyResponse>>>> GetActive()
        {
            var result = _mapper.Map<List<CurrencyResponse>>(await _cs.GetActive().ToListAsync());
            if (result.Count > 0)
            {
                return new WebApiResponse<List<CurrencyResponse>>("Success", true, result);
            }
            return new WebApiResponse<List<CurrencyResponse>>("Error", false);
        }
    }
}