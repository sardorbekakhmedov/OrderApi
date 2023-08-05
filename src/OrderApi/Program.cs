using OrderApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllers();

app.Run();

