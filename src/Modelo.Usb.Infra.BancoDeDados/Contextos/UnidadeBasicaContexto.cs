using Modelo.Ubs.Infra.BancoDeDados.Contextos.Base;
using Modelo.Ubs.Infra.BancoDeDados.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Modelo.Ubs.Infra.BancoDeDados.Contextos
{
    public class UnidadeBasicaContexto : ContextoBase
    {
        public override string NomeContexto => nameof(UnidadeBasicaContexto);

        public UnidadeBasicaContexto(DbContextOptions options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            //if (!Database.GetService<IRelationalDatabaseCreator>().Exists())
            //{
            //    Database.EnsureCreated();
            //}
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = ObterConfiguracaoConexao();

                optionsBuilder
                    .UseSqlServer(config.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Modelo.Ubs.WebApi"))
                    .UseLazyLoadingProxies()
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();

                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UnidadeSaudeMapeamento());
            base.OnModelCreating(modelBuilder);
        }

        private static IConfigurationRoot ObterConfiguracaoConexao()
        {
            //TODO: MELHORAR AQUI
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json");

            return builder.Build();
        }
    }
}