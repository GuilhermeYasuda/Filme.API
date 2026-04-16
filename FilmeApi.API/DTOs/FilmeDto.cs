namespace FilmeApi.API.DTOs
{
    public record FilmeDto(Guid Id, string Titulo, string Genero, DateTimeOffset DtLancamento, double Avaliacao);
}
