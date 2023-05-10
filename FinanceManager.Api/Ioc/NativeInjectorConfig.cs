using FinanceManager.Api.Extensions;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Application.Services;
using FinanceManager.Domain.Entidades;
using FinanceManager.Identity.Configurations;
using FinanceManager.Identity.Interfaces;
using FinanceManager.Identity.Services;
using FinanceManager.Infrastructure;
using FinanceManager.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Api.Ioc
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinanceManagerContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("strConnection")));
            services.AddScoped<ILancamentoRep, LancamentoRep>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<ILancamentoService, LancamentoService>();
            services.AddScoped<ILancamentoRep, LancamentoRep>();
            services.AddScoped<ILancamentoRecorrenteRep, LancamentoRecorrenteRep>();
            services.AddScoped<ILancamentoRecorrenteService, LancamentoRecorrenteService>();
            services.AddScoped<ICategoriaRep, CategoriaRep>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
           options.TokenLifespan = TimeSpan.FromHours(2));
            services.Configure<EmailSenderOptions>(configuration.GetSection("EmailSenderOptions"));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.Configure<DataProtectionTokenProviderOptions>("EmailConfirmation", options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(2);
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddDefaultUI()
           .AddEntityFrameworkStores<FinanceManagerContext>()
           .AddUserManager<UserManager<ApplicationUser>>()
           .AddSignInManager<SignInManager<ApplicationUser>>()
           .AddDefaultTokenProviders()
           .AddTokenProvider("Default", typeof(EmailConfirmationTokenProvider<ApplicationUser>));

            services.AddAuthentication(configuration);
            services.AddAuthorizationPolicies();
        }
    }
}
