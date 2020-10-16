using Modelo.Ubs.Dominio.Interfaces.Modelos;
using System;

namespace Modelo.Ubs.Dominio.Modelos.Base
{
    public abstract class EntidadeBase<ChavePrimaria> : IEntidadeBase<ChavePrimaria>
    {
        public ChavePrimaria Id { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}#{Id}";
        }
    }

    public abstract class EntidadeBase : EntidadeBase<Guid>, IEntidadeBase
    {
    }
}