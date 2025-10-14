using eAgenda.Dominio.ModuloTarefa;
using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models
{
    public class VisualizarTarefasViewModel
    {
        public List<DetalhesTarefaViewModel> Tarefas { get; set; }

        public VisualizarTarefasViewModel()
        {
            Tarefas = new List<DetalhesTarefaViewModel>();
        }

        public VisualizarTarefasViewModel(List<Tarefa> tarefas)
        {
            Tarefas = tarefas.Select(x => new DetalhesTarefaViewModel(x.Id, x.Titulo, x.Prioridade, x.DataCriacao, x.DataConclusao, x.StatusConclusao, x.PercentualConclusao, x.ItensTarefa)).ToList();
        }
    }

    public class DetalhesTarefaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public bool StatusConclusao { get; set; }
        public decimal PercentualConclusao { get; set; }
        public List<ItemTarefa> ItensTarefa { get; set; }

        public DetalhesTarefaViewModel() { }

        public DetalhesTarefaViewModel(Guid id, string titulo, PrioridadeTarefa prioridade, DateTime dataCriacao, DateTime? dataConclusao, bool statusConclusao, decimal percentualConclusao, List<ItemTarefa> itensTarefa)
        {
            Id = id;
            Titulo = titulo;
            Prioridade = prioridade;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            StatusConclusao = statusConclusao;
            PercentualConclusao = percentualConclusao;
            ItensTarefa = itensTarefa;
        }
    }

    public class CadastrarTarefaViewModel
    {
        [Required(ErrorMessage = "O título da tarefa é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "O título da tarefa deve conter no máximo 100 caracteres!")]
        public string Titulo { get; set; }

        public PrioridadeTarefa Prioridade { get; set; }

        [Required(ErrorMessage = "A data de criação da tarefa é um campo obrigatório!")]
        public DateTime DataCriacao { get; set; }

        public CadastrarTarefaViewModel() { }

        public CadastrarTarefaViewModel(string titulo, PrioridadeTarefa prioridade, DateTime dataCriacao)
        {
            Titulo = titulo;
            Prioridade = prioridade;
            DataCriacao = dataCriacao;
        }
    }

    public class EditarTarefaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O título da tarefa é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "O título da tarefa deve conter no máximo 100 caracteres!")]
        public string Titulo { get; set; }

        public PrioridadeTarefa Prioridade { get; set; }

        public EditarTarefaViewModel() { }

        public EditarTarefaViewModel(Guid id, string titulo, PrioridadeTarefa prioridade)
        {
            Id = id;
            Titulo = titulo;
            Prioridade = prioridade;
        }
    }

    public class ExcluirTarefaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public ExcluirTarefaViewModel() { }

        public ExcluirTarefaViewModel(Guid id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }
    }

    public class DetalhesItensTarefaViewModel
    {
        public List<ItemTarefa> ItensTarefa { get; set; }
        public string TituloTarefa { get; set; }
        public Guid TarefaId { get; set; }
        public string TituloItem { get; set; }
        public bool StatusConclusaoItem { get; set; }
        public decimal PercentualConclusaoTarefa { get; set; }
        public bool StatusConclusaoTarefa { get; set; }

        public DetalhesItensTarefaViewModel() { }

        public DetalhesItensTarefaViewModel(List<ItemTarefa> itensTarefa, string tituloTarefa, Guid tarefaId, bool statusConclusaoItem, decimal percentualConclusaoTarefa, bool statusConclusaoTarefa)
        {
            ItensTarefa = itensTarefa;
            TituloTarefa = tituloTarefa;
            TarefaId = tarefaId;
            StatusConclusaoItem = statusConclusaoItem;
            PercentualConclusaoTarefa = percentualConclusaoTarefa;
            StatusConclusaoTarefa = statusConclusaoTarefa;
        }
    }

    public class AdicionarItemTarefaViewModel
    {
        public Guid TarefaId { get; set; }

        [Required(ErrorMessage = "O título do item é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "O título do item deve conter no máximo 100 caracteres!")]
        public string TituloItem { get; set; }

        public AdicionarItemTarefaViewModel() { }

        public AdicionarItemTarefaViewModel(Guid tarefaId, string tituloItem)
        {
            TarefaId = tarefaId;
            TituloItem = tituloItem;
        }
    }

    public class RemoverItemTarefaViewModel
    {
        public Guid Id { get; set; }

        public RemoverItemTarefaViewModel() { }

        public RemoverItemTarefaViewModel(Guid id)
        {
            Id = id;
        }
    }
}
