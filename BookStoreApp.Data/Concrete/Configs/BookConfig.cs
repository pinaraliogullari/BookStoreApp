using BookStoreApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Data.Concrete.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b=>b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);//bire çok ilişki
            builder.HasOne(b=>b.Publisher).WithMany(p => p.Books).HasForeignKey(b=>b.PublisherId);//bire çok ilişki
            builder.HasOne(b => b.Genre).WithMany(g => g.Books).HasForeignKey(b => b.GenreId);//bire çok ilişki

            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Title).HasMaxLength(30);
            builder.Property(b => b.Isbn).IsRequired();
            builder.Property(b => b.Isbn).HasMaxLength(20);
            builder.Property(b => b.TotalPages).IsRequired();
      

            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "Fareler ve İnsanlar",
                    AuthorId = 1,
                    PublisherId = 1,
                    GenreId = 1,
                    Isbn = "bvncm",
                    TotalPages = 250,

                },
                  new Book
                  {
                      Id = 2,
                      Title = "Kumarbaz",
                      AuthorId = 2,
                      PublisherId = 2,
                      GenreId = 3,
                      Isbn = "xcvbtr",
                      TotalPages = 450,

                  },
                    new Book
                    {
                        Id = 3,
                        Title = "İnsan Ne İle Yaşar",
                        AuthorId = 3,
                        PublisherId = 3,
                        GenreId = 2,
                        Isbn = "qwert",
                        TotalPages = 320,

                    }
            );
            


        }
    }
}
