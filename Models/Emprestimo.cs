using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetodot1.Models
{
    public class Emprestimo
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Data de Empréstimo")]
        [Required(ErrorMessage = "A data de empréstimo é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataEmprestimo { get; set; }

        [Display(Name = "Data de Devolução")]
        [Required(ErrorMessage = "A data de devolução é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime? DataDevolucao { get; set; }

        [Display(Name = "ID do Livro")]
        public int LivroId { get; set; }
        [ForeignKey("LivroId")]
        public virtual Livro? Livro { get; set; }

        [Display(Name = "ID do Aluno")]
        // Chave Estrangeira para Aluno
        public int AlunoId { get; set; }
        [ForeignKey("AlunoId")]
        public virtual Aluno? Aluno { get; set; }
    }
}
