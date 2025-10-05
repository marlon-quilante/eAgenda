using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models
{
    public class VisualizarCompromissoViewModel
    {
        public List<DetalhesCompromissoViewModel> Compromissos { get; set; }

        public VisualizarCompromissoViewModel() { }

        public VisualizarCompromissoViewModel(List<Compromisso> compromissos)
        {
            Compromissos = compromissos.Select(x => new DetalhesCompromissoViewModel(x.Id, x.Assunto, x.Data, x.HoraInicio, x.HoraTermino, x.Tipo, x.Link, x.Local, x.Contato)).ToList();
        }
    }

    public class DetalhesCompromissoViewModel
    {
        public Guid Id { get; set; }
        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public TipoCompromisso Tipo { get; set; }
        public string Link { get; set; }
        public string Local { get; set; }
        public Contato Contato { get; set; }

        public DetalhesCompromissoViewModel() { }

        public DetalhesCompromissoViewModel(Guid id, string assunto, DateTime data, TimeSpan horaInicio, TimeSpan horaTermino, TipoCompromisso tipo, string link, string local, Contato contato)
        {
            Id = id;
            Assunto = assunto;
            Data = data;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            Tipo = tipo;
            Link = link;
            Local = local;
            Contato = contato;
        }
    }

    public class CadastrarCompromissoViewModel
    {
        [Required(ErrorMessage = "O assunto do compromisso é um campo obrigatório!")]
        [MaxLength(150, ErrorMessage = "O assunto do compromisso deve conter no máximo 150 caracteres!")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "A data do compromisso é um campo obrigatório!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O horário de início do compromisso é um campo obrigatório!")]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "O horário de término do compromisso é um campo obrigatório!")]
        public TimeSpan HoraTermino { get; set; }
        [Required(ErrorMessage = "O tipo do compromisso é um campo obrigatório!")]
        public TipoCompromisso Tipo { get; set; }

        [MaxLength(250, ErrorMessage = "O local do compromisso deve conter no máximo 250 caracteres!")]
        public string? Local { get; set; }

        public string? Link { get; set; }
        public Guid? ContatoId { get; set; }

        [ValidateNever]
        public List<SelectListItem> ContatosDisponiveis { get; set; }
        [ValidateNever]
        public List<SelectListItem> TiposDisponiveis { get; set; }

        public CadastrarCompromissoViewModel() { }

        public CadastrarCompromissoViewModel(List<Contato> contatosDisponiveis) 
        {
            ContatosDisponiveis = contatosDisponiveis.Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            ContatosDisponiveis.Insert(0, new SelectListItem("Sem contato", ""));

            TiposDisponiveis = Enum.GetValues(typeof(TipoCompromisso)).Cast<TipoCompromisso>().Select(x => new SelectListItem(x.ToString(), ((int)x).ToString())).ToList();
        }
    }

    public class EditarCompromissoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O assunto do compromisso é um campo obrigatório!")]
        [MaxLength(150, ErrorMessage = "O assunto do compromisso deve conter no máximo 150 caracteres!")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "A data do compromisso é um campo obrigatório!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O horário de início do compromisso é um campo obrigatório!")]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "O horário de término do compromisso é um campo obrigatório!")]
        public TimeSpan HoraTermino { get; set; }

        [Required(ErrorMessage = "O tipo do compromisso é um campo obrigatório!")]
        public TipoCompromisso Tipo { get; set; }

        [MaxLength(250, ErrorMessage = "O local do compromisso deve conter no máximo 250 caracteres!")]
        public string? Local { get; set; }
        public string? Link { get; set; }

        [ValidateNever]
        public List<SelectListItem> ContatosDisponiveis { get; set; }
        [ValidateNever]
        public List<SelectListItem> TiposDisponiveis { get; set; }
        public Guid? ContatoId { get; set; }

        public EditarCompromissoViewModel() { }

        public EditarCompromissoViewModel(List<Contato> contatosDisponiveis)
        {
            ContatosDisponiveis = contatosDisponiveis.Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            ContatosDisponiveis.Insert(0, new SelectListItem("Sem contato", ""));

            TiposDisponiveis = Enum.GetValues(typeof(TipoCompromisso)).Cast<TipoCompromisso>().Select(x => new SelectListItem(x.ToString(), ((int)x).ToString())).ToList();
        }

        public EditarCompromissoViewModel(Guid id, string assunto, DateTime data, TimeSpan horaInicio, TimeSpan horaTermino, string local, string link, List<Contato> contatosDisponiveis, TipoCompromisso tipo, Guid contatoId)
        {
            Id = id;
            Assunto = assunto;
            Data = data;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            Local = local;
            Link = link;
            ContatosDisponiveis = contatosDisponiveis.Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            ContatosDisponiveis.Insert(0, new SelectListItem("Sem contato", ""));
            TiposDisponiveis = Enum.GetValues(typeof(TipoCompromisso)).Cast<TipoCompromisso>().Select(x => new SelectListItem(x.ToString(), ((int)x).ToString())).ToList();
            Tipo = tipo;
            ContatoId = contatoId;
        }
    }

    public class ExcluirCompromissoViewModel
    {
        public Guid Id { get; set; }
        public string Assunto { get; set; }

        public ExcluirCompromissoViewModel() { }

        public ExcluirCompromissoViewModel(Guid id, string assunto)
        {
            Id = id;
            Assunto = assunto;
        }
    }
}
