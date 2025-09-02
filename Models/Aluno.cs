using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetodot1.Models
{
    public class Aluno
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome do Aluno")]
        [Required(ErrorMessage = "O campo nome do aluno é obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ser inferior a 100 caracteres"))]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Data de Inscrição")]
        [Required(ErrorMessage = "A data é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataInscricao { get; set; }
    }
}