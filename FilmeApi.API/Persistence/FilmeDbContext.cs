using FilmeApi.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.API.Persistence
{
    public class FilmeDbContext(DbContextOptions<FilmeDbContext> options) : DbContext(options)
    {
        public DbSet<Filme> Filmes => Set<Filme>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("app");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilmeDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                // Configura o seeding assíncrono para garantir que o filme de exemplo seja adicionado ao banco de dados, mesmo em cenários onde a inicialização do banco de dados é assíncrona
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    // Procura o filme "Godzilla e Kong: O Novo Império" no banco de dados
                    var sampleFilme = await context.Set<Filme>().FirstOrDefaultAsync(f => f.Titulo == "Godzilla e Kong: O Novo Império");

                    // Se o filme não existir, cria e adiciona ao banco de dados
                    if (sampleFilme == null)
                    {
                        sampleFilme = Filme.Create(
                            "Godzilla e Kong: O Novo Império",
                            "Ação, Aventura, Ficção Científica",
                            new DateTimeOffset(new DateTime(2024, 3, 28), TimeSpan.Zero),
                            6.2
                        );

                        await context.Set<Filme>().AddAsync(sampleFilme);
                        await context.SaveChangesAsync();
                    }
                })
                // Configura o seeding síncrono como fallback para garantir que o filme de exemplo seja adicionado ao banco de dados em cenários onde a inicialização do banco de dados é síncrona
                .UseSeeding((context, _) =>
                {
                    // Procura o filme "Godzilla e Kong: O Novo Império" no banco de dados
                    var sampleFilme = context.Set<Filme>().FirstOrDefault(f => f.Titulo == "Godzilla e Kong: O Novo Império");

                    // Se o filme não existir, cria e adiciona ao banco de dados
                    if (sampleFilme == null)
                    {
                        sampleFilme = Filme.Create(
                            "Godzilla e Kong: O Novo Império",
                            "Ação, Aventura, Ficção Científica",
                            new DateTimeOffset(new DateTime(2024, 3, 28), TimeSpan.Zero),
                            6.2
                        );

                        context.Set<Filme>().Add(sampleFilme);
                        context.SaveChanges();
                    }
                });
        }
    }
}
