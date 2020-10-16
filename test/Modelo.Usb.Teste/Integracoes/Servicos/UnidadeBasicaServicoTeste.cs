using Modelo.Ubs.Dominio.Excecoes;
using Modelo.Ubs.Dominio.Interfaces.Servicos;
using Modelo.Ubs.Dominio.Modelos;
using Modelo.Ubs.Teste.Builders.Contratos;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Ubs.Teste.Integracoes.Servicos
{
    public class UnidadeBasicaServicoTeste : ModeloTesteBase
    {
        private IUnidadeSaudeServico servico;

        protected override void SetUpAMcomUbs()
        {
            servico = ObterServico<IUnidadeSaudeServico>();
            _ = DadasAlgumasUnidadesDeSaudeAleatorias();
        }

        [Test]
        public async Task deve_obter_as_unidades_basicas_de_saude_ordernada_por_melhor_avaliacao_e_proximo_das_coordenadas_passadas()
        {
            //arrange: ao preparar um dado
            var contrato = new UnidadeSaudeContratoBuilder().Construir();
            //act....: no ato de executar
            var retorno = await servico.ObterUnidadesSaude(contrato).ConfigureAwait(false);
            //assert.: [posso] afirmar que o resultado esperado
            retorno.Should().HaveCountLessOrEqualTo(5);
            retorno.FirstOrDefault().Nome.Should().NotBeNullOrEmpty();
            retorno.FirstOrDefault().Endereco.Should().NotBeNullOrEmpty();
            retorno.FirstOrDefault().Avaliacao.Should().NotBeNullOrEmpty();
        }

        [TestCase(-15.1514, -47.1546)]
        [TestCase(16.5487, -25.234567)]
        public async Task deve_obter_as_unidades_basicas_de_saude_ordernada_por_melhor_avaliacao_e_proximo_das_coordenadas_passadas(double latitude, double longitude)
        {
            //arrange
            var contrato = new UnidadeSaudeContratoBuilder()
                .ComLatitude(latitude)
                .ComLatitude(longitude)
                .Construir();
            //act
            var retorno = await servico.ObterUnidadesSaude(contrato).ConfigureAwait(false);
            //assert
            retorno.Should().HaveCountLessOrEqualTo(5);
            retorno.FirstOrDefault().Nome.Should().NotBeNullOrEmpty();
            retorno.FirstOrDefault().Endereco.Should().NotBeNullOrEmpty();
            retorno.FirstOrDefault().Avaliacao.Should().NotBeNullOrEmpty();
        }

        [TestCase(-1115.1514, -75.1546)]
        [TestCase(10.5487, -25234567)]
        public void deve_lancar_excecao_coordenadas_passadas_erradas(double latitude, double longitude)
        {
            var contrato = new UnidadeSaudeContratoBuilder()
                .ComLatitude(latitude)
                .ComLatitude(longitude)
                .Construir();

            Func<Task> retorno = async () => await servico.ObterUnidadesSaude(contrato).ConfigureAwait(false);

            retorno.Should().Throws<UnidadeSaudeException>();
        }

        [Test]
        public void deve_lancar_excecao_se_latitude_for_maior_que_90_graus_positivo_ou_negativo()
        {
            var contrato = new UnidadeSaudeContratoBuilder()
                .ComLatitude(91.01)
                .Construir();

            //act & assert
            Assert.Throws<UnidadeSaudeException>(async () => await servico.ObterUnidadesSaude(contrato).ConfigureAwait(false));
        }

        [Test]
        public void deve_lancar_excecao_se_longitude_for_maior_que_180_graus_positivo_ou_negativo()
        {
            var contrato = new UnidadeSaudeContratoBuilder()
                .ComLongitude(181.01)
                .Construir();

            Func<Task> retorno = async () => await servico.ObterUnidadesSaude(contrato).ConfigureAwait(false);

            retorno.Should().Throws<UnidadeSaudeException>();
        }

        //TODO:
        //public async Task handle_deve_obter_as_unidades_basicas_de_saude_ordernada_por_melhor_avaliacao_e_proximo_das_coordenadas_passadas()
        //{
        //    var contrato = new UnidadeSaudeContratoBuilder().Construir();
        //    var comando = new UnidadeSaudeRequisicao(contrato);
        //    var handler = new UnidadeSaudeHandler();
        //
        //    var retorno = await handler.Handle(comando, new CancellationToken());
        //
        //    retorno.Should().HaveCountLessOrEqualTo(5);
        //    retorno.FirstOrDefault().Nome.Should().NotBeNullOrEmpty();
        //    retorno.FirstOrDefault().Endereco.Should().NotBeNullOrEmpty();
        //    retorno.FirstOrDefault().Avaliacao.Should().NotBeNullOrEmpty();
        //}

        private async Task DadasAlgumasUnidadesDeSaudeAleatorias()
        {
            double coordenada;
            for (int indice = 0; indice < 10; indice++)
            {
                Random random = new Random();
                coordenada = random.NextDouble() * (10 - 1) + indice;

                string ambiencia;
                if (indice % 2 == 0)
                    ambiencia = "Desempenho acima da média";
                else
                    ambiencia = "Desempenho mediano ou um pouco abaixo da média";

                var entidade = new UnidadeSaude(
                    latitude: coordenada,
                    longitude: (coordenada + 5) * -1,
                    nomeUnidade: $"Unidade de Teste {indice}",
                    endereco: $"Endereço de {indice}",
                    bairro: $"Endereço de {indice}",
                    cidade: $"Endereço de {indice}",
                    ambiencia: ambiencia);
                await Repositorio.AdicionarAsync(entidade).ConfigureAwait(false);
            }
        }
    }
}