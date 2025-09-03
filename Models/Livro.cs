using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetodot1.Models
{
    public class Livro
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="Nome do Livro")]
        [Required(ErrorMessage = "O nome do livro é obrigatório")]
        [StringLength(200, ErrorMessage = "Título deve ser inferior a 100 caracteres")]
        public string? Titulo { get; set; }

        [Display(Name = "Ano de Publicação")]
        [Range(4, 4, ErrorMessage = "O ano de publicação deve ter no mínimo 4 dígitos.")]
        public int AnoPublicacao { get; set; }

        [Display(Name = "ISBN (International Standard Book Number")]
        [Required(ErrorMessage = "O ISBN do livro é obrigatório")]
        [StringLength(20)]
        public string? ISBN { get; set; }

        [Display(Name = "ID do Gênero")]
        public int GeneroId { get; set; }
        [ForeignKey("GeneroId")]
        public virtual Genero? Genero { get; set; }

        [Display(Name = "ID do Autor")]
        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        public virtual Autor? Autor { get; set; }
    }
}