using AMcom.Ubs.Dominio.Contratos;
using AMcom.Ubs.Dominio.Interfaces.Servicos;
using AMcom.Ubs.Dominio.Mediador.Mediadores.Requisicoes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AMcom.Ubs.Dominio.Mediador.Mediadores.Handlers
{
    internal class UnidadeSaudeHandler : IRequestHandler<UnidadeSaudeRequisicao, IList<RetornoUnidadeSaudeContrato>>
    {
        private readonly IUnidadeSaudeServico servico;

        public UnidadeSaudeHandler(IUnidadeSaudeServico servico)
        {
            this.servico = servico;
        }

        public async Task<IList<RetornoUnidadeSaudeContrato>> Handle(UnidadeSaudeRequisicao request, CancellationToken cancellationToken)
        {
            return await servico.ObterUnidadesSaude(request.Contrato).ConfigureAwait(false);
        }
    }
}