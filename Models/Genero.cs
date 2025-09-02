using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetodot1.Models
{
    public class Genero
    {
        [Display(Name = "Código ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(100, ErrorMessage = "Descrição deve ser inferior a 100 caracteres")]
        public string Descricao { get; set; }
    }
}