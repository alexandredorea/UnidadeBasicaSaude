﻿using Modelo.Ubs.Infra.BancoDeDados.Contextos;
using Modelo.Ubs.Teste.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Modelo.Ubs.Teste.Integracoes
{
    public abstract class ModeloTesteBase : TesteBase
    {
        protected override void AdicionarServicos(IServiceCollection servicos, IConfiguration configuracao)
        {
            AdicionarBancoDadosTeste<UnidadeBasicaContexto>();
            servicos.AdicionarServicos(configuracao);
            servicos.AddLogging();

            AdicionarServicosMocados(servicos, configuracao);
        }

        protected override void SetUp()
        {
            SetUpAMcomUbs();
        }

        protected abstract void SetUpAMcomUbs();

        protected TServico ObterServicoMocado<TServico>()
            where TServico : class
        {
            TServico servico = Substitute.For<TServico>();
            return servico;
        }

        protected virtual void AdicionarServicosMocados(IServiceCollection servicos, IConfiguration configuracao)
        {
        }
    }
}