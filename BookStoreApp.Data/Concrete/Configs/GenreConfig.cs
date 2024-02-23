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
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).ValueGeneratedOnAdd();

            builder.Property(g => g.Name).IsRequired();
            builder.Property(g => g.Name).HasMaxLength(15);

            builder.HasData
                (
                new Genre { Id = 1, Name = "Roman" },
                new Genre { Id = 2, Name = "Psikoloji" },
                new Genre { Id = 3, Name = "Gezi" },
                new Genre { Id = 4, Name = "Şiir" });
   
        }
    }
}
