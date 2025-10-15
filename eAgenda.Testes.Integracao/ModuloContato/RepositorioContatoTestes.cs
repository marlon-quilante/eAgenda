using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloContato;

namespace eAgenda.Testes.Integracao.ModuloContato
{
    [TestClass]
    public sealed class RepositorioContatoTestes
    {
        private static readonly AppDbContext context = AppDbContextFactory.CriarDbContext("Data source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgenda;Integrated Security=True;");
        private static RepositorioContato repositorioContato = new RepositorioContato(context);

        [TestMethod]
        public void Deve_CadastrarRegistro_ComSucesso()
        {
            Contato contato = new Contato("Teste", "(49) 99999-9999", "teste@teste.com", "Empresa Teste", "Cargo Teste");

            repositorioContato.Cadastrar(contato);

            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contato.Id);

            // Asserção
            Assert.AreEqual(contato, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_RetornarNulo_Ao_SelecionarRegistroPorId_ComIdErrado()
        {
            Contato contato = new Contato("Teste", "(49) 99999-9999", "teste@teste.com", "Empresa Teste", "Cargo Teste");

            repositorioContato.Cadastrar(contato);

            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(Guid.NewGuid());

            // Asserção
            Assert.AreNotEqual(contato, contatoSelecionado);
        }
    }
}
