using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using api.service.dictionary.Middlewares;
using db.v1.context.dictionary;
using db.v1.context.dictionary.Wrappers;
using MassTransit;



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
            policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("https://localhost:7001");
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DictionaryContext>(options => options.UseNpgsql(config.GetConnectionString("default")));
builder.Services.AddScoped<IDictionaryWrapper, DictionaryWrapper>();

builder.Services.AddMassTransit(options =>
{
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
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

#endregion


