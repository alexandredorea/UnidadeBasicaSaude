using AMcom.Ubs.Dominio.Interfaces.Modelos;
using System;

namespace AMcom.Ubs.Dominio.Modelos.Base
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