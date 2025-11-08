using eAgenda.Dominio.ModuloTarefa;

namespace eAgenda.Testes.Unidade.ModuloTarefa
{
    [TestClass]
    [TestCategory("Testes de Unidade de Tarefa")]
    public sealed class TarefaTestes
    {
        [TestMethod]
        public void Deve_MarcarConcluido_ComSucesso()
        {
            // Arranjo
            Tarefa tarefa = new Tarefa("Tarefa teste", PrioridadeTarefa.Alta);

            // Ação
            tarefa.MarcarConcluido();

            // Asserção
            Assert.IsTrue(tarefa.StatusConclusao);
            Assert.IsNotNull(tarefa.DataConclusao);
        }

        [TestMethod]
        public void Deve_MarcarPendente_ComSucesso()
        {
            // Arranjo
            Tarefa tarefa = new Tarefa("Tarefa teste", PrioridadeTarefa.Normal);
            tarefa.MarcarConcluido();

            // Ação
            tarefa.MarcarPendente();

            // Asserção
            Assert.IsFalse(tarefa.StatusConclusao);
            Assert.IsNull(tarefa.DataConclusao);
        }

        [TestMethod]
        public void Deve_AdicionarItem_ComSucesso()
        {
            // Arranjo
            Tarefa tarefa = new Tarefa("Tarefa teste", PrioridadeTarefa.Normal);
            ItemTarefa item = new ItemTarefa("Item teste", tarefa);

            // Ação
            tarefa.AdicionarItem(item);

            // Asserção
            Assert.IsTrue(tarefa.ItensTarefa.Any());
        }

        [TestMethod]
        public void Deve_RemoverItem_ComSucesso()
        {
            // Arranjo
            Tarefa tarefa = new Tarefa("Tarefa teste", PrioridadeTarefa.Normal);
            ItemTarefa item = new ItemTarefa("Item teste", tarefa);
            tarefa.AdicionarItem(item);

            // Ação
            tarefa.RemoverItem(item);

            // Asserção
            Assert.IsFalse(tarefa.ItensTarefa.Any());
        }

        [TestMethod]
        public void Deve_AtualizarPercentualConclusao_ComSucesso()
        {
            // Arranjo
            Tarefa tarefa = new Tarefa("Tarefa teste", PrioridadeTarefa.Normal);
            ItemTarefa item1 = new ItemTarefa("Item teste 1", tarefa);
            ItemTarefa item2 = new ItemTarefa("Item teste 2", tarefa);

            tarefa.AdicionarItem(item1);
            tarefa.AdicionarItem(item2);
            item1.MarcarConcluido();

            // Ação
            tarefa.AtualizarPercentualConclusao();

            // Asserção
            Assert.IsTrue(tarefa.PercentualConclusao == 50);
        }
    }
}
