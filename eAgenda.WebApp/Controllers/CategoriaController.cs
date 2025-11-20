using eAgenda.Dominio.ModuloAutenticacao;
using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.ModuloCategoria;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApp.Controllers
{
    [Authorize]
    [Route("categorias")]
    public class CategoriaController : Controller
    {
        private readonly IRepositorioCategoria repositorioCategoria;
        private readonly ITenantProvider tenantProvider;

        public CategoriaController(IRepositorioCategoria repositorioCategoria, ITenantProvider tenantProvider)
        {
            this.repositorioCategoria = repositorioCategoria;
            this.tenantProvider = tenantProvider;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Categoria> categorias = repositorioCategoria.SelecionarRegistros();

            VisualizarCategoriaViewModel visualizarVM = new VisualizarCategoriaViewModel(categorias);

            return View(visualizarVM);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            CadastrarCategoriaViewModel cadastrarVM = new CadastrarCategoriaViewModel();

            return View(cadastrarVM);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(CadastrarCategoriaViewModel cadastrarVM)
        {
            if (!ModelState.IsValid)
                return View(cadastrarVM);

            Categoria novaCategoria = new Categoria(cadastrarVM.Titulo);

            novaCategoria.UsuarioId = tenantProvider.UsuarioId.GetValueOrDefault();

            repositorioCategoria.Cadastrar(novaCategoria);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            Categoria categoria = repositorioCategoria.SelecionarRegistroPorId(id);

            EditarCategoriaViewModel editarVM = new EditarCategoriaViewModel(id, categoria.Titulo);

            return View(editarVM);
        }

        [HttpPost("editar/{id:guid}")]
        public IActionResult Editar(EditarCategoriaViewModel editarVM)
        {
            if (!ModelState.IsValid)
                return View(editarVM);

            Categoria categoriaEditada = new Categoria(editarVM.Titulo);

            repositorioCategoria.Editar(editarVM.Id, categoriaEditada);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            Categoria categoria = repositorioCategoria.SelecionarRegistroPorId(id);

            ExcluirCategoriaViewModel excluirVM = new ExcluirCategoriaViewModel(id, categoria.Titulo);

            return View(excluirVM);
        }

        [HttpPost("excluir/{id:guid}")]
        public IActionResult ExclusaoConfirmada(Guid id)
        {
            repositorioCategoria.Excluir(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("despesas/{id:guid}")]
        public IActionResult Despesas(Guid id)
        {
            Categoria categoria = repositorioCategoria.SelecionarRegistroPorId(id);

            DespesasCategoriaViewModel despesasCategoriaVM = new DespesasCategoriaViewModel(categoria.Id, categoria.Titulo, categoria.Despesas);

            return View(despesasCategoriaVM);
        }
    }
}
