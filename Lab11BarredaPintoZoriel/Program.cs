using Lab11BarredaPintoZoriel;
using Lab11BarredaPintoZoriel.Extensions;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using Lab11BarredaPintoZoriel.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProjectServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
builder.Services.AddDbContext<dbContextApi>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();