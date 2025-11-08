using eAgenda.Dominio.ModuloTarefa;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public interface IRepositorioItemTarefa
    {
        public ItemTarefa? SelecionarItemPorId(Guid id);

        public List<ItemTarefa>? SelecionarItensTarefa(Guid idTarefa);
    }
}
