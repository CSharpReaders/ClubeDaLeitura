using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloRevista.Dominio;

public class Revista : EntidadeBase<Revista>
{
    public string Titulo { get; set; }
    public int NumeroEdicao { get; set; }
    public int AnoPublicacao { get; set; }
    public Caixa Caixa { get; set; }

    public Revista(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
    {
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        Caixa = caixa;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (string.IsNullOrWhiteSpace(Titulo))
            erros.Add("O Campo Titulo é obrigadotorio;");

        else if (Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O campo titulo deve conter entre 2 e 100 caracteres;");

        if (NumeroEdicao < 0)
            erros.Add("O campo numero da edicao deve ser maior que 0;");

        int anoAtual = DateTime.Now.Year;

        if (AnoPublicacao < 1 || AnoPublicacao > anoAtual)
            erros.Add("O campo ano publicacao deve conter uma data valida;");

        if (Caixa == null)
            erros.Add("O campo Caixa deve conter uma caixa valida;");

        return erros;

    }

    public override void AtualizarDados(Revista novaRevista)
    {
        Titulo = novaRevista.Titulo;
        NumeroEdicao = novaRevista.NumeroEdicao;
        AnoPublicacao = novaRevista.AnoPublicacao;
        Caixa = novaRevista.Caixa;
    }
}