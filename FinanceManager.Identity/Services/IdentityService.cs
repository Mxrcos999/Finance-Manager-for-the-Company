using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;
using FinanceManager.Identity.Configurations;
using FinanceManager.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinanceManager.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtOptions _jwtOptions;
    private readonly LinkGenerator _linkGenerator;

    public IdentityService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOptions<JwtOptions> jwtOptions, LinkGenerator linkGenerator)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
        _linkGenerator = linkGenerator;
    }

    public async Task<UserLoginResponse> LoginAsync(UserLoginRequest userLogin)
    {
        SignInResult signInResult = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, isPersistent: false, lockoutOnFailure: true);
        if (signInResult.Succeeded)
            return await GerarCredenciais(userLogin.Email);


        UserLoginResponse userLoginResponse = new UserLoginResponse(signInResult.Succeeded);
        if (!signInResult.Succeeded)
        {
            if (signInResult.IsLockedOut)
            {
                userLoginResponse.AddError("This account is locked.");
            }
            else if (signInResult.IsNotAllowed)
            {
                userLoginResponse.AddError("This account doesn't have permission to sign-in.");
            }
            else if (signInResult.RequiresTwoFactor)
            {
                userLoginResponse.AddError("Confirm your sign-in.");
            }
            else
            {
                userLoginResponse.AddError("Username or password is incorrect.");
            }
        }

        return userLoginResponse;
    }

    public async Task<bool> CadastrarUsuario(UserCadastroRequest userRegister)
    {
        var user = await ConverteObjetos(userRegister);

        IdentityResult result = await _userManager.CreateAsync(user, userRegister.Senha);
        if (result.Succeeded)
        {
            return true;
        }

        return false;
    }

    private async Task<PessoaFisica> CriaPessoaFisica(UserCadastroRequest userRegister)
    {
        var empregadores = new List<Empregador>();
        var enderecos = new List<Endereco>();
        var telefones = new List<Telefone>();

        foreach (var enderecoAtual in userRegister.PessoaFisica.Enderecos)
        {
            enderecos.Add(new Endereco(enderecoAtual.Logradouro, enderecoAtual.Numero, enderecoAtual.Cep, enderecoAtual.TipoLogradouro));
        }

        foreach (var telefoneAtual in userRegister.PessoaFisica.Telefones)
        {
            telefones.Add(new Telefone(telefoneAtual.Ddd, telefoneAtual.Ddi, telefoneAtual.Numero, telefoneAtual.Principal, telefoneAtual.Ramal, telefoneAtual.TipoTelefone));
        }
        foreach (var empregadorAtual in userRegister.PessoaFisica.Empregador)
        {
            empregadores.Add(new Empregador
                (empregadorAtual.RazaoSocial,
                empregadorAtual.Cnpj,
                empregadorAtual.EmpresaAtual,
                empregadorAtual.ValorPago));
        }
        var pessoaFisica = new PessoaFisica
              (userRegister.PessoaFisica.Cpf,
              userRegister.PessoaFisica.Nome,
              userRegister.PessoaFisica.DataNascimento,
              empregadores,
              enderecos,
              telefones,
              userRegister.PessoaFisica.Email);

        return pessoaFisica;
    }   
    
    private async Task<PessoaJuridica> CriaPessoaJuridica(UserCadastroRequest userRegister)
    {
        var enderecos = new List<Endereco>();
        var telefones = new List<Telefone>();

        foreach (var enderecoAtual in userRegister.PessoaJuridica.Enderecos)
        {
            enderecos.Add(new Endereco(enderecoAtual.Logradouro, enderecoAtual.Numero, enderecoAtual.Cep, enderecoAtual.TipoLogradouro));
        }

        foreach (var telefoneAtual in userRegister.PessoaJuridica.Telefones)
        {
            telefones.Add(new Telefone(telefoneAtual.Ddd, telefoneAtual.Ddi, telefoneAtual.Numero, telefoneAtual.Principal, telefoneAtual.Ramal, telefoneAtual.TipoTelefone));
        }
        var pessoaJuridica = new PessoaJuridica
                       (userRegister.PessoaJuridica.RazaoSocial,
                       userRegister.PessoaJuridica.Cnpj,
                       userRegister.PessoaJuridica.FaturamentoMensal,
                       userRegister.PessoaJuridica.FaturamentoAnual,
                       enderecos,
                       telefones,
                       userRegister.PessoaJuridica.Email);

        return pessoaJuridica;
    }

    private async Task<ApplicationUser> ConverteObjetos(UserCadastroRequest userRegister)
    {
        var pessoaFisica = new PessoaFisica();
        var pessoaJuridica = new PessoaJuridica();
        var appUser = new ApplicationUser();
        
        if (userRegister.TipoUsuario == UserCadastroRequest.TipoUsuarioEnum.PessoaFisica)
        {
            pessoaFisica = await CriaPessoaFisica(userRegister);
            appUser = new ApplicationUser()
            {
                Email = userRegister.Email,
                PessoaFisica = pessoaFisica,
                UserName = userRegister.Email
            };
        }
        else
        {
            pessoaJuridica = await CriaPessoaJuridica(userRegister);

            appUser = new ApplicationUser()
            {
                Email = userRegister.Email,
                PessoaJuridica = pessoaJuridica,
                UserName = userRegister.Email

            };
        }
        return appUser;
    }

    public async Task<string> ConfirmarEmail(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        user.EmailConfirmed = false;
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        return token;
    }

    private async Task<UserLoginResponse> GerarCredenciais(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var accessTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: true);
        var refreshTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: false);

        var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
        var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

        var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
        var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

        return new UserLoginResponse
        (
            success: true,
            accessToken: accessToken,
            refreshToken: refreshToken
        );
    }

    private string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
    {
        JwtSecurityToken token = new JwtSecurityToken(_jwtOptions.Issuer, _jwtOptions.Audience, claims, DateTime.Now, dataExpiracao, _jwtOptions.SigningCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<IList<Claim>> ObterClaims(ApplicationUser user, bool adicionarClaimsUsuario)
    {
        var claims = new List<Claim>();

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        if (adicionarClaimsUsuario)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);

            foreach (var role in roles)
                claims.Add(new Claim("role", role));
        }

        return claims;
    }

}
