using FilmeApi.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmeApi.API.Persistence.Configurations
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            // Define nome da tabela
            builder.ToTable("Filmes");

            // Indica que a propriedade Id é a chave primária
            builder.HasKey(f => f.Id);

            // Configura as propriedades
            builder.Property(f => f.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(f => f.Genero)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.DtLancamento)
                .IsRequired();

            builder.Property(f => f.Avaliacao)
                .IsRequired();

            // Configura o relacionamento com a entidade base (EntityBase)
            // Configura as propriedades DtCriacao e DtUltimaAlteracao para serem tratadas como timestamps imutáveis ​​e modificáveis
            builder.Property(f => f.DtCriacao)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(f => f.DtUltimaAlteracao)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();

            // Adiciona índices para melhorar a performance de consultas
            builder.HasIndex(m => m.Titulo);
        }
    }
}
