using Microsoft.EntityFrameworkCore;
using OrdemServicoAPI.Data;
using OrdemServicoAPI.Services;
using OrdemServicoAPI.Services.Interfaces;
using OrdemServicoAPI.Services.Implementations;
using OrdemServicoAPI.Repositories.Interfaces;
using OrdemServicoAPI.Repositories;
using OrdemServicoAPI.Repositories.Implementations;
using Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra os serviços
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IOrdemServicoService, OrdemServicoService>();
builder.Services.AddScoped<IServicosService, ServicoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IOrdemServicoServicoService, OrdemServicoServicoService>();

// Registra os repositórios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IOrdemServicoServicoRepository, OrdemServicoServicoRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ativa os Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// mapeia os Controllers
app.MapControllers();

app.Run();
