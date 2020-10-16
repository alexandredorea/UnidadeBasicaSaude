using Modelo.Ubs.Dominio.Mediador.Mediadores.Handlers;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarRequisicoes(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddMediatR(typeof(UnidadeSaudeHandler).Assembly);
            servicos.AdicionarServicos(configuracao);
        }
    }
}