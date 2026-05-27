using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloAmigos.Dominio;

public class Amigo : EntidadeBase<Amigo>
{
    public string Nome { get; set; } = string.Empty;
    public string NomeResponsavel { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    public Amigo() { }
    public Amigo(string nome, string nomeResponsavel, string telefone)
    {
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
    }
    public override List<string> Validar()
    {
        List<string> erros = new();

        if (string.IsNullOrEmpty(Nome))
            erros.Add("O campo \"Nome\" é obrigatório;");
        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres;");

        if (string.IsNullOrEmpty(NomeResponsavel))
            erros.Add("O campo \"Nome do Responsável\" é obrigatório;");

        if (string.IsNullOrEmpty(Telefone))
            erros.Add("O campo \"Telefone\" é obrigatório;");
        int contadorDigitos = 0;

        string telefoneEncurtado = Telefone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
        bool contemLetraOuSimbolo = false;

        for (int i = 0; i < telefoneEncurtado.Length; i++)
        {
            char c = telefoneEncurtado[i];
            if (char.IsDigit(c))
                contadorDigitos++;
            else
            {
                contemLetraOuSimbolo = true;
                break;
            }
        }

        if (contadorDigitos < 10 || contadorDigitos > 11)
            erros.Add("O campo \"Telefone\" deve conter entre 10 e 11 dígitos;");

        if (contemLetraOuSimbolo)
            erros.Add("O campo \"Telefone\" deve conter apenas dígitos;");

        return erros;
    }
    public override void AtualizarDados(Amigo entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        NomeResponsavel = entidadeAtualizada.NomeResponsavel;
        Telefone = entidadeAtualizada.Telefone;
    }

    // internal void AdicionarEmprestimo(Emprestimo emprestimo)
    // {
    //     for (int i = 0; i < Emprestimos.Length; i++)
    //     {
    //         if (Emprestimos[i] == null)
    //         {
    //             Emprestimos[i] = emprestimo;
    //             break;
    //         }
    //     }
    // }
}
