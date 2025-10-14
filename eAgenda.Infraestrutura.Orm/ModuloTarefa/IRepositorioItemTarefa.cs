using eAgenda.Dominio.ModuloTarefa;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public interface IRepositorioItemTarefa
    {
        public void Cadastrar(ItemTarefa novoItem, Guid idTarefa);

        public void Concluir(Guid idItem);

        public void Excluir(Guid idParaDeletar);

        public ItemTarefa? SelecionarItemPorId(Guid id);

        public List<ItemTarefa>? SelecionarItensTarefa(Guid idTarefa);
    }
}
