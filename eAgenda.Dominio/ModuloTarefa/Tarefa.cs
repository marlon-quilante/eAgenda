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
            Id = Guid.NewGuid();
        }

        public void MarcarConcluido()
        {
            StatusConclusao = true;
            DataConclusao = DateTime.Now;
        }

        public void MarcarPendente()
        {
            StatusConclusao = false;
            DataConclusao = null;
        }

        public void AtualizarPercentualConclusao()
        {
            decimal qtdItensTotal = ItensTarefa.Count();
            decimal qtdItensConcluidos = ItensTarefa.Where(x => x.StatusConclusao == true).Count();

            if (qtdItensTotal == 0)
            {
                PercentualConclusao = 0;
                return;
            }

            decimal percentualConclusao = (qtdItensConcluidos / qtdItensTotal) * 100;

            PercentualConclusao = percentualConclusao;
        }
    }
}
