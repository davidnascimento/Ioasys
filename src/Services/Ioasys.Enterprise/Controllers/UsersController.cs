using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ioasys.Domain.Interfaces.Repository;
using Ioasys.Enterprise.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Ioasys.Enterprise.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IAuthRepository _authRepository;

        public UsersController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(true);
        }

        [AllowAnonymous]
        [HttpPost("auth/sign_in")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var isValid = _authRepository.ValidatePassword(userDto.email, CalculateMD5Hash(userDto.password));

            if (!isValid)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ioasystesteteste");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDto.email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            Response.Headers.Add("access-token", tokenString);
            Response.Headers.Add("client", "ioasystesteteste");
            Response.Headers.Add("uid", userDto.email);

            var user = _authRepository.GetUserByEmail(userDto.email);

            if (user.Investor != null)
                user.Investor.Users = null;

            if (user.Enterprise != null)
                user.Enterprise.Users = null;

            return Ok(new
            {
                investor = user.Investor
                ,
                enterprise = user.Enterprise
                ,
                success = true
            });
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}