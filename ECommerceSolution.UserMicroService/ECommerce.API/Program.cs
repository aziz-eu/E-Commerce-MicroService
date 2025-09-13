using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using ECommerce.API.Middlewares;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers().AddJsonOptions(
    opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.
        WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
        //.AllowAnyOrigin();
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseExceptionHandlerMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); 
app.MapGet("/", () => "Hello World!");

app.Run();
