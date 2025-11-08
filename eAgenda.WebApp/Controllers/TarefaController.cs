using eAgenda.Dominio.ModuloAutenticacao;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloTarefa;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApp.Controllers
{
    [Authorize]
    [Route("Tarefas")]
    public class TarefaController : Controller
    {
        private readonly AppDbContext context;
        private readonly IRepositorioTarefa repositorioTarefa;
        private readonly IRepositorioItemTarefa repositorioItemTarefa;
        private readonly ITenantProvider tenantProvider;

        public TarefaController(AppDbContext context, IRepositorioTarefa repositorioTarefa, IRepositorioItemTarefa repositorioItemTarefa, ITenantProvider tenantProvider)
        {
            this.context = context;
            this.repositorioTarefa = repositorioTarefa;
            this.repositorioItemTarefa = repositorioItemTarefa;
            this.tenantProvider = tenantProvider;
        }

        [HttpGet]
        public IActionResult Index(string? status, string? prioridade)
        {
            List<Tarefa> tarefas;

            switch (status)
            {
                case "Pendentes": tarefas = repositorioTarefa.SelecionarRegistros().Where(x => x.StatusConclusao == false).ToList(); break;
                case "Concluídas": tarefas = repositorioTarefa.SelecionarRegistros().Where(x => x.StatusConclusao == true).ToList(); break;
                default: tarefas = repositorioTarefa.SelecionarRegistros(); break;
            }

            VisualizarTarefasViewModel visualizarVM = new VisualizarTarefasViewModel(tarefas);

            ViewBag.StatusAtual = status ?? "Todas";
            ViewBag.PrioridadeAtual = prioridade ?? "Todas";

            return View(visualizarVM);
        }

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar()
        {
            CadastrarTarefaViewModel cadastrarVM = new CadastrarTarefaViewModel();

            return View(cadastrarVM);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(CadastrarTarefaViewModel cadastrarVM)
        {
            if (!ModelState.IsValid)
                return View(cadastrarVM);

            Tarefa novaTarefa = new Tarefa(cadastrarVM.Titulo, cadastrarVM.Prioridade);

            novaTarefa.UsuarioId = tenantProvider.UsuarioId.GetValueOrDefault();

            repositorioTarefa.Cadastrar(novaTarefa);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            Tarefa tarefa = repositorioTarefa.SelecionarRegistroPorId(id);

            EditarTarefaViewModel editarVM = new EditarTarefaViewModel(tarefa.Id, tarefa.Titulo, tarefa.Prioridade);

            return View(editarVM);
        }

        [HttpPost("Editar/{id:guid}")]
        public IActionResult Editar(EditarTarefaViewModel editarVM)
        {
            if (!ModelState.IsValid)
                return View(editarVM);

            Tarefa tarefaAtualizada = new Tarefa(editarVM.Titulo, editarVM.Prioridade);

            repositorioTarefa.Editar(editarVM.Id, tarefaAtualizada);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            Tarefa tarefa = repositorioTarefa.SelecionarRegistroPorId(id);

            ExcluirTarefaViewModel excluirVM = new ExcluirTarefaViewModel(tarefa.Id, tarefa.Titulo);

            return View(excluirVM);
        }

        [HttpPost("Excluir/{id:guid}")]
        public IActionResult ExclusaoConfirmada(Guid id)
        {
            repositorioTarefa.Excluir(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("Concluir/{id:guid}")]
        public IActionResult Concluir(Guid id)
        {
            Tarefa tarefa = repositorioTarefa.SelecionarRegistroPorId(id);

            tarefa.MarcarConcluido();
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("DesfazerConclusao/{id:guid}")]
        public IActionResult DesfazerConclusao(Guid id)
        {
            Tarefa tarefa = repositorioTarefa.SelecionarRegistroPorId(id);

            tarefa.MarcarPendente();
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("ItensTarefa/{idTarefa:guid}")]
        public IActionResult ItensTarefa(Guid idTarefa)
        {
            Tarefa tarefa = repositorioTarefa.SelecionarRegistroPorId(idTarefa);

            if (tarefa.ItensTarefa is null)
                tarefa.ItensTarefa = new List<ItemTarefa>();

            DetalhesItensTarefaViewModel itensTarefaVM = new DetalhesItensTarefaViewModel(tarefa.ItensTarefa, tarefa.Titulo, tarefa.Id, tarefa.StatusConclusao, tarefa.PercentualConclusao, tarefa.StatusConclusao);

            return View(itensTarefaVM);
        }

        [HttpPost("AdicionarItemTarefa")]
        public IActionResult AdicionarItemTarefa(AdicionarItemTarefaViewModel adicionarItemVM, Guid idTarefa)
        {
            DetalhesItensTarefaViewModel itensTarefaVM = new DetalhesItensTarefaViewModel();
            Tarefa tarefa = repositorioTarefa.SelecionarRegistroPorId(idTarefa);
            ItemTarefa itemTarefa = new ItemTarefa(adicionarItemVM.TituloItem, tarefa);

            if (!ModelState.IsValid)
            {
                itensTarefaVM = new DetalhesItensTarefaViewModel(tarefa.ItensTarefa, tarefa.Titulo, tarefa.Id, itemTarefa.StatusConclusao, tarefa.PercentualConclusao, tarefa.StatusConclusao);

                return View(nameof(ItensTarefa), itensTarefaVM);
            }

            tarefa.AdicionarItem(itemTarefa);
            context.ItensTarefa.Add(itemTarefa);

            context.SaveChanges();

            return RedirectToAction("ItensTarefa", new { idTarefa = tarefa.Id });
        }

        [HttpPost("RemoverItemTarefa")]
        public IActionResult RemoverItemTarefa(Guid idTarefa, Guid idItem)
        {
            ItemTarefa? itemTarefa = repositorioItemTarefa.SelecionarItemPorId(idItem);
            Tarefa tarefa = repositorioTarefa.SelecionarRegistroPorId(idTarefa);

            if (itemTarefa is not null)
            {
                tarefa.RemoverItem(itemTarefa);
                context.SaveChanges();
            }

            return RedirectToAction("ItensTarefa", new { idTarefa = tarefa.Id });
        }

        [HttpPost("ConcluirItemTarefa")]
        public IActionResult ConcluirItemTarefa(Guid idTarefa, Guid idItem)
        {
            ItemTarefa? itemTarefa = repositorioItemTarefa.SelecionarItemPorId(idItem);
            Tarefa tarefa = repositorioTarefa.SelecionarRegistroPorId(idTarefa);

            if (itemTarefa is not null)
            {
                itemTarefa.MarcarConcluido();
                tarefa.AtualizarPercentualConclusao();
                context.SaveChanges();
            }

            return RedirectToAction("ItensTarefa", new { idTarefa = tarefa.Id });
        }
    }
}
