using BooksWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApi.Contexts
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
          : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
