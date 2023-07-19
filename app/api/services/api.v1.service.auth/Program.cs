using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MassTransit;
using api.v1.service.auth.Middlewares;
using db.v1.context.auth.Repos;
using db.v1.context.auth;
using helpers.jwt;



#region builder

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllOrigins",
        policy =>
        {
            policy.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
        });
});
builder.Services.AddHealthChecks();
//builder.Services.AddAntiforgery(options =>
//{
//    options.HeaderName = "X-XSRF-TOKEN";
//    options.SuppressXFrameOptionsHeader = true;
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuthContext>(options => options.UseNpgsql(config.GetConnectionString("default")));
builder.Services.AddScoped<IAuthRepos, AuthRepos>();
builder.Services.AddScoped<IAuthServiceToken, AuthToken>();

builder.Services.AddMassTransit(options =>
{
    options.AddHealthChecks();
    options.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(factoryCfg =>
    {
        factoryCfg.Host("rabbitmq://localhost", hostCfg =>
        {
            hostCfg.Username("guest");
            hostCfg.Password("guest");
        });
    }));
});

#endregion



#region app

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllOrigins");
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<HeadersMiddleware>();
app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

#endregion


