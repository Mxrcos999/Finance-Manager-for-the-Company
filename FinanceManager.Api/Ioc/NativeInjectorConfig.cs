using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Services;
using FinanceManager.Identity.Interfaces;
using FinanceManager.Identity.Services;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinanceManager.Api.Extensions;
using FinanceManager.Domain.Entidades;

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
           .AddDefaultTokenProviders()
           .AddDefaultUI()
           .AddEntityFrameworkStores<FinanceManagerContext>()
           .AddDefaultTokenProviders()
           .AddUserManager<UserManager<ApplicationUser>>()
           .AddSignInManager<SignInManager<ApplicationUser>>();

            services.AddAuthentication(configuration);
            services.AddAuthorizationPolicies();
        }
    }
}
