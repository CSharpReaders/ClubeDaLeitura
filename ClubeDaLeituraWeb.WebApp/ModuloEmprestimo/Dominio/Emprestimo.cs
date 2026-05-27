using System.Security.Cryptography;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloAmigos.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevista.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Dominio;

public class Emprestimo : EntidadeBase<Emprestimo>
{
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public Status Status { get; set; } = Status.Aberto;
    public DateTime DataEmprestimo { get; set; } = DateTime.Now;
    public DateTime DataDevolucao
    {
        get => DataEmprestimo.AddDays(Revista.Caixa.DiasDeEmprestimo);
    }
    public Emprestimo()
    {

    }
    public Emprestimo(Amigo amigo, Revista revista)
    {
        Amigo = amigo;
        Revista = revista;
    }

    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }

    public override void AtualizarDados(Emprestimo entidadeAtualizada)
    {
        throw new NotImplementedException();
    }
}
