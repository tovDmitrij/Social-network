using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using api.Misc;
using api.Middlewares;
using database.context.main;
using database.context.main.Repos.User;
using database.context.main.Repos.Profile;
using database.context.main.Repos.Languages;
using database.context.main.Repos.LifePositions;
using database.context.main.Repos.Cities;
using database.context.main.Repos.FamilyStatuses;
namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {



            #region builder

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
            builder.Services.AddCors();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(30);});
            
            builder.Services.AddDbContext<MainContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("social_network_user_admin")));
            builder.Services.AddScoped<IAuthRepos, AuthRepos>();
            builder.Services.AddScoped<IProfileRepos, ProfileRepos>();
            builder.Services.AddScoped<ILanguageRepos, LanguageRepos>();
            builder.Services.AddScoped<ILifePositionsRepos, LifePositionsRepos>();
            builder.Services.AddScoped<IPlaceOfLivingRepos, PlaceOfLivingRepos>();
            builder.Services.AddScoped<IFamilyStatusRepos, FamilyStatusRepos>();

            #endregion



            #region app

            var app = builder.Build();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
            );
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllers();
            app.Run();

            #endregion



        }
    }
}