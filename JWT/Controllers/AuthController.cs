using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        // POST api/values
        [HttpPost("token")]

        public ActionResult GetToken()
        {

            var claims = new[]
   {
        new Claim(JwtRegisteredClaimNames.Sub, "sub"),
        new Claim(JwtRegisteredClaimNames.Jti, "jti"),
    };

            string securityKey = "super_secrete_222super_secrete_222super_secrete_222super_secrete_222super_secrete_222super_secrete_222super_secrete_222super_secrete_222";

            var symmetricSecKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            var singInCredentials = new SigningCredentials(symmetricSecKey, SecurityAlgorithms.HmacSha256Signature);
            var encryptingCredentials = new EncryptingCredentials(symmetricSecKey, JwtConstants.DirectKeyUseAlg, SecurityAlgorithms.Aes256CbcHmacSha512);
            var token = new JwtSecurityTokenHandler().CreateJwtSecurityToken(
                "kevin.broit",
               "readers",

              new ClaimsIdentity(claims),
               null,
                 DateTime.Now.AddHours(1),
                null,
     singInCredentials,
   encryptingCredentials);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }


        [HttpPost("admintoken")]

        public ActionResult GetAdminToken()
        {

            var claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, "sub"),
        new Claim(JwtRegisteredClaimNames.Jti, "jti"),
        new Claim(ClaimTypes.Role, "admin")
    };

            string securityKey = "super_secrete_222super_secrete_222super_secrete_222super_secrete_222super_secrete_222super_secrete_222super_secrete_222super_secrete_222";

            var symmetricSecKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            var singInCredentials = new SigningCredentials(symmetricSecKey, SecurityAlgorithms.HmacSha256Signature);
            var encryptingCredentials = new EncryptingCredentials(symmetricSecKey, JwtConstants.DirectKeyUseAlg, SecurityAlgorithms.Aes256CbcHmacSha512);
            var token = new JwtSecurityTokenHandler().CreateJwtSecurityToken(
                "kevin.broit",
               "readers",

              new ClaimsIdentity(claims),
               null,
                 DateTime.Now.AddHours(1),
                null,
     singInCredentials,
    encryptingCredentials);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }

   

}
