
using ClubeDaLeituraWeb.WebApp.ModuloAmigos.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ClubeDaLeituraWeb.WebApp.ModuloAmigos.Apresentacao.Views
{
    public class AmigoController : Controller
    {
        private readonly IRepositorioAmigo repositorioAmigo;

        public AmigoController(IRepositorioAmigo repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }

        [HttpGet]
        public ActionResult Listar()
        {
            List<Amigo> amigos = repositorioAmigo.SelecionarTodos();

            List<ListarAmigoViewModel> listarVmS = new();

            //Cria a lista de amigos em ViewModel

            foreach (Amigo a in amigos)
            {
                ListarAmigoViewModel vm = new(
                    a.Id,
                    a.Nome,
                    a.NomeResponsavel,
                    a.Telefone
                );
                listarVmS.Add(vm);
            }
            return View(listarVmS);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(CadastrarAmigoViewModel amigoVm)
        {
            if (!ModelState.IsValid)
                return View(nameof(Cadastrar));

            Amigo amigo = new Amigo(amigoVm.Nome, amigoVm.NomeResponsavel, amigoVm.Telefone);

            repositorioAmigo.Cadastrar(amigo);

            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public ActionResult Excluir(string id)
        {
            Amigo? amigo = repositorioAmigo.SelecionarPorId(id);

            if (amigo == null)
                return RedirectToAction(nameof(Listar));

            ExcluirAmigoViewModel amigoVm = new(
                id,
                amigo.Nome,
                amigo.NomeResponsavel,
                amigo.Telefone
            );
            return View(amigoVm);
        }
        [HttpPost]
        public ActionResult Excluir(ExcluirAmigoViewModel excluirVm)
        {
            Amigo? amigoExcluir = repositorioAmigo.SelecionarPorId(excluirVm.Id);

            if (amigoExcluir == null)
                return View(excluirVm);

            if (amigoExcluir.Emprestimo != null)
            {
                ModelState.AddModelError("Nome", "Amigos com emprestimos não podem ser excluidos");
                return View(excluirVm);
            }

            repositorioAmigo.Excluir(amigoExcluir);
            return RedirectToAction(nameof(Listar));

        }
        [HttpGet]
        public ActionResult Editar(string id)
        {
            Amigo? amigo = repositorioAmigo.SelecionarPorId(id);

            if (amigo == null)
                return RedirectToAction(nameof(Listar));

            EditarAmigoViewModel editarVm = new(
                amigo.Id,
                amigo.Nome,
                amigo.NomeResponsavel,
                amigo.Telefone
            );

            return View(editarVm);
        }
        [HttpPost]
        public ActionResult Editar(EditarAmigoViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(nameof(Editar));

            Amigo amigoAtualizado = new(
                editarVm.Nome,
                editarVm.NomeResponsavel,
                editarVm.Telefone
            );

            repositorioAmigo.Editar(editarVm.Id, amigoAtualizado);

            return RedirectToAction(nameof(Listar));
        }
    }
}