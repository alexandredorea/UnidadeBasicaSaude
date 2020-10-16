using AMcom.Ubs.Dominio.Configuracoes;
using AMcom.Ubs.Dominio.Excecoes;
using AMcom.Ubs.Dominio.Interfaces.Conversores;
using AMcom.Ubs.Dominio.Interfaces.Servicos;
using AMcom.Ubs.Dominio.Servico.Conversores;
using AMcom.Ubs.Dominio.Servico.Servicos;
using AMcom.Ubs.Infra.BancoDeDados.Contextos;
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