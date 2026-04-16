namespace FilmeApi.API.DTOs
{
    public record CriarFilmeDto(string Titulo, string Genero, DateTimeOffset DtLancamento, double Avaliacao);
}
