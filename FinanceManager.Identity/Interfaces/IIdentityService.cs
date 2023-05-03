using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Identity.Interfaces;

public interface IIdentityService
{
    Task<UserLoginResponse> LoginAsync(UserLoginRequest userLogin);
    Task<UserRegisterResponse> CadastrarUsuarioPessoaFisica(UserPessoaFisicaCadastroRequest userRegister);
    Task<UserRegisterResponse> CadastrarUsuarioPessoaJuridica(UserPessoaJuridicaCadastroRequest userRegister);
    Task<string> ConfirmarEmail(string email);
}


