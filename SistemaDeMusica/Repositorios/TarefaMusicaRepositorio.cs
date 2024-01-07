using Microsoft.EntityFrameworkCore;
using SistemaDeMusica.Data;
using SistemaDeMusica.Models;
using SistemaDeMusica.Repositorios.Interfaces;

namespace SistemaDeMusica.Repositorios
{
    public class TarefaMusicaRepositorio : ITarefaMusicaRepositorio
    {
        private readonly SistemaMusicaDBContex _dbContext;
        public TarefaMusicaRepositorio(SistemaMusicaDBContex sistemaMusicaDBContex)
        {
            _dbContext = sistemaMusicaDBContex;
        }

        public async Task<TarefaMusica> BuscarPorId(int id)
        {
            return await _dbContext.Musicas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaMusica>> BuscarTodasMusicas()
        {
            return await _dbContext.Musicas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaMusica> Adicionar(TarefaMusica musica)
        {
            await _dbContext.Musicas.AddAsync(musica);
            await _dbContext.SaveChangesAsync();

            return musica;
        }

        public async Task<TarefaMusica> Atualizar(TarefaMusica musica, int id)
        {
            TarefaMusica musicaPorId = await BuscarPorId(id);

            if (musicaPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            musicaPorId.NomeMusica = musica.NomeMusica;
            musicaPorId.AvaliacaoDaMusica = musica.AvaliacaoDaMusica;
            musicaPorId.NotaDaMusica = musica.NotaDaMusica;

            _dbContext.Musicas.Update(musicaPorId);
            await _dbContext.SaveChangesAsync();

            return musicaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaMusica musicaPorId = await BuscarPorId(id);

            if (musicaPorId == null)
            {
                throw new Exception($"Música para o ID: {id} não foi encontrada no banco de dados.");
            }

            _dbContext.Musicas.Remove(musicaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
