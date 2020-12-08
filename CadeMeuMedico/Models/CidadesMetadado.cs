using System.ComponentModel.DataAnnotations;


namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(CidadesMetadado))]

    public partial class Cidades
    {
    }

    public class CidadesMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar a nome da Cidade")]
        [StringLength(100, ErrorMessage = "A Cidade deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}