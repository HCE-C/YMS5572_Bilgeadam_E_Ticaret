using AutoMapper;
using E_Ticaret.Common.Client.Services;
using E_Ticaret.Common.DTOs.Member;
using E_Ticaret.Service.Service.MemberService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace E_Ticaret.API.Infrastructure.Models.Base
{
    public class ApiWorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IMemberService _ms;
        private readonly IMapper _mapper;

        public ApiWorkContext(IHttpContextAccessor accessor, IMemberService ms, IMapper mapper)
        {
            _accessor = accessor;
            _ms = ms;
            _mapper = mapper;
        }
        public MemberResponse CurrentUser
        {
            get
            {
                var authResult = _accessor.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme).Result;
                if (!authResult.Succeeded)
                    return null;
                var email = authResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email).Value;
                var userId = authResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                MemberResponse user = _mapper.Map<MemberResponse>(_ms.GetById(Convert.ToInt32(userId)).Result);
                return user;
            }

            set
            {
                CurrentUser = value;
            }
        }
    }
}
