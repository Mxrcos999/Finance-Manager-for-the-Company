using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Identity.Interfaces;

public interface IIdentityService
{
    Task<UserLoginResponse> LoginAsync(UserLoginRequest userLogin);
    Task<UserRegisterResponse> CadastrarUsuario(UserCadastroRequest userRegister);
    Task<string> ConfirmarEmail(string email);
}


