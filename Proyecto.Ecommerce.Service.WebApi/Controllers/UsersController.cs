using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Proyecto.Ecommerce.Application.DTO;
using Proyecto.Ecommerce.Application.Interface;
using Proyecto.Ecommerce.Service.WebApi.Helpers;
using Proyecto.Ecommerce.Transversal.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Service.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        //private readonly AppSettings _appSettings;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usersApplication"></param>
        /// <param name="config"></param>
        public UsersController(IUsersApplication usersApplication, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _usersApplication = usersApplication;
            _config = config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authDto"></param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]UsersDTO authDto)
        {
            var response = _usersApplication.Authenticate(authDto.UserName, authDto.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                return NotFound(response.Message);
            }

            return BadRequest(response.Message);
        }

        private string BuildToken(Response<UsersDTO> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Config:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.UserId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config["Config:Issuer"],
                Audience = _config["Config:Audience"],
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
