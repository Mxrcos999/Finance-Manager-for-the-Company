using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.Interfaces;
using FinanceManager.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinanceManager.Api.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IIdentityService _identityService;
        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("api/users/register/pessoa-fisica")]
        public async Task<IActionResult> RegisterUser(UserPessoaFisicaCadastroRequest model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _identityService.CadastrarUsuarioPessoaFisica(model);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        } 
        
        [HttpPost]
        [Route("api/users/register/pessoa-juridica")]
        public async Task<IActionResult> RegisterUserPessoaJuridica(UserPessoaJuridicaCadastroRequest model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _identityService.CadastrarUsuarioPessoaJuridica(model);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("api/users/confirmEmail")]
        public async Task<IActionResult> ConfirmEmailUser(string token,string idUser)
        {

            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _identityService.ConfirmarEmail(token, idUser);
           
            return Ok(result);
        }

        [HttpPost]
        [Route("api/users/login")]
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

