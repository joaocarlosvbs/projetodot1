using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetodot1.Models
{
    public class Autor
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do autor é obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ser inferior a 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Nacionalidade")]
        [StringLength(100, ErrorMessage = "Nacionalidade deve ser inferior a 100 caracteres")]
        public string Nacionalidade { get; set; }
    }
}