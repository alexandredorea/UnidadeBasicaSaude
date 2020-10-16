using Modelo.Ubs.Infra.BancoDeDados.Contextos.Base;
using Modelo.Ubs.Infra.BancoDeDados.Repositorios.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Ubs.Teste.Base
{
    public abstract class TesteBase
    {
        private readonly IServiceCollection serviceCollection;
        private IServiceScopeFactory serviceScopeFactory;
        private Type contextoEFTeste;
        private DbContextOptions<ContextoBase> dbContextOptions;

        protected IConfiguration Configuracao => new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .Build();

        protected IServiceScopeFactory ServicoEscopo
        {
            get
            {
                var contexto = Activator.CreateInstance(contextoEFTeste, dbContextOptions);
                serviceCollection.AddScoped(_ => contexto);
                return serviceScopeFactory;
            }
            private set => value = serviceScopeFactory;
        }

        protected IRepositorioBase Repositorio { get; set; }
        protected IServiceProvider Servico;

        protected TesteBase()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(_ => Configuracao);
        }

        [SetUp]
        public void SetUpBase()
        {
            dbContextOptions = new DbContextOptionsBuilder<ContextoBase>()
                .UseInMemoryDatabase(databaseName: nameof(contextoEFTeste))
                .Options;

            AdicionarServicos(serviceCollection, Configuracao);

            IniciarServiceProviderEContexto();

            SetUp();
        }

        private void IniciarServiceProviderEContexto()
        {
            Servico = serviceCollection.BuildServiceProvider();

            if (contextoEFTeste != null)
            {
                var contexto = (ContextoBase)Servico.GetService(contextoEFTeste);
                contexto.Database.EnsureDeleted();
                contexto.Database.EnsureCreated();

                Repositorio = ObterServico<IRepositorioBase>();
            }

            serviceScopeFactory = Servico.GetService<IServiceScopeFactory>();
        }

        protected abstract void AdicionarServicos(IServiceCollection servicos, IConfiguration configuracao);

        protected abstract void SetUp();

        protected void AdicionarBancoDadosTeste<TContexto>() where TContexto : ContextoBase
        {
            AdicionarBancoDadosTeste<TContexto, Guid>();
        }

        protected void AdicionarBancoDadosTeste<TContexto, TChavePrimaria>() where TContexto : ContextoBase
        {
            contextoEFTeste = typeof(TContexto);
            var contexto = (TContexto)Activator.CreateInstance(contextoEFTeste, dbContextOptions);
            serviceCollection.AddScoped(_ => contexto);
            serviceCollection.AddSingleton<IRepositorioBase<TChavePrimaria>, RepositorioBase<TContexto, TChavePrimaria>>();
            serviceCollection.AddSingleton<IRepositorioBase, RepositorioBase<TContexto>>();
        }

        protected T ObterServico<T>()
        {
            return Servico.GetService<T>();
        }

        protected IEnumerable<T> ObterServicos<T>()
        {
            return Servico.GetServices<T>();
        }

        protected T ObterServico<T>(Type type)
        {
            return (T)Servico.GetService(type);
        }

        protected void SubstituirServico<T>() where T : class
        {
            SubstituirServico<T>(Substitute.For<T>());
        }

        protected void SubstituirServico<T>(T instance)
        {
            var descriptorARemover = serviceCollection.FirstOrDefault(x => x.ServiceType == typeof(T));
            if (descriptorARemover == null)
                return;

            serviceCollection.Remove(descriptorARemover);

            var descriptorAAdicionar = new ServiceDescriptor(typeof(T), instance);

            serviceCollection.Add(descriptorAAdicionar);

            IniciarServiceProviderEContexto();
        }

        [TearDown]
        public void TearDownAttribute()
        {
            TearDown();
        }

        public virtual void TearDown()
        {
        }
    }
}