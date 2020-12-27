using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Location;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.LocationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.API.Controllers
{
    [Route("Location")]
    [ApiController]
    public class LocationController : BaseApiController<LocationController>
    {
        private readonly ILocationService _ls;
        private readonly IMapper _mapper;
        public LocationController(ILocationService ls, IMapper mapper)
        {
            _ls = ls;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<LocationResponse>>> GetAll()
        {
            var result = _mapper.Map<List<LocationResponse>>(await _ls.GetDefault(x=>x.Id != 0,x=>x.Country,x=>x.Region).ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<LocationResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<LocationResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("Special")]
        public async Task<WebApiResponse<List<LocationResponse>>> GetAllByParam(LocationRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId <= 0)
                return new WebApiResponse<List<LocationResponse>>("Lütfen gerekli parametreleri giriniz", false);

            var result =
                request.Sort.Contains('-')
                ? _mapper.Map<List<LocationResponse>>(await _ls.Table.OrderBy(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync())
                : _mapper.Map<List<LocationResponse>>(await _ls.Table.OrderByDescending(x => x.Id).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToListAsync());

            if (result.Count > 0)
                return new WebApiResponse<List<LocationResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<LocationResponse>>("Bir şeyler ters gitti", false);

        }
        [HttpGet("{id}")]
        public async Task<WebApiResponse<LocationResponse>> GetById(int id)
        {
            var result = _mapper.Map<LocationResponse>(await _ls.GetById(id));
            if (result != null)
                return new WebApiResponse<LocationResponse>("Sonuç başarılı", true, result);
            return new WebApiResponse<LocationResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<LocationResponse>>> GetByIds(LocationRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            var entityList = new List<Location>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<LocationResponse>>("Lütfen geçerli bir id giriniz", false);
                var result = await _ls.GetById(intid);
                entityList.Add(result);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<LocationResponse>>(entityList);

            return new WebApiResponse<List<LocationResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<WebApiResponse<LocationResponse>> Put(int id, LocationRequest request)
        {
            if (id != request.Id)
                return new WebApiResponse<LocationResponse>("Error", false);
            try
            {
                var entity = await _ls.GetById(id);
                if (entity == null)
                    return new WebApiResponse<LocationResponse>("Error", false);
                _mapper.Map(request, entity);

                var updateResult = await _ls.Update(entity, id);
                if (updateResult != null)
                {
                    LocationResponse rm = _mapper.Map<LocationResponse>(updateResult);
                    return new WebApiResponse<LocationResponse>("Success", true, rm);
                }
                return new WebApiResponse<LocationResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<WebApiResponse<LocationResponse>> Post(LocationRequest request)
        {
            var entity = _mapper.Map<Location>(request);

            var insertResult = await _ls.Add(entity);
            if (insertResult != null)
            {
                LocationResponse rm = _mapper.Map<LocationResponse>(insertResult);
                return new WebApiResponse<LocationResponse>("Success", true, rm);
            }
            return new WebApiResponse<LocationResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<WebApiResponse<LocationResponse>> Delete(int id)
        {
            var result = _mapper.Map<Location>(await _ls.GetById(id));
            if (result != null)
            {
                var deleteResult = await _ls.Delete(result);
                if (deleteResult)
                    return new WebApiResponse<LocationResponse>("Success", true, _mapper.Map<LocationResponse>(result));
                else
                    return new WebApiResponse<LocationResponse>("Error", false);
            }
            return new WebApiResponse<LocationResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<WebApiResponse<bool>> Activate(int id)
        {
            bool result = await _ls.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [AllowAnonymous]
        [HttpGet("getactive")]
        public async Task<WebApiResponse<List<LocationResponse>>> GetActive()
        {
            var result = _mapper.Map<List<LocationResponse>>(await _ls.GetActive().ToListAsync());
            if (result.Count > 0)
                return new WebApiResponse<List<LocationResponse>>("Success", true, result);
            return new WebApiResponse<List<LocationResponse>>("Error", false);
        }

        //[AllowAnonymous]
        //[HttpGet("Join")]
        //public async Task<WebApiResponse<List<LocationResponse>>> GetJoinLocation()
        //{
        //    var result = _mapper.Map<List<LocationResponse>>(await _ls.GetByDefault(x=>x.Status == Core.Entity.Enums.Status.Active, x=>x.Region,x=>x.Country));
        //    if (result.Count > 0)
        //        return new WebApiResponse<List<LocationResponse>>("Success", true, result);
        //    return new WebApiResponse<List<LocationResponse>>("Error", false);
        //}
    }
}
