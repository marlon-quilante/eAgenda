using eAgenda.Dominio.ModuloAutenticacao;
using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApp.Controllers
{
    [Authorize]
    [Route("contatos")]
    public class ContatoController : Controller
    {
        private readonly IRepositorioContato repositorioContato;
        private readonly ITenantProvider tenantProvider;

        public ContatoController(IRepositorioContato repositorioContato, ITenantProvider tenantProvider)
        {
            this.repositorioContato = repositorioContato;
            this.tenantProvider = tenantProvider;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Contato> contatos = repositorioContato.SelecionarRegistros();

            VisualizarContatosViewModel visualizarVM = new VisualizarContatosViewModel(contatos);

            return View(visualizarVM);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            CadastrarContatoViewModel cadastrarVM = new CadastrarContatoViewModel();

            return View(cadastrarVM);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(CadastrarContatoViewModel cadastrarVM)
        {
            if (!ModelState.IsValid)
                return View(cadastrarVM);

            Contato novoContato = new Contato(cadastrarVM.Nome, cadastrarVM.Telefone, cadastrarVM.Email, cadastrarVM.Empresa, cadastrarVM.Cargo);

            novoContato.UsuarioId = tenantProvider.UsuarioId.GetValueOrDefault();

            repositorioContato.Cadastrar(novoContato);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            Contato contato = repositorioContato.SelecionarRegistroPorId(id);

            EditarContatoViewModel editarVM = new EditarContatoViewModel(contato.Id, contato.Nome, contato.Telefone, contato.Email, contato.Empresa, contato.Cargo);

            return View(editarVM);
        }

        [HttpPost("editar/{id:guid}")]
        public IActionResult Editar(Guid id, EditarContatoViewModel editarVM)
        {
            if (!ModelState.IsValid)
                return View(editarVM);

            Contato contatoAtualizado = new Contato(editarVM.Nome, editarVM.Telefone, editarVM.Email, editarVM.Empresa, editarVM.Cargo);

            repositorioContato.Editar(id, contatoAtualizado);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            Contato contato = repositorioContato.SelecionarRegistroPorId(id);

            ExcluirContatoViewModel excluirVM = new ExcluirContatoViewModel(id, contato.Nome);

            return View(excluirVM);
        }

        [HttpPost("excluir/{id:guid}")]
        public IActionResult ExclusaoConfirmada(Guid id)
        {
            Contato contato = repositorioContato.SelecionarRegistroPorId(id);

            repositorioContato.Excluir(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
