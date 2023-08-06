using System.Reflection;
using System.Text;
using GRS;
using GRS.Application;
using GRS.Infrastructure;
using GRS.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.JwtSectionName));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection($"{JwtSettings.JwtSectionName}:Key").Value)),
        ValidateIssuer = true,
        ValidateAudience = true
    };
});
builder.Services.AddAuthorization();
builder.Services.AddGrpc();
builder.Services.AddSingleton<JwtAuthenticationManager>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGrpcService<AuthenticationService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();