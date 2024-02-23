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
    public class PublisherConfig : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("Publishers");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Publisher { Id=1,PublisherName="Can Yayınları"},
                new Publisher { Id=2,PublisherName="Martı Yayınları"},
                new Publisher { Id=3,PublisherName="YKY Yayınları"}
                );

        }
    }
}
