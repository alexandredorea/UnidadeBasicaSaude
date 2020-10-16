using AMcom.Ubs.Infra.BancoDeDados.Contextos.Base;
using AMcom.Ubs.Infra.BancoDeDados.Repositorios.Base;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarBancoDeDados<TipoContexto, ChavePrimaria>(this IServiceCollection servicos, IConfiguration configuracao)
            where TipoContexto : ContextoBase
        {
            servicos.AddDbContext<TipoContexto>();
            servicos.AddScoped<IRepositorioBase<ChavePrimaria>, RepositorioBase<TipoContexto, ChavePrimaria>>();
        }

        public static void AdicionarBancoDeDados<TipoContexto>(this IServiceCollection servicos, IConfiguration configuracao)
            where TipoContexto : ContextoBase
        {
            servicos.AddDbContext<TipoContexto>();
            servicos.AddScoped<IRepositorioBase, RepositorioBase<TipoContexto>>();
        }
    }
}