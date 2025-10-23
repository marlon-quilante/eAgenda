using eAgenda.Dominio.ModuloContato;
using eAgenda.Testes.Integracao.Compartilhado;

namespace eAgenda.Testes.Integracao.ModuloContato
{
    [TestClass]
    [TestCategory("Testes de Integração de Contatos")]
    public sealed class RepositorioContatoTestes : TestFixture
    {
        [TestMethod]
        public void Deve_CadastrarRegistro_ComSucesso()
        {
            Contato contato = new Contato("Teste", "(49) 99999-9999", "teste@teste.com", "Empresa Teste", "Cargo Teste");

            repositorioContato?.Cadastrar(contato);

            Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(contato.Id);

            // Asserção
            Assert.AreEqual(contato, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_RetornarNulo_Ao_SelecionarRegistroPorId_ComIdErrado()
        {
            Contato contato = new Contato("Teste", "(49) 99999-9999", "teste@teste.com", "Empresa Teste", "Cargo Teste");

            repositorioContato?.Cadastrar(contato);

            Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(Guid.NewGuid());

            // Asserção
            Assert.AreNotEqual(contato, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_EditarRegistro_ComSucesso()
        {
            // Padrão AAA

            // Arranjo
            Contato contatoOriginal = new Contato("Teste", "(49) 99999-9999", "teste@teste.com", "Empresa Teste", "Cargo Teste");

            repositorioContato?.Cadastrar(contatoOriginal);

            Contato contatoEditado = new Contato("Teste Editado", "(49) 11111-1111", "testeeditado@teste.com", "Empresa Teste Editada", "Cargo Teste Editado");
            contatoEditado.Id = contatoOriginal.Id;

            // Ação
            repositorioContato?.Editar(contatoOriginal.Id, contatoEditado);

            // Asserção
            Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(contatoOriginal.Id);

            Assert.AreEqual(contatoOriginal, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_ExcluirRegistro_ComSucesso()
        {
            // Arranjo
            Contato contatoOriginal = new Contato("Teste", "(49) 99999-9999", "teste@teste.com", "Empresa Teste", "Cargo Teste");

            repositorioContato?.Cadastrar(contatoOriginal);
            // Ação
            repositorioContato?.Excluir(contatoOriginal.Id);

            // Asserção
            Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(contatoOriginal.Id);

            Assert.IsNull(contatoSelecionado);
        }
    }
}
