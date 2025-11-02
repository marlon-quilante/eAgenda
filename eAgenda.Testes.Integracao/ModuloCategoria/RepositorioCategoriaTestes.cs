using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Testes.Integracao.Compartilhado;

namespace eAgenda.Testes.Integracao.ModuloCategoria
{
    [TestClass]
    [TestCategory("Testes de Integração de Categoria")]
    public class RepositorioCategoriaTestes : TestFixture
    {
        [TestMethod]
        public void Deve_CadastrarRegistro_ComSucesso()
        {
            // Arranjo
            Categoria categoria = new Categoria("Categoria teste");

            // Ação
            repositorioCategoria?.Cadastrar(categoria);

            // Asserção
            Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(categoria.Id);

            Assert.AreEqual(categoria, categoriaSelecionada);
        }

        [TestMethod]
        public void Deve_RetornarNull_AoSelecionar_IdErrado()
        {
            // Arranjo
            Categoria categoria = new Categoria("Categoria teste");
            categoria.Id = Guid.NewGuid();

            repositorioCategoria?.Cadastrar(categoria);

            // Ação
            Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(Guid.NewGuid());

            // Asserção
            Assert.IsNull(categoriaSelecionada);
        }

        [TestMethod]
        public void Deve_EditarRegistro_ComSucesso()
        {
            // Arranjo
            Categoria categoriaOriginal = new Categoria("Categoria teste");

            repositorioCategoria?.Cadastrar(categoriaOriginal);

            // Ação
            Categoria categoriaEditada = new Categoria("Categoria teste editada");

            repositorioCategoria?.Editar(categoriaOriginal.Id, categoriaEditada);

            // Asserção
            Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(categoriaOriginal.Id);

            Assert.AreEqual(categoriaOriginal, categoriaSelecionada);
        }

        [TestMethod]
        public void Deve_ExcluirRegistro_ComSucesso()
        {
            // Arranjo
            Categoria categoria = new Categoria("Categoria teste");

            repositorioCategoria?.Cadastrar(categoria);

            // Ação
            repositorioCategoria?.Excluir(categoria.Id);

            // Asserção
            Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(categoria.Id);

            Assert.IsNull(categoriaSelecionada);
        }
    }
}
