using AMcom.Ubs.Dominio.Modelos;
using AMcom.Ubs.Infra.BancoDeDados.Mapeamentos.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMcom.Ubs.Infra.BancoDeDados.Mapeamentos
{
    internal class UnidadeSaudeMapeamento : MapeamentoBase<UnidadeSaude>
    {
        public override void Configure(EntityTypeBuilder<UnidadeSaude> builder)
        {
            builder.Property(x => x.NomeUnidade)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Endereco)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Bairro)
                .HasMaxLength(40)
                .HasColumnType("varchar(40)");

            builder.Property(x => x.Cidade)
                .HasMaxLength(40)
                .HasColumnType("varchar(40)");

            builder.Property(x => x.Ambiencia)
                .HasMaxLength(60)
                .HasColumnType("varchar(60)");

            base.Configure(builder);
        }
    }
}