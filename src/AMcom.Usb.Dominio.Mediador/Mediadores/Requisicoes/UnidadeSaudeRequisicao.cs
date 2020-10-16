using AMcom.Ubs.Dominio.Contratos;
using MediatR;
using System;
using System.Collections.Generic;

namespace AMcom.Ubs.Dominio.Mediador.Mediadores.Requisicoes
{
    public class UnidadeSaudeRequisicao : IRequest<IList<RetornoUnidadeSaudeContrato>>
    {
        public UnidadeSaudeContrato Contrato { get; private set; }

        public UnidadeSaudeRequisicao(UnidadeSaudeContrato contrato)
        {
            Contrato = contrato ?? throw new ArgumentNullException(nameof(contrato));
        }
    }
}