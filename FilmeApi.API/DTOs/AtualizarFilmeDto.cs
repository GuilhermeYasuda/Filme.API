namespace FilmeApi.API.DTOs
{
    public record AtualizarFilmeDto(string Titulo, string Genero, DateTimeOffset DtLancamento, double Avaliacao);
}
