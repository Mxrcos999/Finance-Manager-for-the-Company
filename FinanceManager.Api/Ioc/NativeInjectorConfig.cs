using FinanceManager.Api.Extensions;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Services;
using FinanceManager.Domain.Entidades;
using FinanceManager.Identity.Configurations;
using FinanceManager.Identity.Interfaces;
using FinanceManager.Identity.Services;
using FinanceManager.Infrastructure;
using FinanceManager.Infrastructure.Factory;
using FinanceManager.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Api.Iocgit
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Repositório
            services.AddScoped<IContaFinanceiraRepository, ContaFinanceiraRep>();

            // Service
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IContaFinanceiraService, ContaFinanceiraService>();

            // Factory
            services.AddScoped<IContaFinanceiraFactory, ContaFinanceiraFactory>();

            //Email
            services.AddScoped<IEmailSender, EmailSender>();

            // Configuração Email
            services.Configure<DataProtectionTokenProviderOptions>(options =>
           options.TokenLifespan = TimeSpan.FromHours(2));
            services.Configure<EmailSenderOptions>(configuration.GetSection("EmailSenderOptions"));
            services.Configure<DataProtectionTokenProviderOptions>("EmailConfirmation", options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(2);
            });

            // Configuração Conexão
            services.AddDbContext<FinanceManagerContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("strConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Cors 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Autorização
            services.AddAuthorizationPolicies();

            // Indentificador e Autenticador
            services.AddAuthentication(configuration);
            services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddDefaultUI()
           .AddEntityFrameworkStores<FinanceManagerContext>()

           //Maneger
           .AddUserManager<UserManager<ApplicationUser>>()
           .AddSignInManager<SignInManager<ApplicationUser>>()

           // Token 
           .AddDefaultTokenProviders()
           .AddTokenProvider("Default", typeof(EmailConfirmationTokenProvider<ApplicationUser>));

            
        }
    }
}
