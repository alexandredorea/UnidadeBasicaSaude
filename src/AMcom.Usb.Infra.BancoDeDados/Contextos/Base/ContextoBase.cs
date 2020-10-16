using Microsoft.EntityFrameworkCore;

namespace AMcom.Ubs.Infra.BancoDeDados.Contextos.Base
{
    public abstract class ContextoBase : DbContext, IContextoBase
    {
        public abstract string NomeContexto { get; }

        protected ContextoBase(DbContextOptions options) : base(options)
        {
        }
    }
}