using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MassTransit;
using api.service.profile.Middlewares;
using api.service.profile.Controllers;
using db.v1.context.profiles;
using db.v1.context.profiles.Wrappers;
using api.v1.service.profiles.Consumers;



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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProfileContext>(options => options.UseNpgsql(config.GetConnectionString("default")));
builder.Services.AddScoped<IProfileWrapper, ProfileWrapper>();

builder.Services.AddMassTransit(options =>
{
    options.AddConsumer<ProfileConsumer>();
    options.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(factoryCfg =>
    {
        factoryCfg.Host("rabbitmq://localhost", hostCfg =>
        {
            hostCfg.Username("guest");
            hostCfg.Password("guest");
        });
        factoryCfg.ReceiveEndpoint("profiles_create", endpointCfg =>
        {
            endpointCfg.PrefetchCount = 16;
            endpointCfg.UseMessageRetry(msgCfg => msgCfg.Interval(4, 1000));
            endpointCfg.ConfigureConsumer<ProfileConsumer>(provider);
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
//app.UseMiddleware<TokenMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

#endregion


