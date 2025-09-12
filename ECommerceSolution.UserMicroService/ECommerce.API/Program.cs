using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using ECommerce.API.Middlewares;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers().AddJsonOptions(
    opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
var app = builder.Build();
app.UseExceptionHandlerMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); 
app.MapGet("/", () => "Hello World!");

app.Run();
