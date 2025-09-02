using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using projetodot1.Models;

namespace projetodot1.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}