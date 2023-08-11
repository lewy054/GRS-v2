using System.Reflection;
using System.Text;
using GRS;
using GRS.Application;
using GRS.Infrastructure;
using GRS.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.JwtSectionName));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration[$"{JwtSettings.JwtSectionName}:Issuer"],
        ValidAudience = builder.Configuration[$"{JwtSettings.JwtSectionName}:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration[$"{JwtSettings.JwtSectionName}:Key"]!))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddSingleton<JwtAuthenticationManager>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapGrpcService<AuthenticationService>();
app.MapGrpcService<ForumService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();