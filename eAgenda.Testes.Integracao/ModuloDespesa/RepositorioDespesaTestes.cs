using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Testes.Integracao.Compartilhado;
using FizzWare.NBuilder;

namespace eAgenda.Testes.Integracao.ModuloDespesa
{
    [TestClass]
    [TestCategory("Testes de Integração de Despesas")]
    public class RepositorioDespesaTestes : TestFixture
    {
        [TestMethod]
        public void Deve_CadastrarRegistro_ComSucesso()
        {
            // Arrange

            Despesa despesa = new Despesa("Despesa Teste", DateTime.Now, 10.50m, FormaPagamento.Credito, new List<Categoria>());

            Categoria categoria = Builder<Categoria>.CreateNew().Build();

            despesa.Categorias.Add(categoria);

            // Act
            repositorioDespesa?.Cadastrar(despesa);

            // Assert
            Despesa? despesaSelecionada = repositorioDespesa?.SelecionarRegistroPorId(despesa.Id);

            Assert.AreEqual(despesa, despesaSelecionada);
        }

        [TestMethod]
        public void Deve_EditarRegistro_ComSucesso()
        {
            // Arrange

            Despesa despesaOriginal = new Despesa("Despesa Teste", DateTime.Now, 10.50m, FormaPagamento.Credito, new List<Categoria>());

            Categoria categoria = Builder<Categoria>.CreateNew().Build();

            despesaOriginal.Categorias.Add(categoria);

            repositorioDespesa?.Cadastrar(despesaOriginal);

            Despesa despesaEditada = new Despesa("Despesa Teste Editado", DateTime.Now, 15.50m, FormaPagamento.Debito, new List<Categoria>());

            despesaEditada.Categorias.Add(categoria);

            // Act
            repositorioDespesa?.Editar(despesaOriginal.Id, despesaEditada);

            // Assert
            Despesa? despesaSelecionada = repositorioDespesa?.SelecionarRegistroPorId(despesaOriginal.Id);

            Assert.AreEqual(despesaOriginal, despesaSelecionada);
        }

        [TestMethod]
        public void Deve_ExcluirRegistro_ComSucesso()
        {
            // Arrange

            Despesa despesa = new Despesa("Despesa Teste", DateTime.Now, 10.50m, FormaPagamento.Credito, new List<Categoria>());

            Categoria categoria = Builder<Categoria>.CreateNew().Build();

            despesa.Categorias.Add(categoria);

            // Act
            repositorioDespesa?.Excluir(despesa.Id);

            // Assert
            Despesa? despesaSelecionada = repositorioDespesa?.SelecionarRegistroPorId(despesa.Id);

            Assert.IsNull(despesaSelecionada);
        }
    }
}
