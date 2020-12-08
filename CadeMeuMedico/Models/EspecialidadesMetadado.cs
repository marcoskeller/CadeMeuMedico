using System.ComponentModel.DataAnnotations;


namespace CadeMeuMedico.Models
{

    [MetadataType(typeof(EspecialidadesMetadado))]

    public partial class Especialidades
    {
    }

    public class EspecialidadesMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar nome da Especialidade")]
        [StringLength(100, ErrorMessage = "O nome da Especialidade deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}