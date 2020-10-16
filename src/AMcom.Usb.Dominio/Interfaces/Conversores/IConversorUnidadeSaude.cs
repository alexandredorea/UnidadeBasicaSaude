using AMcom.Ubs.Dominio.Contratos;
using AMcom.Ubs.Dominio.Modelos;
using System.Collections.Generic;

namespace AMcom.Ubs.Dominio.Interfaces.Conversores
{
    public interface IConversorUnidadeSaude
    {
        IList<RetornoUnidadeSaudeContrato> ConverterParaContrato(IList<UnidadeSaude> unidadesBasicas);
    }
}