using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.ModuloCompromisso;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloDespesa;
using eAgenda.Infraestrutura.Orm.ModuloTarefa;
using Microsoft.Extensions.Configuration;

namespace eAgenda.Testes.Integracao.Compartilhado
{
    [TestClass]
    public abstract class TestFixture
    {
        protected AppDbContext context;
        
        protected RepositorioContato? repositorioContato;
        protected RepositorioCompromisso? repositorioCompromisso;
        protected RepositorioCategoria? repositorioCategoria;
        protected RepositorioDespesa? repositorioDespesa;
        protected RepositorioTarefa? repositorioTarefa;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            var assembly = typeof(TestFixture).Assembly;

            IConfiguration configuration = new ConfigurationBuilder().AddUserSecrets(assembly).AddEnvironmentVariables().Build();

            string? connectionString = configuration["SQL_CONNECTION_STRING"];

            if (string.IsNullOrWhiteSpace(connectionString)) 
                throw new Exception("A variável \"SQL_CONNECTION_STRING\" não foi informada.");

            context = AppDbContextFactory.CriarDbContext(connectionString);

            context.Database.EnsureCreated();

            context.Tarefas.RemoveRange(context.Tarefas);
            context.Despesas.RemoveRange(context.Despesas);
            context.Categorias.RemoveRange(context.Categorias);
            context.Compromissos.RemoveRange(context.Compromissos);
            context.Contatos.RemoveRange(context.Contatos);

            context.SaveChanges();

            repositorioContato = new RepositorioContato(context);
            repositorioCompromisso = new RepositorioCompromisso(context);
            repositorioCategoria = new RepositorioCategoria(context);
            repositorioDespesa = new RepositorioDespesa(context);
            repositorioTarefa = new RepositorioTarefa(context);
        }
    }
}
