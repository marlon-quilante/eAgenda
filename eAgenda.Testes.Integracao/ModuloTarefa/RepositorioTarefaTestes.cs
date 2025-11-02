using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Testes.Integracao.Compartilhado;

namespace eAgenda.Testes.Integracao.ModuloTarefa
{
    [TestClass]
    [TestCategory("Testes de Integração de Tarefas")]
    public class RepositorioTarefaTestes : TestFixture
    {
        [TestMethod]
        public void Deve_CadastrarRegistro_ComSucesso()
        {
            // Arrange
            Tarefa tarefa = new Tarefa("Tarefa Teste", PrioridadeTarefa.Baixa);

            // Act
            repositorioTarefa?.Cadastrar(tarefa);

            // Assert
            Tarefa? tarefaSelecionada = repositorioTarefa?.SelecionarRegistroPorId(tarefa.Id);

            Assert.AreEqual(tarefa, tarefaSelecionada);
        }

        [TestMethod]
        public void Deve_EditarRegistro_ComSucesso()
        {
            // Arrange
            Tarefa tarefaOriginal = new Tarefa("Tarefa Teste", PrioridadeTarefa.Baixa);

            repositorioTarefa?.Cadastrar(tarefaOriginal);

            Tarefa tarefaEditada = new Tarefa("Tarefa Teste Editada", PrioridadeTarefa.Normal);

            // Act
            repositorioTarefa?.Editar(tarefaOriginal.Id, tarefaEditada);

            // Assert
            Tarefa? tarefaSelecionada = repositorioTarefa?.SelecionarRegistroPorId(tarefaOriginal.Id);

            Assert.AreEqual(tarefaOriginal, tarefaSelecionada);
        }

        [TestMethod]
        public void Deve_ExcluirRegistro_ComSucesso()
        {
            // Arrange
            Tarefa tarefa = new Tarefa("Tarefa Teste", PrioridadeTarefa.Baixa);

            // Act
            repositorioTarefa?.Excluir(tarefa.Id);

            // Assert
            Tarefa? tarefaSelecionada = repositorioTarefa?.SelecionarRegistroPorId(tarefa.Id);

            Assert.IsNull(tarefaSelecionada);
        }

        [TestMethod]
        public void Deve_SelecionarTarefasConcluidas_ComSucesso()
        {
            // Arrange
            Tarefa tarefa = new Tarefa("Tarefa Teste", PrioridadeTarefa.Baixa);
            Tarefa tarefa2 = new Tarefa("Tarefa Teste 2", PrioridadeTarefa.Normal);
            Tarefa tarefa3 = new Tarefa("Tarefa Teste 3", PrioridadeTarefa.Alta);

            repositorioTarefa?.Cadastrar(tarefa);
            repositorioTarefa?.Cadastrar(tarefa2);
            repositorioTarefa?.Cadastrar(tarefa3);

            repositorioTarefa?.Concluir(tarefa2.Id);

            // Act
            List<Tarefa>? tarefasSelecionadas = repositorioTarefa?.SelecionarRegistros()?.Where(x => x.StatusConclusao == true).ToList();

            // Assert
            List<Tarefa>? tarefasOriginais = [tarefa, tarefa2, tarefa3];

            Assert.IsTrue(tarefasSelecionadas?.All(t => t.StatusConclusao == true));
            CollectionAssert.AreNotEqual(tarefasOriginais, tarefasSelecionadas);
        }

        [TestMethod]
        public void Deve_SelecionarTarefasPendentes_ComSucesso()
        {
            // Arrange
            Tarefa tarefa = new Tarefa("Tarefa Teste", PrioridadeTarefa.Baixa);
            Tarefa tarefa2 = new Tarefa("Tarefa Teste 2", PrioridadeTarefa.Normal);
            Tarefa tarefa3 = new Tarefa("Tarefa Teste 3", PrioridadeTarefa.Alta);

            repositorioTarefa?.Cadastrar(tarefa);
            repositorioTarefa?.Cadastrar(tarefa2);
            repositorioTarefa?.Cadastrar(tarefa3);

            repositorioTarefa?.Concluir(tarefa2.Id);

            // Act
            List<Tarefa>? tarefasSelecionadas = repositorioTarefa?.SelecionarRegistros()?.Where(x => x.StatusConclusao == false).ToList();

            // Assert
            List<Tarefa>? tarefasOriginais = [tarefa, tarefa2, tarefa3];

            Assert.IsTrue(tarefasSelecionadas?.All(t => t.StatusConclusao == false));
            CollectionAssert.AreNotEqual(tarefasOriginais, tarefasSelecionadas);
        }

        [TestMethod]
        public void Deve_SelecionarTarefas_ComSucesso()
        {
            // Arrange
            Tarefa tarefa = new Tarefa("Tarefa Teste", PrioridadeTarefa.Baixa);
            Tarefa tarefa2 = new Tarefa("Tarefa Teste 2", PrioridadeTarefa.Normal);
            Tarefa tarefa3 = new Tarefa("Tarefa Teste 3", PrioridadeTarefa.Alta);

            repositorioTarefa?.Cadastrar(tarefa);
            repositorioTarefa?.Cadastrar(tarefa2);
            repositorioTarefa?.Cadastrar(tarefa3);

            // Act
            List<Tarefa>? tarefasSelecionadas = repositorioTarefa?.SelecionarRegistros();

            // Assert
            CollectionAssert.AllItemsAreNotNull(tarefasSelecionadas);
        }
    }
}
