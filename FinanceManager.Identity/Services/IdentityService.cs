using AutoMapper;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;
using FinanceManager.Identity.Configurations;
using FinanceManager.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinanceManager.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtOptions _jwtOptions;
    private readonly IMapper _mapper;

    public IdentityService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOptions<JwtOptions> jwtOptions, IMapper mapper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
        _mapper = mapper;
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
                userLoginResponse.AddError("Esta conta está bloqueada.");
            }
            else if (signInResult.IsNotAllowed)
            {
                userLoginResponse.AddError("Esta conta não tem permissão para entrar.");
            }
            else if (signInResult.RequiresTwoFactor)
            {
                userLoginResponse.AddError("Confirme seu email.");
            }
            else
            {
                userLoginResponse.AddError("Nome de usuário ou senha estão incorretos.");
            }
        }

        return userLoginResponse;
    }

    public async Task<UserRegisterResponse> CadastrarUsuario(UserCadastroRequest userRegister)
    {
        var user = _mapper.Map<ApplicationUser>(userRegister);

        user.UserName = userRegister.Email;

        IdentityResult result = await _userManager.CreateAsync(user, userRegister.Senha);

        UserRegisterResponse userRegisterResponse = new UserRegisterResponse(result.Succeeded);

        if (!result.Succeeded)
        {
            foreach(var erroAtual in result.Errors)
            {
                switch (erroAtual.Code)
                {
                    case "PasswordRequiresNonAlphanumeric" :
                        userRegisterResponse.AddError("A senha precisa conter pelo menos um caracter especial - ex( * | ! ).");
                        break;   
                    
                    case "PasswordRequiresDigit":
                        userRegisterResponse.AddError("A senha precisa conter pelo menos um número (0 - 9).");
                        break; 
                    
                    case "PasswordRequiresUpper":
                        userRegisterResponse.AddError("A senha precisa conter pelo menos um caracter em maiúsculo.");
                        break;

                    case "DuplicateUserName":
                        userRegisterResponse.AddError("O email informado já foi cadastrado!");
                        break;

                    default:
                        userRegisterResponse.AddError("Erro ao criar usuário.");
                        break;
                }

            }
        }

        return userRegisterResponse;
    }

    public async Task<string> ConfirmarEmail(string email)
    {
        _userManager.RegisterTokenProvider("default", new EmailConfirmationTokenProvider<ApplicationUser>());

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
