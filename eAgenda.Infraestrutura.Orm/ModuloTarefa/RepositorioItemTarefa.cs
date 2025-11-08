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

        public ItemTarefa? SelecionarItemPorId(Guid id)
        {
            return context.ItensTarefa.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<ItemTarefa>? SelecionarItensTarefa(Guid idTarefa)
        {
            return context.ItensTarefa.Where(x => x.Tarefa.Id.Equals(idTarefa)).ToList();
        }
    }
}
