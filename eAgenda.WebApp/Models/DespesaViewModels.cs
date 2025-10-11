using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloDespesa;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models
{
    public class VisualizarDespesasViewModel
    {
        public List<DetalhesDespesaViewModel> Despesas { get; set; }

        public VisualizarDespesasViewModel()
        {
            Despesas = new List<DetalhesDespesaViewModel>(); 
        }

        public VisualizarDespesasViewModel(List<Despesa> despesas)
        {
            Despesas = despesas.Select(x => new DetalhesDespesaViewModel(x.Id, x.Descricao, x.DataOcorrencia, x.Valor, x.FormaPagamento.ToString(), x.Categorias)).ToList();
        }
    }

    public class DetalhesDespesaViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public decimal Valor { get; set; }
        public string FormaPagamento { get; set; }
        public List<Categoria> Categorias { get; set; }

        public DetalhesDespesaViewModel() { }

        public DetalhesDespesaViewModel(Guid id, string descricao, DateTime dataOcorrencia, decimal valor, string formaPagamento, List<Categoria> categorias)
        {
            Id = id;
            Descricao = descricao;
            DataOcorrencia = dataOcorrencia;
            Valor = valor;
            FormaPagamento = formaPagamento;
            Categorias = categorias;
        }
    }

    public class CadastrarDespesaViewModel
    {
        [Required(ErrorMessage = "A descrição da despesa é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "A descrição da despesa deve conter no máximo 100 caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de ocorrência da despesa é um campo obrigatório!")]
        public DateTime DataOcorrencia { get; set; }

        [Required(ErrorMessage = "O valor da despesa é um campo obrigatório!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A forma de pagamento é um campo obrigatório!")]
        public FormaPagamento FormaPagamento { get; set; }

        [ValidateNever]
        public List<SelectListItem> FormasPagamentoDisponiveis { get; set; }

        [ValidateNever]
        public List<Categoria> CategoriasDisponiveis { get; set; }

        [ValidateNever]
        public List<Guid> CategoriasSelecionadas { get; set; }

        public CadastrarDespesaViewModel() { }

        public CadastrarDespesaViewModel(List<Categoria> categorias)
        {
            CategoriasDisponiveis = categorias.Select(x => new Categoria(x.Id, x.Titulo)).ToList();
            FormasPagamentoDisponiveis = Enum.GetValues(typeof(FormaPagamento)).Cast<FormaPagamento>().Select(x => new SelectListItem(x.ToString(), ((int)x).ToString())).ToList();
            CategoriasSelecionadas = new List<Guid>();
        }

        public CadastrarDespesaViewModel(string descricao, DateTime dataOcorrencia, decimal valor)
        {
            Descricao = descricao;
            DataOcorrencia = dataOcorrencia;
            Valor = valor;
        }
    }

    public class EditarDespesaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A descrição da despesa é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "A descrição da despesa deve conter no máximo 100 caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de ocorrência da despesa é um campo obrigatório!")]
        public DateTime DataOcorrencia { get; set; }

        [Required(ErrorMessage = "O valor da despesa é um campo obrigatório!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A forma de pagamento é um campo obrigatório!")]
        public FormaPagamento FormaPagamento { get; set; }

        [ValidateNever]
        public List<SelectListItem> FormasPagamentoDisponiveis { get; set; }

        [ValidateNever]
        public List<Categoria> CategoriasDisponiveis { get; set; }

        [ValidateNever]
        public List<Guid> CategoriasSelecionadas { get; set; }

        public EditarDespesaViewModel() { }

        public EditarDespesaViewModel(Guid id, string descricao, DateTime dataOcorrencia, decimal valor, List<Categoria> categoriasDisponiveis, List<Categoria> categoriasSelecionadas)
        {
            Id = id;
            Descricao = descricao;
            DataOcorrencia = dataOcorrencia;
            Valor = valor;

            CategoriasDisponiveis = categoriasDisponiveis.Select(x => new Categoria(x.Id, x.Titulo)).ToList();
            FormasPagamentoDisponiveis = Enum.GetValues(typeof(FormaPagamento)).Cast<FormaPagamento>().Select(x => new SelectListItem(x.ToString(), ((int)x).ToString())).ToList();
            CategoriasSelecionadas = categoriasSelecionadas.Select(x => x.Id).ToList();
        }
    }

    public class ExcluirDespesaViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public ExcluirDespesaViewModel(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
