using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Services;
using FinanceManager.Domain;
using FinanceManager.Infrastructure;
using FinanceManager.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinanceManager.Api.Extensions;
using FinanceManager.Identity.Interfaces;
using FinanceManager.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();
builder.Services.AddDbContext<FinanceManagerContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("strConnection")));
builder.Services.AddScoped<IContaFinanceiraRepository, ContaFinanceiraRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IContaFinanceiraService, ContaFinanceiraService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddDefaultTokenProviders()
           .AddDefaultUI()
           .AddEntityFrameworkStores<FinanceManagerContext>()
           .AddDefaultTokenProviders()
           .AddUserManager<UserManager<ApplicationUser>>()
           .AddSignInManager<SignInManager<ApplicationUser>>();

builder.Services.AddAuthentication(builder.Configuration);
//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .require()
//        .Build();
//});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
