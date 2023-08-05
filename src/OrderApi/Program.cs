using OrderApi.Extensions;
using OrderApi.MiddleWares;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.File(@"Loggers\OrderApiErrors.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithToken();

builder.Services.AddRepositories();
builder.Services.AddManagers();
builder.Services.AddServices();

builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtValidation(builder.Configuration);

builder.Services.AddOrderApiDbContext(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseErrorHandlerMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();

