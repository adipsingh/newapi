﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AttachMore.NextGen.Service.APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult token()
        {
            var claims = new[] { new Claim(ClaimTypes.Name, "username") };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jksjskljfksjflkjsdklfjsdkjfsljkfjsldkfsjldfkdsjklskfjlsdkdslkl"));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: "AttachMoreIssuer",
                audience: "AttachMoreAudience",
                expires: DateTime.Now.AddMinutes(1),
                claims: claims,
                signingCredentials: signInCred
                  );
            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(tokenstring);
        }
    }
}