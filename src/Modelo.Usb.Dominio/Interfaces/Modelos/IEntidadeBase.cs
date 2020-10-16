using System;

namespace Modelo.Ubs.Dominio.Interfaces.Modelos
{
    public interface IEntidadeBase<TChavePrimaria>
    {
        TChavePrimaria Id { get; }
    }

    public interface IEntidadeBase : IEntidadeBase<Guid>
    {
    }
}