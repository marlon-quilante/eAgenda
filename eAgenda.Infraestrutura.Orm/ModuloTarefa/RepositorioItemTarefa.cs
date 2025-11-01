using eAgenda.Dominio.ModuloTarefa;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class RepositorioItemTarefa : IRepositorioItemTarefa
    {
        private readonly AppDbContext context;
        private readonly IRepositorioTarefa repositorioTarefa;

        public RepositorioItemTarefa(AppDbContext context, IRepositorioTarefa repositorioTarefa)
        {
            this.context = context;
            this.repositorioTarefa = repositorioTarefa;
        }

        public void Cadastrar(ItemTarefa novoItem, Guid idTarefa)
        {
            Tarefa tarefa = repositorioTarefa.SelecionarRegistroPorId(idTarefa);

            tarefa.ItensTarefa.Add(novoItem);

            context.ItensTarefa.Add(novoItem);

            context.SaveChanges();

            repositorioTarefa.AtualizarPercentualConclusao(tarefa.Id);
        }

        public void Excluir(Guid idParaDeletar)
        {
            ItemTarefa itemTarefa = SelecionarItemPorId(idParaDeletar);
            Tarefa tarefa = itemTarefa.Tarefa;

            if (itemTarefa is null) return;

            context.ItensTarefa.Remove(itemTarefa);
            context.SaveChanges();

            repositorioTarefa.AtualizarPercentualConclusao(tarefa.Id);
        }

        public ItemTarefa? SelecionarItemPorId(Guid id)
        {
            return context.ItensTarefa.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<ItemTarefa>? SelecionarItensTarefa(Guid idTarefa)
        {
            return context.ItensTarefa.Where(x => x.Tarefa.Id.Equals(idTarefa)).ToList();
        }

        public void Concluir(Guid idItem)
        {
            ItemTarefa itemTarefa = SelecionarItemPorId(idItem);
            Tarefa tarefa = itemTarefa.Tarefa;

            if (itemTarefa is null) return;

            itemTarefa.StatusConclusao = true;

            context.SaveChanges();

            repositorioTarefa.AtualizarPercentualConclusao(tarefa.Id);
        }
    }
}
