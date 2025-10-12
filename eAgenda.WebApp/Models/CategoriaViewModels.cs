using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models
{
    public class VisualizarCategoriaViewModel
    {
        public List<DetalhesCategoriaViewModel> Categorias { get; set; }

        public VisualizarCategoriaViewModel()
        {
            Categorias = new List<DetalhesCategoriaViewModel>();
        }

        public VisualizarCategoriaViewModel(List<Categoria> categorias)
        {
            Categorias = categorias.Select(x => new DetalhesCategoriaViewModel(x.Id, x.Titulo, x.Despesas.Count())).ToList();
        }
    }

    public class DetalhesCategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int QtdDespesas { get; set; }

        public DetalhesCategoriaViewModel() { }

        public DetalhesCategoriaViewModel(Guid id, string titulo, int qtdDespesas)
        {
            Id = id;
            Titulo = titulo;
            QtdDespesas = qtdDespesas;
        }
    }

    public class CadastrarCategoriaViewModel
    {
        [Required(ErrorMessage = "O título da categoria é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "O título da categoria deve conter no máximo 100 caracteres!")]
        public string Titulo { get; set; }

        public CadastrarCategoriaViewModel() { }

        public CadastrarCategoriaViewModel(string titulo)
        {
            Titulo = titulo;
        }
    }

    public class EditarCategoriaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O título da categoria é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "O título da categoria deve conter no máximo 100 caracteres!")]
        public string Titulo { get; set; }

        public EditarCategoriaViewModel() { }

        public EditarCategoriaViewModel(Guid id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }
    }

    public class ExcluirCategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public ExcluirCategoriaViewModel() { }

        public ExcluirCategoriaViewModel(Guid id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }
    }

    public class DespesasCategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public List<DetalhesDespesaViewModel> Despesas { get; set; }
        public decimal ValorTotal { get; set; }

        public DespesasCategoriaViewModel() { }

        public DespesasCategoriaViewModel(Guid id, string titulo, List<Despesa> despesas)
        {
            Id = id;
            Titulo = titulo;
            Despesas = despesas.Select(x => new DetalhesDespesaViewModel(x.Id, x.Descricao, x.DataOcorrencia, x.Valor, x.FormaPagamento.ToString(), x.Categorias)).ToList();
            ValorTotal = Despesas.Select(x => x.Valor).Sum();
        }
    }
}