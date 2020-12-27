using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Login;
using E_Ticaret.Common.DTOs.Member;
using E_Ticaret.Service.Service.MemberService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMemberService _ms;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountController(IMemberService ms, IMapper mapper, IConfiguration configuration)
        {
            _ms = ms;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet("Login")]
        public async Task<WebApiResponse<MemberResponse>> Get([FromQuery] LoginRequest request)
        {
            var member = await _ms.GetByDefault(x => x.Email == request.Email && x.Password == request.Password);
            if (member != null)
            {
                MemberResponse rm = _mapper.Map<MemberResponse>(member);
                rm.AccessToken = SetAccessToken(rm);
                return new WebApiResponse<MemberResponse>("Member Sonucu Başarılı", true, rm);
            }
            return new WebApiResponse<MemberResponse>("Member Sonucunu Başarısız", false);
        }
        [HttpGet("refreshtoken")]
        public async Task<WebApiResponse<GetAccessToken>> RefreshToken([FromQuery] RefreshToken request)
        {
            if (string.IsNullOrEmpty(request.Refresh_Token))
                return new WebApiResponse<GetAccessToken>("Geçersiz Token", false);

            var key = request.Refresh_Token.Decrypt();
            var userInfo = key.Split('_');
            if (userInfo.Length < 3 || userInfo[0] != request.User_Name)
                return new WebApiResponse<GetAccessToken>("Geçersiz Token", false);

            var result = await _ms.GetByDefault(x => x.Email == userInfo[0] && x.Password == userInfo[1]);
            if (request != null)
            {
                MemberResponse rm = _mapper.Map<MemberResponse>(result);
                rm.AccessToken = SetAccessToken(rm);
                return new WebApiResponse<GetAccessToken>("Sorgu Sonucu Başarılı", true, rm.AccessToken);
            }
            return new WebApiResponse<GetAccessToken>("Kullanıcı Bulunamadı", false);
        }

        private GetAccessToken SetAccessToken(MemberResponse rm)
        {
            var claims = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Email, rm.Email),
              new Claim(JwtRegisteredClaimNames.Jti, rm.Id.ToString())
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:key"]));
            var singingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Tokens:Expires"]));
            var ticks = expires.ToUnixTime();

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Tokens:Issuer"],
                audience: _configuration["Tokens:Audience"],
                claims: claims,
                expires : expires,
                signingCredentials: singingCredentials
                );

            return new GetAccessToken
            {
                TokenType = "BilgeAdamAccessToken",
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Expires = ticks,
                RefreshToken = $"{rm.Email}_{rm.Password}_{ticks}".Encrypt()
            };
        }
    }
}
