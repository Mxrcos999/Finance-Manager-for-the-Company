using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            if (result)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        [Route("Users/confirmEmail")]
        public async Task<IActionResult> ConfirmEmailUser([FromBody] string email)
        {

            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _identityService.ConfirmarEmail(email);
            var link = Url.Action("ConfirmEmail", "UserController", new { token = result }, Request.Scheme);
            await _emailSender.SendEmailAsync(email, "Confirmação de email", $"clique aqui {link}");
            return Ok(result);
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
            return BadRequest();
        }
    }
}

