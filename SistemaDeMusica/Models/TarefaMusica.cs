using SistemaDeMusica.Enums;

namespace SistemaDeMusica.Models
{
    public class TarefaMusica
    {
        public int Id { get; set; }
        public string NomeMusica { get; set; }
        public StatusAvaliacaoMusica AvaliacaoDaMusica { get; set; }
        public int NotaDaMusica { get; set; }
        public int UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}
