using FilmeApi.API.DTOs;
using FilmeApi.API.Models;
using FilmeApi.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.API.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly FilmeDbContext _dbContext;
        private readonly ILogger<FilmeService> _logger;

        public FilmeService(FilmeDbContext dbContext, ILogger<FilmeService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<FilmeDto> CreateFilmeAsync(CriarFilmeDto command)
        {
            var filme = Filme.Create(command.Titulo, command.Genero, command.DtLancamento, command.Avaliacao);

            await _dbContext.Filmes.AddAsync(filme);
            await _dbContext.SaveChangesAsync();

            return new(filme.Id, filme.Titulo, filme.Genero, filme.DtLancamento, filme.Avaliacao);
        }

        public async Task DeleteFilmeAsync(Guid id)
        {
            var filme = await _dbContext.Filmes.FindAsync(id);

            if (filme is not null)
            {
                _dbContext.Filmes.Remove(filme);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FilmeDto>> GetAllFilmesAsync()
        {
            return await _dbContext.Filmes
                .AsNoTracking()
                .Select(f => new FilmeDto(
                    f.Id,
                    f.Titulo,
                    f.Genero,
                    f.DtLancamento,
                    f.Avaliacao
                ))
                .ToListAsync();
        }

        public async Task<FilmeDto?> GetFilmeByIdAsync(Guid id)
        {
            var filme = await _dbContext.Filmes
                            .AsNoTracking()
                            .FirstOrDefaultAsync(f => f.Id == id);

            if(filme == null)
                return null;

            return new(
                filme.Id,
                filme.Titulo,
                filme.Genero,
                filme.DtLancamento,
                filme.Avaliacao
            );
        }

        public async Task UpdateFilmeAsync(Guid id, AtualizarFilmeDto command)
        {
            var filme = await _dbContext.Filmes.FindAsync(id);

            if(filme is null)
                throw new ArgumentNullException($"Id do filme inválido: {id}");

            filme.Update(command.Titulo, command.Genero, command.DtLancamento, command.Avaliacao);
            await _dbContext.SaveChangesAsync();
        }
    }
}
