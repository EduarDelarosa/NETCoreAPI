using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyecto.Ecommerce.Application.DTO;
using Proyecto.Ecommerce.Application.Interface;
using Proyecto.Ecommerce.Service.WebApi.Helpers;
using Proyecto.Ecommerce.Transversal.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proyecto.Ecommerce.Service.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication usersApplication, AppSettings appSettings)
        {
            _usersApplication = usersApplication;
            _appSettings = appSettings;
        }

        //[AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]UsersDTO authDto)
        {
            var response = _usersApplication.Authenticate(authDto.UserName, authDto.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = buildToken(response);
                    return Ok(response);
                }
                return NotFound(response.Message);
            }

            return BadRequest(response.Message);
        }

        private string buildToken(Response<UsersDTO> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.UserId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
