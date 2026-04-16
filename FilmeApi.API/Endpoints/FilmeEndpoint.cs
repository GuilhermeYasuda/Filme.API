using FilmeApi.API.DTOs;
using FilmeApi.API.Services;

namespace FilmeApi.API.Endpoints
{
    public static class FilmeEndpoint
    {
        public static void MapFilmeEndpoints(this IEndpointRouteBuilder routes)
        {
            var filmeApi = routes.MapGroup("/api/filmes").WithTags("Filmes");

            filmeApi.MapPost("/", async (IFilmeService service, CriarFilmeDto command) =>
            {
                // Lógica para criar um novo filme
                var filme = await service.CreateFilmeAsync(command);
                return TypedResults.Created($"/api/filmes/{filme.Id}", filme);
            });

            filmeApi.MapGet("/", async (IFilmeService service) =>
            {
                // Lógica para obter a lista de filmes
                var filmes = await service.GetAllFilmesAsync();
                return TypedResults.Ok(filmes);
            });

            filmeApi.MapGet("/{id}", async (IFilmeService service, Guid id) =>
            {
                // Lógica para obter um filme específico por ID
                var filme = await service.GetFilmeByIdAsync(id);

                return filme is null
                    ? (IResult)TypedResults.NotFound(new { Message = $"Filme com ID {id} não encontrado." })
                    : TypedResults.Ok(filme);
            });

            filmeApi.MapPut("/{id}", async (IFilmeService service, Guid id, AtualizarFilmeDto command) =>
            {
                // Lógica para atualizar um filme existente
                await service.UpdateFilmeAsync(id, command);
                return TypedResults.NoContent();
            });

            filmeApi.MapDelete("/{id}", async (IFilmeService service, Guid id) =>
            {
                // Lógica para excluir um filme
                await service.DeleteFilmeAsync(id);
                return TypedResults.NoContent();
            });
        }
    }
}
