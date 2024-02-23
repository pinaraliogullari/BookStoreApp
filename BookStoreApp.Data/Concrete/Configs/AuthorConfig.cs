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
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a=>a.AuthorName).IsRequired();
            builder.HasData(
                new Author{ Id = 1, AuthorName="John Steinback"},
                new Author{ Id = 2, AuthorName="Dostoyevski"},
                new Author{ Id = 3, AuthorName="Tolstoy"} );
        }
    }
}
