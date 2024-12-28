
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApp.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(new Book { Id = 1, Title = "Ali Can Yücel", Price = 50 },
             new Book { Id = 2, Title = "Hakan Can Yücel", Price = 250 },
             new Book { Id = 3, Title = "Metin Yücel", Price = 150 }
             );
        }
        
    }
}