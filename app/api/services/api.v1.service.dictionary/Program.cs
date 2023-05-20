using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using api.service.data.Middlewares;
using db.v1.context.dictionary;
using db.v1.context.dictionary.Wrappers;
namespace api.service.data
{
    public class Program
    {
        public static void Main(string[] args)
        {



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

            builder.Services.AddDbContext<DictionaryContext>(options => options.UseNpgsql(config.GetConnectionString("default")));
            builder.Services.AddSingleton<IDictionaryWrapper, IDictionaryWrapper>();

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



        }
    }
}