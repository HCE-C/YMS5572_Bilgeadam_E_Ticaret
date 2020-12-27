using AutoMapper;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Member;
using E_Ticaret.Core.Entity.Enums;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.MemberService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("Member")]
    [ApiController]
    public class MemberController : BaseApiController<MemberController>
    {
        private readonly IMemberService _ms;
        private readonly IMapper _mapper;
        public MemberController(IMemberService ms, IMapper mapper)
        {
            _ms = ms;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<WebApiResponse<List<MemberResponse>>> GetAll()
        {
            var memberResult = _mapper.Map<List<MemberResponse>>(await _ms.Table.ToListAsync());
            if (memberResult.Count > 0)
                return new WebApiResponse<List<MemberResponse>>("Sonuç başarılı", true, memberResult);
            return new WebApiResponse<List<MemberResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("Special")]
        public async Task<WebApiResponse<List<MemberResponse>>> GetAllByParam([FromQuery]MemberRequest request)
        {
            if (request.Sort == null || request.Limit <= 0 || request.SinceId == 0)
            {
                var responses = _mapper.Map<List<MemberResponse>>(_ms.GetDefault(x => x.Id > 0,x=>x.Country,x=>x.Location).ToList());
                return new WebApiResponse<List<MemberResponse>>("Sonuç başarılı", true, responses);
            }

            List<MemberResponse> result = new List<MemberResponse>();
            if (request.Sort.Contains('-'))
            {
                var memberResult = _mapper.Map<List<MemberResponse>>(_ms.GetDefault(x => x.Id > 0, x => x.Location, x => x.Country));
                result = memberResult.OrderBy(x => x.Firstname).SkipWhile(x => x.Id <= request.SinceId).Skip(request.Page).Take(request.Limit).ToList();
            }
            else
            {
                var memberResult = _mapper.Map<List<MemberResponse>>(_ms.GetDefault(x => x.Id > 0, x => x.Location, x => x.Country));
                result = memberResult.OrderByDescending(x => x.Firstname).SkipWhile(x => x.Id <= request.SinceId).Take(request.Limit).ToList();
            }

            if (result.Count > 0)
                return new WebApiResponse<List<MemberResponse>>("Sonuç başarılı", true, result);
            return new WebApiResponse<List<MemberResponse>>("Bir şeyler ters gitti", false);

        }

        [HttpGet("{id}")]
        public async Task<WebApiResponse<MemberResponse>> GetById(int id)
        {
            var memberResult = _mapper.Map<MemberResponse>(await _ms.GetById(id));
            if (memberResult != null)
                return new WebApiResponse<MemberResponse>("Sonuç başarılı", true, memberResult);
            return new WebApiResponse<MemberResponse>("Bir şeyler ters gitti", false);

        }
        [HttpGet("List")]
        public async Task<WebApiResponse<List<MemberResponse>>> GetByIds(MemberRequest request)
        {
            int intid;
            var ids = request.Ids.Split(',');
            List<Member> entityList = new List<Member>();
            foreach (var item in ids)
            {
                if (!int.TryParse(item, out intid))
                    return new WebApiResponse<List<MemberResponse>>("Lütfen geçerli bir id giriniz", false);
                var memberResult = await _ms.GetById(intid);
                entityList.Add(memberResult);
            }
            if (request.Sort.Contains('-'))
                entityList.OrderBy(x => x.Id);
            else if (request.Sort != null && !request.Sort.Contains('-'))
                entityList.OrderByDescending(x => x.Id);
            var rm = _mapper.Map<List<MemberResponse>>(entityList);

            return new WebApiResponse<List<MemberResponse>>("Üye Liste sorgusu başarılı", true, rm);
        }
        [HttpPut("{id}")]
        public async Task<WebApiResponse<MemberResponse>> PutMember(int id, MemberRequest request)
        {
            request.DeviceType = "Computer";
            request.MemberStatus = Model.MemberStatus.Active;
            request.MemberGroupId = 1;
            request.ReferredMemberId = 1;
            if (id != request.Id)
                return new WebApiResponse<MemberResponse>("Bad Request", false);
            try
            {
                var entity = await _ms.GetById(id);
                if (entity == null)
                    return new WebApiResponse<MemberResponse>("Not Found", false); ;
                _mapper.Map(request, entity);

                var updateResult = await _ms.Update(entity, id);
                if (updateResult != null)
                {
                    MemberResponse rm = _mapper.Map<MemberResponse>(updateResult);
                    return new WebApiResponse<MemberResponse>("Success", true, rm);
                }
                return new WebApiResponse<MemberResponse>("Error", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<WebApiResponse<MemberResponse>> PostMember(MemberRequest request)
        {
            Member entity = _mapper.Map<Member>(request);
            entity.DeviceType = "Computer";
            entity.MemberStatus = Model.MemberStatus.Queue;
            entity.Title = "User";
            entity.MemberGroupId = 1;
            entity.ReferredMemberId = 1;
            var insertResult = await _ms.Add(entity);
            if (insertResult != null)
            {
                MemberResponse rm = _mapper.Map<MemberResponse>(insertResult);
                return new WebApiResponse<MemberResponse>("Success", true, rm);
            }
            return new WebApiResponse<MemberResponse>("Error", false);
        }

        [HttpDelete("{id}")]
        public async Task<WebApiResponse<MemberResponse>> DeleteMember(int id)
        {
            var member = await _ms.GetById(id);
            if (member != null)
            {
                var deleteResult = await _ms.Delete(_mapper.Map<Member>(member));
                if (deleteResult)
                    return new WebApiResponse<MemberResponse>("Success", true);
                else
                    return new WebApiResponse<MemberResponse>("Error", false);
            }
            return new WebApiResponse<MemberResponse>("Error", false);
        }

        [HttpGet("activate/{id}")]
        public async Task<WebApiResponse<bool>> Activate(int id)
        {
            bool result = await _ms.Activate(id);
            if (result)
            {
                return new WebApiResponse<bool>("Success", true, true);
            }
            return new WebApiResponse<bool>("Error", false);
        }

        [HttpGet("getactive")]
        public async Task<WebApiResponse<List<MemberResponse>>> GetActive()
        {
            var MemberResult = _mapper.Map<List<MemberResponse>>(await _ms.GetActive().ToListAsync());
            if (MemberResult.Count > 0)
            {
                return new WebApiResponse<List<MemberResponse>>("Success", true, MemberResult);
            }
            return new WebApiResponse<List<MemberResponse>>("Error", false);
        }
    }
}