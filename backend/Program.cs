using Microsoft.EntityFrameworkCore;
using OrdemServicoAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ativa os Controllers
builder.Services.AddControllers();

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
