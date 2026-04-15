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
    }
}
