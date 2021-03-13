using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ParkUp.CC.Identity.Models;
using ParkUp.Domain.Interfaces;
using ParkUp.Services.Api.Configuration;

namespace ParkUp.Services.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    [Produces("application/json")]
    public class AccountController : ApiController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AccountController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings,
            IUser user) : base(user)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Modelo de entrada inválido."
                });
            }

            var user = new IdentityUser
            {
                UserName = userRegistration.Name,
                Email = userRegistration.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return BadRequest(error.Code + " " + error.Description);
                }

                return BadRequest(userRegistration);
            }

            await _signInManager.SignInAsync(user, false);

            //var token = await GenerateJwt(userRegistration.Email);
            //return Ok(token);
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Modelo de entrada inválido."
                });
            }

            var userName = await _userManager.FindByEmailAsync(userLogin.Email);

            if (userName is null)
            {
                return StatusCode(403);
            }

            var result = await _signInManager.PasswordSignInAsync(userName, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                //var token = await GenerateJwt(userLogin.Email);
                //return Ok(token);
                return Ok();
            }

            return StatusCode(403);
        }

    }
}
