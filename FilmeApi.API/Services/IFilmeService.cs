using FilmeApi.API.DTOs;

namespace FilmeApi.API.Services
{
    public interface IFilmeService
    {
        Task<FilmeDto> CreateFilmeAsync(CriarFilmeDto command);
        Task<FilmeDto?> GetFilmeByIdAsync(Guid id);
        Task<IEnumerable<FilmeDto>> GetAllFilmesAsync();
        Task UpdateFilmeAsync(Guid id, AtualizarFilmeDto command);
        Task DeleteFilmeAsync(Guid id);
    }
}
