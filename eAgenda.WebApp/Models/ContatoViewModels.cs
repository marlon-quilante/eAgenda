using eAgenda.Dominio.ModuloContato;
using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models
{
    public class VisualizarContatosViewModel
    {
        public List<DetalhesContatoViewModel> Contatos { get; set; }

        public VisualizarContatosViewModel(List<Contato> contatos)
        {
            Contatos = contatos.Select(x => new DetalhesContatoViewModel(x.Id, x.Nome, x.Telefone, x.Email, x.Empresa, x.Cargo)).ToList();
        }
    }

    public class DetalhesContatoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }

        public DetalhesContatoViewModel() { }

        public DetalhesContatoViewModel(Guid id, string nome, string telefone, string email, string empresa, string cargo)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Empresa = empresa;
            Cargo = cargo;
        }
    }

    public class CadastrarContatoViewModel
    {
        [Required(ErrorMessage = "O nome do contato é um campo obrigatório!")]
        [MinLength(2, ErrorMessage = "O nome do contato deve conter no mínimo 2 caracteres!")]
        [MaxLength(100, ErrorMessage = "O nome do contato deve conter no máximo 100 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone do contato é um campo obrigatório!")]
        [Phone(ErrorMessage = "O telefone do contato não está em um formato válido!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O email do contato é um campo obrigatório!")]
        [EmailAddress(ErrorMessage = "O email do contato não está em um formato válido!")]
        public string Email { get; set; }

        [MaxLength(150, ErrorMessage = "A empresa do contato deve conter no máximo 150 caracteres!")]
        public string Empresa { get; set; }

        [MaxLength(150, ErrorMessage = "O cargo do contato deve conter no máximo 150 caracteres!")]
        public string Cargo { get; set; }

        public CadastrarContatoViewModel() { }

        public CadastrarContatoViewModel(string nome, string telefone, string email, string empresa, string cargo)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Empresa = empresa;
            Cargo = cargo;
        }
    }

    public class EditarContatoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do contato é um campo obrigatório!")]
        [MinLength(2, ErrorMessage = "O nome do contato deve conter no mínimo 2 caracteres!")]
        [MaxLength(100, ErrorMessage = "O nome do contato deve conter no máximo 100 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone do contato é um campo obrigatório!")]
        [Phone(ErrorMessage = "O telefone do contato não está em um formato válido!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O email do contato é um campo obrigatório!")]
        [EmailAddress(ErrorMessage = "O email do contato não está em um formato válido!")]
        public string Email { get; set; }

        [MaxLength(150, ErrorMessage = "A empresa do contato deve conter no máximo 150 caracteres!")]
        public string Empresa { get; set; }

        [MaxLength(150, ErrorMessage = "O cargo do contato deve conter no máximo 150 caracteres!")]
        public string Cargo { get; set; }

        public EditarContatoViewModel() { }

        public EditarContatoViewModel(Guid id, string nome, string telefone, string email, string empresa, string cargo)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Empresa = empresa;
            Cargo = cargo;
        }
    }

    public class ExcluirContatoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ExcluirContatoViewModel() { }

        public ExcluirContatoViewModel(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
