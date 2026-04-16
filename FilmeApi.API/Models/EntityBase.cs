namespace FilmeApi.API.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public DateTimeOffset DtCriacao { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset DtUltimaAlteracao { get; private set; } = DateTimeOffset.UtcNow;

        public void AtualizarDataUltimaAlteracao()
        {
            DtUltimaAlteracao = DateTimeOffset.UtcNow;
        }
    }
}