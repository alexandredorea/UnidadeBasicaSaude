using Modelo.Ubs.Dominio.Contratos;
using Modelo.Ubs.Dominio.Modelos;
using System.Collections.Generic;

namespace Modelo.Ubs.Dominio.Interfaces.Conversores
{
    public interface IConversorUnidadeSaude
    {
        IList<RetornoUnidadeSaudeContrato> ConverterParaContrato(IList<UnidadeSaude> unidadesBasicas);
    }
}