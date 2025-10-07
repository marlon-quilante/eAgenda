using eAgenda.Dominio.ModuloCategoria;
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
            Categorias = categorias.Select(x => new DetalhesCategoriaViewModel(x.Id, x.Titulo)).ToList();
        }
    }

    public class DetalhesCategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public DetalhesCategoriaViewModel() { }

        public DetalhesCategoriaViewModel(Guid id, string titulo)
        {
            Id = id;
            Titulo = titulo;
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
}
