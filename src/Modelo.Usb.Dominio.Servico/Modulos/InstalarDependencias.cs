using Modelo.Ubs.Dominio.Configuracoes;
using Modelo.Ubs.Dominio.Excecoes;
using Modelo.Ubs.Dominio.Interfaces.Conversores;
using Modelo.Ubs.Dominio.Interfaces.Servicos;
using Modelo.Ubs.Dominio.Servico.Conversores;
using Modelo.Ubs.Dominio.Servico.Servicos;
using Modelo.Ubs.Infra.BancoDeDados.Contextos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarServicos(this IServiceCollection servicos, IConfiguration configuracao)
        {
            //Banco
            servicos.AdicionarBancoDeDados<UnidadeBasicaContexto>(configuracao);

            //Serviços
            servicos.TryAddScoped<IUnidadeSaudeServico, UnidadeBasicaServico>();
            servicos.TryAddScoped<IConversorUnidadeSaude, ConversorUnidadeBasica>();

            //TODO: Melhorar
            //servicos.AdicionarConfiguracaoArquivo(configuracao);
        }

        private static void AdicionarConfiguracaoArquivo(this IServiceCollection servicos, IConfiguration configuracoes)
        {
            var configuracaoArquivo = new ConfiguracaoArquivo();
            configuracoes.Bind(nameof(ConfiguracaoArquivo), configuracaoArquivo);

            if (string.IsNullOrEmpty(configuracaoArquivo.CaminhoArquivo))
                throw new UnidadeSaudeException($"Verifique no appsettings.json, se existe a ilha {nameof(ConfiguracaoArquivo)} " +
                                                $"com todas as informações necessárias para a comunicação com a api ArquivoSincronizador");

            servicos.AddSingleton(configuracaoArquivo);
        }
    }
}