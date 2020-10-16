using AMcom.Ubs.Dominio.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMcom.Ubs.Dominio.Interfaces.Servicos
{
    public interface IUnidadeSaudeServico
    {
        Task<IList<RetornoUnidadeSaudeContrato>> ObterUnidadesSaude(UnidadeSaudeContrato contrato);
    }
}