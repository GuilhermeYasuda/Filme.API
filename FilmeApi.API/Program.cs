using FilmeApi.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FilmeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configuração não recomendada para ambientes de produção, mas útil para desenvolvimento e testes. Em um ambiente de produção, é recomendado usar migrações para gerenciar o esquema do banco de dados.
// Garante de que o banco de dados foi criado e preenchido com os dados iniciais.
await using (var serviceScope = app.Services.CreateAsyncScope())
await using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<FilmeDbContext>())
{
    // Garante que o banco de dados foi criado. Se ele já existir, isso não fará nada.
    await dbContext.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Map endpoints
app.MapGet("/", () => "Hello World!")
   .Produces<string>(200);

app.UseAuthorization();

app.MapControllers();

app.Run();
