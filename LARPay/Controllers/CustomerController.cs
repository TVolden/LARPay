using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dk.lashout.LARPay.Core.Facades;
using dk.lashout.LARPay.Core.Providers;
using dk.lashout.LARPay.Web.Models;
using dk.lashout.LARPay.Web.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace dk.lashout.LARPay.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomers _customers;
        private readonly IConfiguration _configuration;

        public CustomerController(ICustomers customers, IConfiguration configuration)
        {
            _customers = customers;
            _configuration = configuration;
        }

        public ActionResult Create()
        {
            var returnValue = new CredentialsViewModel();
            returnValue.Name = "Full name";
            returnValue.Identity = "Login name";
            returnValue.Pincode = 0000;
            return Json(returnValue);
        }

        [HttpPost]
        public ActionResult Create(CredentialsViewModel credentials)
        {
            _customers.Create(credentials.Identity, credentials.Name, credentials.Pincode);
            return Created($"/credentials/{credentials.Identity}", credentials);
        }

        public ActionResult Login()
        {
            var returnValue = new AuthenticateViewModel();
            returnValue.Identity = "Login name";
            returnValue.Pincode = 0000;
            return Json(returnValue);
        }

        [HttpPost]
        public ActionResult Login(AuthenticateViewModel model)
        {
            if (_customers.Login(model.Identity, model.Pincode))
            {
                return Ok(CreateToken(model.Identity));
            }
            return new UnauthorizedWithChallengeResult("Bearer realm=\"jwt\"");
        }

        [Authorize]
        public ActionResult Renew()
        {
            return Ok(CreateToken(""));
        }

        private string CreateToken(string Username)
        {
            var symmetricKey = Encoding.UTF8.GetBytes(_configuration["jwt:SecretKey"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var now = TimeProvider.Current.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Username)
                }),
                Issuer = _configuration["jwt:Issuer"],
                Audience = _configuration["jwt:Audience"],
                Expires = now.AddMinutes(Convert.ToInt32(20)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}