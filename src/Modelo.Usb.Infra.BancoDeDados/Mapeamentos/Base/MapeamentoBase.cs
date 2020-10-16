using Modelo.Ubs.Dominio.Modelos.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Modelo.Ubs.Infra.BancoDeDados.Mapeamentos.Base
{
    public class MapeamentoBase<TipoEntidade, Tipo> : IEntityTypeConfiguration<TipoEntidade> where TipoEntidade : EntidadeBase<Tipo>
    {
        private string NomeTabela => typeof(TipoEntidade).Name;

        public virtual void Configure(EntityTypeBuilder<TipoEntidade> builder)
        {
            builder.ToTable(NomeTabela);

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                .HasName($"IX_{NomeTabela}_Id");
        }
    }

    public class MapeamentoBase<TipoEntidade> : IEntityTypeConfiguration<TipoEntidade> where TipoEntidade : EntidadeBase
    {
        private string NomeTabela => typeof(TipoEntidade).Name;

        public virtual void Configure(EntityTypeBuilder<TipoEntidade> builder)
        {
            builder.ToTable(NomeTabela);

            builder.HasKey(x => x.Id)
                .HasName($"IX_{NomeTabela}_Id");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<SequentialGuidValueGenerator>()
                .HasDefaultValueSql("NEWSEQUENTIALID()");
        }
    }
}