using Microsoft.EntityFrameworkCore;
using SimpleBooksApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBooksApi.Data
{
    public class SimpleBooksDbContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SimpleBooks;Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.Entity<Autor>().ToTable("Autor");
            modelBuider.Entity<Livro>().ToTable("Livro");
        }
    }
}
