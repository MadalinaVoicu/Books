using BooksWebApi.Contexts;
using BooksWebApi.Entities;
using System;

namespace BooksWebApi.Services.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly BooksContext _context;

        public AuthorRepository(BooksContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
