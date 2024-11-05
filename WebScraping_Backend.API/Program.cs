using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Core.Entities;
using WebScraping_Backend.Infrastructure.Data;
using WebScraping_Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using WebScraping_Backend.Core.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder
    .Services
    .AddDbContext<ProjectWebScrapingContext>
    (options => options.UseSqlServer(cnx));

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddTransient<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddTransient<IVideoGeneradoRepository, VideoGeneradoRepository>();
builder.Services.AddTransient<IVideoGeneradoService, VideoGeneradoService>();
builder.Services.AddTransient<ILista_GuardadoRepository, ListaGuardadoRepository>();
builder.Services.AddTransient<ILista_GuardadoService, ListaGuardadoService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();



builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
