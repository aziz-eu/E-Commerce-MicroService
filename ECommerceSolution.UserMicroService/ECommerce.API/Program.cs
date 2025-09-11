using eCommerce.Core;
using eCommerce.Infrastructure;
using ECommerce.API.Middlewares;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers();
var app = builder.Build();
app.UseExceptionHandlerMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); 
app.MapGet("/", () => "Hello World!");

app.Run();
