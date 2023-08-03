using Microsoft.EntityFrameworkCore;
using MVM.CabanasDream.Locacao.API.Middlewares;
using MVM.CabanasDream.Locacao.API.Setup;
using MVM.CabanasDream.Locacao.API.Setup.Mappers;
using MVM.CabanasDream.Locacao.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();

builder.Services.AddAutoMapper(typeof(FestaProfile));

// Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FestaContext>(opt => opt.UseNpgsql(connectionString));

var app = builder.Build();

// Middlewares
app.UseMiddleware<LoggingExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

