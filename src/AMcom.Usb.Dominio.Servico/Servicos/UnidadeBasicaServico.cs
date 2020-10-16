using AMcom.Ubs.Dominio.Contratos;
using AMcom.Ubs.Dominio.Excecoes;
using AMcom.Ubs.Dominio.Interfaces.Conversores;
using AMcom.Ubs.Dominio.Interfaces.Servicos;
using AMcom.Ubs.Dominio.Modelos;
using AMcom.Ubs.Infra.BancoDeDados.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AMcom.Ubs.Dominio.Servico.Servicos
{
    internal class UnidadeBasicaServico : IUnidadeSaudeServico
    {
        private readonly IRepositorioBase repositorio;
        private readonly IConversorUnidadeSaude conversor;

        public UnidadeBasicaServico(IRepositorioBase repositorio, IConversorUnidadeSaude conversor)
        {
            this.repositorio = repositorio;
            this.conversor = conversor;
        }

        public async Task<IList<RetornoUnidadeSaudeContrato>> ObterUnidadesSaude(UnidadeSaudeContrato contrato)
        {
            var unidadesBasicas = await repositorio.ObterTodosAsync<UnidadeSaude>().ConfigureAwait(false);
            var casosFiltrados = unidadesBasicas
                .OrderBy(ubs => ubs.ObterAvaliacaoAmbiencia(ubs.Ambiencia))
                .ThenBy(cood => cood.ObterDistanciaCoordenadas(contrato.Latitude, contrato.Longitude))
                .Take(5)
                .ToList();

            return conversor.ConverterParaContrato(casosFiltrados);
        }

        //TODO: Criar um Seed para os dados
        //TODO: Obter as informações pelo appsettings
        private async void Seed()
        {
            string pathArquivo = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()).Replace("src", "doc"), "ubs.csv");
            StreamReader arquivo = new StreamReader(File.OpenRead(pathArquivo));
            string conteudoArquivo = Regex.Replace(arquivo.ReadToEnd(), Environment.NewLine, "#");
            arquivo.Close();

            IList<string> linhaArquivo = new List<string>(conteudoArquivo.Split('#'));

            for (int indice = 1; indice < conteudoArquivo.Length; indice++)
            {
                string[] campos = linhaArquivo[indice].Split(',');
                var entidade = new UnidadeSaude(
                    latitude: Convert.ToDouble(campos[0].ToString(), CultureInfo.InvariantCulture),
                    longitude: Convert.ToDouble(campos[1].ToString(), CultureInfo.InvariantCulture),
                    nomeUnidade: campos[2].ToString(),
                    endereco: campos[3].ToString(),
                    bairro: campos[4].ToString(),
                    cidade: campos[5].ToString(),
                    ambiencia: campos[6].ToString());
                await repositorio.AdicionarAsync(entidade).ConfigureAwait(false);
            }
        }
    }
}