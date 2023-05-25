using Microsoft.EntityFrameworkCore;
using MassTransit;
using db.v1.context.logs.Repos;
using api.v1.service.logs.Consumers;



#region builder

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
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

builder.Services.AddDbContext<db.v1.context.logs.LogContext>(options => options.UseNpgsql(config.GetConnectionString("default")));
builder.Services.AddScoped<ILogRepos, LogRepos>();

builder.Services.AddMassTransit(options =>
{
    options.AddConsumer<LogConsumer>();
    options.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(factoryCfg =>
    {
        factoryCfg.Host("rabbitmq://localhost", hostCfg =>
        {
            hostCfg.Username("guest");
            hostCfg.Password("guest");
        });
        factoryCfg.ReceiveEndpoint("logs_create", endpointCfg =>
        {
            endpointCfg.PrefetchCount = 16;
            endpointCfg.UseMessageRetry(msgCfg => msgCfg.Interval(4, 1000));
            endpointCfg.ConfigureConsumer<LogConsumer>(provider);
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
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

#endregion


