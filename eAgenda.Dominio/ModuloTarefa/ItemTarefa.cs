using eAgenda.Dominio.Compartilhado;

namespace eAgenda.Dominio.ModuloTarefa
{
    public class ItemTarefa : EntidadeBase<ItemTarefa>
    {
        public string Titulo { get; set; }
        public bool StatusConclusao { get; set; }
        public Tarefa Tarefa { get; set; }

        public ItemTarefa() { }

        public ItemTarefa(string titulo, Tarefa tarefa)
        {
            Titulo = titulo;
            StatusConclusao = false;
            Tarefa = tarefa;
        }
    }
}
