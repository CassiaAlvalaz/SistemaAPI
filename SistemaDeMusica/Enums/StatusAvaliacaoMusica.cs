using System.ComponentModel;

namespace SistemaDeMusica.Enums
{
    public enum StatusAvaliacaoMusica
    {
        [Description("Gosto da música.")]
        Gosto = 1,
        [Description("Não gosto da música.")]
        NaoGosto = 2,
        [Description("Gosto da música, mas não tanto.")]
        MeioTermo = 3
    }
}
