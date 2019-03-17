using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dk.lashout.LARPay.Bank;
using dk.lashout.LARPay.Clock;
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
        private readonly ITimeProvider _timeprovider;
        private readonly CustomerFacade _facade;
        private readonly IConfiguration _configuration;

        public CustomerController(ITimeProvider timeprovider, CustomerFacade facade, IConfiguration configuration)
        {
            _timeprovider = timeprovider ?? throw new ArgumentNullException(nameof(timeprovider));
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ActionResult Register()
        {
            var returnValue = new CustomerViewModel();
            returnValue.Name = "Character name";
            returnValue.Username = "Username";
            returnValue.Pincode = "0000";
            return Json(returnValue);
        }

        [HttpPost]
        public ActionResult Register(CustomerViewModel customer)
        {
            try
            {
                _facade.CreateCustomer(customer.Username, customer.Name, customer.Pincode);
            }
            catch(Exception ex)
            {
            return BadRequest(ex.Message);
            }
            return Created($"/credentials/{customer.Username}", customer);
        }

        public ActionResult Login()
        {
            var returnValue = new AuthenticateViewModel();
            returnValue.Username = "Login name";
            returnValue.Pincode = "0000";
            return Json(returnValue);
        }

        [HttpPost]
        public ActionResult Login(AuthenticateViewModel model)
        {
            if (_facade.Login(model.Username, model.Pincode))
            {
                return Ok(CreateToken(model.Username));
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
            var now = _timeprovider.Now;
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