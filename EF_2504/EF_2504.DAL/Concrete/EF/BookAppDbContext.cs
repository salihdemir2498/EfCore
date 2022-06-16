using EF_2504.DAL.Concrete.EF.Config;
using EF_2504.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_2504.DAL.Concrete.EF
{
    public class BookAppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-4JE8ADO\SQLEXPRESS;Database=BookAppDb;Trusted_Connection=true;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryConfig());
            //modelBuilder.ApplyConfiguration(new AuthorConfig());
            //modelBuilder.ApplyConfiguration(new BookConfig());
            //modelBuilder.ApplyConfiguration(new BookDetailConfig());

            //toplu halde hepsini buraya ekleme kodu
            //Var olan konfiglerimizden herhangi birini seçip onlardan b,r,ni alıyor
            //ve o tipteki tüm configlerin uygulanmasını sağlıyoruz.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfig).Assembly);
        }
    }
}
