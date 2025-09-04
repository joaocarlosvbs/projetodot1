using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetodot1.Models
{
    public enum StatusLivro
    {
        Disponível,
        Emprestado
    }

    public class Livro
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome do Livro")]
        [Required(ErrorMessage = "O nome do livro é obrigatório")]
        [StringLength(200, ErrorMessage = "O título deve ter no máximo 200 caracteres")]
        public string? Titulo { get; set; }

        [Display(Name = "Ano de Publicação")]
        [Range(1000, 2025, ErrorMessage = "O ano de publicação deve ser um valor válido de 4 dígitos.")]
        public int AnoPublicacao { get; set; }

        [Display(Name = "ISBN (International Standard Book Number)")]
        [Required(ErrorMessage = "O ISBN do livro é obrigatório")]
        [StringLength(20)]
        public string? ISBN { get; set; }

        [Display(Name = "Status")]
        public StatusLivro Status { get; set; }

        [Display(Name = "ID do Gênero")]
        public int GeneroId { get; set; }
        [ForeignKey("GeneroId")]
        public virtual Genero? Genero { get; set; }

        [Display(Name = "ID do Autor")]
        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        public virtual Autor? Autor { get; set; }

        public Livro()
        {
            Status = StatusLivro.Disponível;
        }
    }
}