using BookStoreApp.Data.Concrete.Configs;
using BookStoreApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Data.Concrete.Contexts
{
    public class BookStoreAppContext : DbContext
    {
        public BookStoreAppContext(DbContextOptions<BookStoreAppContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
