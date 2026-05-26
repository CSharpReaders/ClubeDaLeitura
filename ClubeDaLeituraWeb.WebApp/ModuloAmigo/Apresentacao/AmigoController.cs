
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

            if (amigoExcluir != null)
                repositorioAmigo.Excluir(amigoExcluir);


            return RedirectToAction(nameof(Listar));
        }
    }
}