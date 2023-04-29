using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using System.Threading.Tasks;

namespace FinanceManager.Identity.Interfaces;

public interface IIdentityService
{
    Task<UserLoginResponse> LoginAsync(UserLoginRequest userLogin);
    Task<bool> CadastrarUsuario(UserCadastroRequest userRegister);
    Task<string> ConfirmarEmail(string email);
    Task EnviaEmail(string link);
}


