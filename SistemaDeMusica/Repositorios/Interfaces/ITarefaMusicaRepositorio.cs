using SistemaDeMusica.Models;

namespace SistemaDeMusica.Repositorios.Interfaces
{
    public interface ITarefaMusicaRepositorio
    {
        Task<List<TarefaMusica>> BuscarTodasMusicas();
        Task<TarefaMusica> BuscarPorId(int id);
        Task<TarefaMusica> Adicionar(TarefaMusica musica);
        Task<TarefaMusica> Atualizar(TarefaMusica musica, int id);
        Task<bool> Apagar(int id);
    }
}
