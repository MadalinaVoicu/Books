using BooksWebApi.Contexts;
using BooksWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BooksWebApi.Services.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly BooksContext _context;

        public BookRepository(BooksContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Book GetBookDetails(Guid bookId)
        {
            return _context.Books
                .Where(b => b.Id == bookId && (b.Deleted == false || b.Deleted == null))
                .Include(b => b.Author)
                .FirstOrDefault();
        }
    }
}
