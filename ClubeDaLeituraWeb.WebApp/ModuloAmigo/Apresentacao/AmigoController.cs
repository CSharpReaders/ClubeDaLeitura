
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
    }
}