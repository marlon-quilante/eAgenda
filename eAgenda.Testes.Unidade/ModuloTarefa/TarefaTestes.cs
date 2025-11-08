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
    }
}
