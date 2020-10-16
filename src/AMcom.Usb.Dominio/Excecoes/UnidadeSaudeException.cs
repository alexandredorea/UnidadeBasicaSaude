using System;

namespace AMcom.Ubs.Dominio.Excecoes
{
    public class UnidadeSaudeException : ArgumentOutOfRangeException
    {
        public UnidadeSaudeException()
        {
        }

        public UnidadeSaudeException(string mensagem)
            : base(mensagem)
        {
        }

        public UnidadeSaudeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}