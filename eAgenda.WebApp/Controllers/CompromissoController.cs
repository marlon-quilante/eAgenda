using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloCompromisso;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApp.Controllers
{
    [Route("Compromissos")]
    public class CompromissoController : Controller
    {
        private readonly IRepositorioCompromisso repositorioCompromisso;
        private readonly IRepositorioContato repositorioContato;

        public CompromissoController(IRepositorioCompromisso repositorioCompromisso, IRepositorioContato repositorioContato)
        {
            this.repositorioCompromisso = repositorioCompromisso;
            this.repositorioContato = repositorioContato;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Compromisso> compromissos = repositorioCompromisso.SelecionarRegistros();

            VisualizarCompromissoViewModel visualizarVM = new VisualizarCompromissoViewModel(compromissos);
            
            return View(visualizarVM);
        }

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar()
        {
            List<Contato> contatosDisponiveis = repositorioContato.SelecionarRegistros();

            CadastrarCompromissoViewModel cadastrarVM = new CadastrarCompromissoViewModel(contatosDisponiveis);

            return View(cadastrarVM);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(CadastrarCompromissoViewModel cadastrarVM)
        {
            if (!ModelState.IsValid)
            {
                List<Contato> contatosDisponiveis = repositorioContato.SelecionarRegistros();
                cadastrarVM = new CadastrarCompromissoViewModel(contatosDisponiveis);

                return View(cadastrarVM);
            }

            Contato contatoSelecionado = repositorioContato.SelecionarRegistroPorId(cadastrarVM.ContatoId.GetValueOrDefault());
            Compromisso novoCompromisso = new Compromisso(cadastrarVM.Assunto, cadastrarVM.Data, cadastrarVM.HoraInicio, cadastrarVM.HoraTermino, cadastrarVM.Tipo, cadastrarVM.Local, cadastrarVM.Link, contatoSelecionado);

            repositorioCompromisso.Cadastrar(novoCompromisso);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            Compromisso compromisso = repositorioCompromisso.SelecionarRegistroPorId(id);

            List<Contato> contatosDisponiveis = repositorioContato.SelecionarRegistros();

            if (compromisso.Contato is null)
            {
                Contato contato = new Contato();
                compromisso.Contato = contato;
            }

            EditarCompromissoViewModel editarVM = new EditarCompromissoViewModel(compromisso.Id, compromisso.Assunto, compromisso.Data, compromisso.HoraInicio, compromisso.HoraTermino, compromisso.Local, compromisso.Link, contatosDisponiveis, compromisso.Tipo, compromisso.Contato.Id);

            return View(editarVM);
        }

        [HttpPost("Editar/{id:guid}")]
        public IActionResult Editar(EditarCompromissoViewModel editarVM)
        {
            Contato contatoSelecionado = repositorioContato.SelecionarRegistroPorId(editarVM.ContatoId.GetValueOrDefault());
            Compromisso compromisso = repositorioCompromisso.SelecionarRegistroPorId(editarVM.Id);

            if (!ModelState.IsValid)
            {
                List<Contato> contatosDisponiveis = repositorioContato.SelecionarRegistros();
                compromisso = repositorioCompromisso.SelecionarRegistroPorId(editarVM.Id);
                editarVM = new EditarCompromissoViewModel(compromisso.Id, compromisso.Assunto, compromisso.Data, compromisso.HoraInicio, compromisso.HoraTermino, compromisso.Local, compromisso.Link, contatosDisponiveis, compromisso.Tipo, compromisso.Contato.Id);

                return View(editarVM);
            }

            Compromisso compromissoEditado = new Compromisso(editarVM.Assunto, editarVM.Data, editarVM.HoraInicio, editarVM.HoraTermino, editarVM.Tipo, editarVM.Local, editarVM.Link, contatoSelecionado);

            repositorioCompromisso.Editar(editarVM.Id, compromissoEditado);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            Compromisso compromisso = repositorioCompromisso.SelecionarRegistroPorId(id);

            ExcluirCompromissoViewModel excluirVM = new ExcluirCompromissoViewModel(id, compromisso.Assunto);

            return View(excluirVM);
        }

        [HttpPost("Excluir/{id:guid}")]
        public IActionResult ExclusaoConfirmada(Guid id)
        {
            repositorioCompromisso.Excluir(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
