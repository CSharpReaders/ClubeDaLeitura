
using System.ComponentModel.DataAnnotations;

namespace ClubeDaLeituraWeb.WebApp.ModuloAmigos.Apresentacao
{
    public record ListarAmigoViewModel(
        string Id,
        string Nome,
        string NomeResponsavel,
        string Telefone
    );
    public record CadastrarAmigoViewModel(
        [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
         [StringLength(30, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve 3 à 30 caracteres!")]
        string Nome,
        [Required(ErrorMessage = "O campo \"Nome responsavel\" deve ser preenchido.")]
         [StringLength(30, MinimumLength = 3, ErrorMessage = "O campo \"Nome responsavel\" deve 3 à 30 caracteres!")]
        string NomeResponsavel,
         [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
         [StringLength(11, MinimumLength = 10, ErrorMessage = "O campo \"Telefone\" deve 10 à 11 caracteres!")]
        string Telefone
    );
    public record ExcluirAmigoViewModel(
        string Id,
        string Nome,
        string NomeResponsavel,
        string Telefone
    );
    public record EditarAmigoViewModel(
        string Id,
        [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
         [StringLength(30, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve 3 à 30 caracteres!")]
        string Nome,
        [Required(ErrorMessage = "O campo \"Nome responsavel\" deve ser preenchido.")]
         [StringLength(30, MinimumLength = 3, ErrorMessage = "O campo \"Nome responsavel\" deve 3 à 30 caracteres!")]
        string NomeResponsavel,
        [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
         [StringLength(11, MinimumLength = 10, ErrorMessage = "O campo \"Telefone\" deve 10 à 11 caracteres!")]
        string Telefone
    );
}