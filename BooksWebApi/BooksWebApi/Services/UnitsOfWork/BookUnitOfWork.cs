using BooksWebApi.Contexts;
using BooksWebApi.Services.Repositories;
using System;

namespace BooksWebApi.Services.UnitsOfWork
{
    public class BookUnitOfWork : IBookUnitOfWork
    {
        private readonly BooksContext _context;

        public BookUnitOfWork(BooksContext context, IBookRepository books,
            IAuthorRepository authors)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Books = books ?? throw new ArgumentNullException(nameof(context));
            Authors = authors ?? throw new ArgumentNullException(nameof(context));
        }

        public IBookRepository Books { get; }

        public IAuthorRepository Authors { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
