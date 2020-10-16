using AMcom.Ubs.Dominio.Contratos;
using AMcom.Ubs.Dominio.Interfaces.Conversores;
using AMcom.Ubs.Dominio.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace AMcom.Ubs.Dominio.Servico.Conversores
{
    internal class ConversorUnidadeBasica : IConversorUnidadeSaude
    {
        public IList<RetornoUnidadeSaudeContrato> ConverterParaContrato(IList<UnidadeSaude> unidadesBasicas)
        {
            var retorno = new List<RetornoUnidadeSaudeContrato>();

            if (unidadesBasicas == null)
                return retorno;

            retorno = unidadesBasicas.Select(x => ConverterParaContrato(x)).ToList();
            return retorno;
        }

        private RetornoUnidadeSaudeContrato ConverterParaContrato(UnidadeSaude unidadeBasica)
        {
            return new RetornoUnidadeSaudeContrato
            {
                Nome = unidadeBasica.NomeUnidade,
                Endereco = $"{unidadeBasica.Endereco}, {unidadeBasica.Bairro} {unidadeBasica.Cidade}.",
                Avaliacao = unidadeBasica.Ambiencia
            };
        }
    }
}