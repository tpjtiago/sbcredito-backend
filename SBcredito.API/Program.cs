using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SBcredito.API.Configuration;
using SBcredito.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SBCreditoContext>(x => x.UseSqlServer(connectionString));

DependencyInjectionConfiguration.AddDependencyInjection(builder);

AutoMapperConfiguration.AddAutoMapper(builder);

builder.Services.AddCors();

builder.Services
    .AddControllersWithViews()
    .AddFluentValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
