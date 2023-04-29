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

namespace FinanceManager.Api.Ioc
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinanceManagerContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("strConnection")));
            services.AddScoped<IContaFinanceiraRepository, ContaFinanceiraRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IContaFinanceiraService, ContaFinanceiraService>();
            services.AddScoped<IContaFinanceiraFactory, ContaFinanceiraFactory>();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
           options.TokenLifespan = TimeSpan.FromHours(2));


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
