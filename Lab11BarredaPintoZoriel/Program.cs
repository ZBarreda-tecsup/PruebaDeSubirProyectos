using Lab11BarredaPintoZoriel;
using Lab11BarredaPintoZoriel.Extensions;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using Lab11BarredaPintoZoriel.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddProjectServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<dbContextApi>();

var app = builder.Build();

// HABILITAR SWAGGER SIEMPRE (Render es Production)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = "swagger"; // ahora accesible en /swagger
});

// Desactiva redireccionamiento HTTPS porque Render usa HTTP interno
// app.UseHttpsRedirection();  // QUITADO

app.UseAuthorization();
app.MapControllers();

app.Run();