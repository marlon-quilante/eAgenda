using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infraestrutura.Orm.Compartilhado;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public interface IRepositorioTarefa : IRepositorio<Tarefa>
    {
        public void AtualizarPercentualConclusao(Guid id);
        public void Concluir(Guid id);
        public void DesfazerConclusao(Guid id);
    }
}
