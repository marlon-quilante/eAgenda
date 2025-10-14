using eAgenda.Dominio.Compartilhado;

namespace eAgenda.Dominio.ModuloTarefa
{
    public class Tarefa : EntidadeBase<Tarefa>
    {
        public string Titulo { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public bool StatusConclusao { get; set; }
        public decimal PercentualConclusao { get; set; }
        public List<ItemTarefa> ItensTarefa = new List<ItemTarefa>();

        public Tarefa() { }

        public Tarefa(string titulo, PrioridadeTarefa prioridade)
        {
            Titulo = titulo;
            Prioridade = prioridade;
            DataCriacao = DateTime.Now;
            DataConclusao = null;
            StatusConclusao = false;
            PercentualConclusao = 0;
        }
    }
}
