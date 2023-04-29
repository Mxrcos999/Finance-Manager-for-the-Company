using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.Interfaces;
using FinanceManager.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace FinanceManager.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailSender _emailSender;
        public UserController(IIdentityService identityService, IEmailSender emailSender)
        {
            _identityService = identityService;
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("Users")]
        public async Task<IActionResult> RegisterUser(UserCadastroRequest model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _identityService.CadastrarUsuario(model);

            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("User/confirmEmail")]
        public async Task<IActionResult> ConfirmEmailUser([FromBody] string email)
        {

            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _identityService.ConfirmarEmail(email);
            var confirmationLink = Url.Action("ConfirmEmailUser", "user", new { userId = "72e3fd1e-0ea7-4592-a330-8a2e15a1f6c5", token = result }, Request.Scheme);

            _emailSender.SendEmail("Confirme seu email", email, confirmationLink);
            return Ok();
        }

        [HttpPost]
        [Route("Users/login")]
        public async Task<IActionResult> Login(UserLoginRequest model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _identityService.LoginAsync(model);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

