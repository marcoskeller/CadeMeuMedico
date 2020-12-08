using System.ComponentModel.DataAnnotations;


namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(UsuariosMetadado))]

    public partial class Usuarios
    {
    }
    public class UsuariosMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(80, ErrorMessage = "O nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Login")]
        [StringLength(80, ErrorMessage = "O login deve possuir no máximo 80 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Senha")]
        [StringLength(80, ErrorMessage = "A senha deve possuir no máximo 80 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o E-mail")]
        [StringLength(80, ErrorMessage = "O E-mail deve possuir no máximo 80 caracteres")]
        public string Email { get; set; }
    }
}