using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Business.Models;
using WebApplication.Business.Services.Auth;
using WebApplication.Entities.Entities;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        private readonly UserManager<Client> _userManager;
        private readonly SignInManager<Client> _signInManager;
        private readonly IAuthService _seguridadService;

        public AuthController(UserManager<Client> userManager, SignInManager<Client> signInManager, IAuthService seguridadService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._seguridadService = seguridadService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AccountResponseModel>> Login(AccountRequestModel model)
        {
            AccountResponseModel data = null;
            try
            {
                var user = await _userManager.FindByEmailAsync(model.UserName);


                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var roles = await this._userManager.GetRolesAsync(user);
                    var token = await this._seguridadService.GetToken(user, roles);
                    data = new AccountResponseModel { AccessToken = token.AccessToken, Role = roles[0], Autentificado = true, UserId = user.Id };
                }

                else
                {
                    data = new AccountResponseModel { Autentificado = false};
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                data = null;
                return BadRequest(data);
            }
        }

        [HttpGet("logout")]
        public async Task<ActionResult<LogoutModel>> Logout()
        {
            LogoutModel data = new();
            try
            {
                await _signInManager.SignOutAsync();
                data.Message = "Proceso finalizado con exito";
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.Message= ex.Message;
                return BadRequest(data);
            }
        }
    }
}
