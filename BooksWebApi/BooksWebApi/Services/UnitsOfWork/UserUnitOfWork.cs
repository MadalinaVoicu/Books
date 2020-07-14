using BooksWebApi.Contexts;
using BooksWebApi.Services.Repositories;
using System;

namespace BooksWebApi.Services.UnitsOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly BooksContext _context;

        public UserUnitOfWork(BooksContext context, IUserRepository users)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Users = users ?? throw new ArgumentNullException(nameof(context));
        }

        public IUserRepository Users { get; }

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
