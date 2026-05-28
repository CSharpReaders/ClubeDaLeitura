using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;
using ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevista.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Infra;

public class RepositorioEmprestimoEmArquivo : RepositorioBaseEmArquivo<Emprestimo>, IRepositorioEmprestimo
{
    public RepositorioEmprestimoEmArquivo(ContextoJson contexto) : base(contexto) { }
    public List<Emprestimo> SelecionarConcluidos()
    {
        List<Emprestimo> lista = new();

        foreach (Emprestimo e in registros)
        {
            if (e.Status == StatusEmprestimo.Concluido)
            {
                lista.Add(e);
            }
        }
        return lista;
    }
    public List<Emprestimo> SelecionarEmAberto()
    {
        List<Emprestimo> lista = new();

        foreach (Emprestimo e in registros)
        {
            if (e.Status == StatusEmprestimo.Aberto)
            {
                lista.Add(e);
            }
        }
        return lista;
    }

    protected override List<Emprestimo> CarregarRegistros()
    {
        return contexto.Emprestimos;
    }

}
