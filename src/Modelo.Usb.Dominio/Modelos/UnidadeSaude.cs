using Modelo.Ubs.Dominio.Enumeradores;
using Modelo.Ubs.Dominio.Modelos.Base;
using GeoCoordinatePortable;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Ubs.Dominio.Modelos
{
    public class UnidadeSaude : EntidadeBase
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string NomeUnidade { get; private set; }
        public string Endereco { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Ambiencia { get; private set; }

        protected UnidadeSaude()
        {
        }

        public UnidadeSaude(
            double latitude,
            double longitude,
            string nomeUnidade,
            string endereco,
            string bairro,
            string cidade,
            string ambiencia)
        {
            Latitude = latitude;
            Longitude = longitude;
            NomeUnidade = nomeUnidade;
            Endereco = endereco;
            Bairro = bairro;
            Cidade = cidade;
            Ambiencia = ambiencia;
        }

        public double ObterDistanciaCoordenadas(double latitude, double longitude)
        {
            return new GeoCoordinate(Latitude, Longitude).GetDistanceTo(new GeoCoordinate(latitude, longitude));
        }

        public Avaliacao ObterAvaliacaoAmbiencia(string avaliacao)
        {
            var dados = AvaliacaoAmbiencia();
            var dadosAvaliados = dados.FirstOrDefault(x => x.Key == avaliacao).Value;
            return dadosAvaliados;
        }

        private static Dictionary<string, Avaliacao> AvaliacaoAmbiencia()
        {
            return new Dictionary<string, Avaliacao>
            {
                { "Desempenho mediano ou um pouco abaixo da média", Avaliacao.Ruim },
                { "Desempenho mediano ou  um pouco abaixo da média", Avaliacao.Ruim },
                { "Desempenho acima da média", Avaliacao.Bom },
                { "Desempenho muito acima da média", Avaliacao.Excelente }
            };
        }
    }
}