using Modelo.Ubs.Dominio.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modelo.Ubs.Dominio.Interfaces.Servicos
{
    public interface IUnidadeSaudeServico
    {
        Task<IList<RetornoUnidadeSaudeContrato>> ObterUnidadesSaude(UnidadeSaudeContrato contrato);
    }
}