using api.v1.service.main.Helpers.JWT;
using api.v1.service.main.Helpers.Timestamps;
using api.v1.service.main.Helpers.Validators;
using api.v1.service.main.Helpers.Validators.Interfaces;
using api.v1.service.main.Middlewares;
using api.v1.service.main.Services.Dictionary;
using api.v1.service.main.Services.Profiles;
using api.v1.service.main.Services.Users;
using db.v1.context.main.Contexts.Main;
using db.v1.context.main.Contexts.Main.Interfaces;
using db.v1.context.main.Repositories.Dictionary;
using db.v1.context.main.Repositories.Profiles;
using db.v1.context.main.Repositories.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;



#region Builder

var builder = WebApplication.CreateBuilder(args);
var cfg = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["JWT:SecretKey"]!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "ProtectedPolicy",
        policy => policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("https://localhost:3000"));
    options.AddPolicy(
        name: "PublicPolicy",
        policy => policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(origin => true));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AddHelpers();
AddServices();
AddRepositories();
AddContexts();

void AddHelpers()
{
    builder.Services.AddScoped<ITimestampHelper, TimestampHelper>();
    builder.Services.AddScoped<IJWTHelper, JWTHelper>();
    builder.Services.AddScoped<IUserValidateHelper, ValidateHelper>();
}
void AddServices()
{
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IProfileService, ProfileService>();
    builder.Services.AddScoped<IDictionaryService, DictionaryService>();
}
void AddRepositories()
{
    builder.Services.AddScoped<IUserRepos, UserRepos>();
    builder.Services.AddScoped<IProfileRepos, ProfileRepos>();
    builder.Services.AddScoped<IDictionaryRepos, DictionaryRepos>();
}
void AddContexts()
{
    builder.Services.AddScoped<IUserContext, MainContext>();
    builder.Services.AddScoped<IProfileContext, MainContext>();
    builder.Services.AddScoped<IDictionaryContext, MainContext>();
    builder.Services.AddDbContext<MainContext>(options => options.UseNpgsql(cfg.GetConnectionString("default")));
}

#endregion



#region App

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("PublicPolicy");
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

#endregion


