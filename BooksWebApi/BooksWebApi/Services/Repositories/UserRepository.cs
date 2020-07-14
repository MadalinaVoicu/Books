using BooksWebApi.Contexts;
using BooksWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksWebApi.Services.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly BooksContext _context;

        public UserRepository(BooksContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetAdminUsers()
        {
            return _context.Users
                .Where(u => u.IsAdmin && (u.Deleted == false || u.Deleted == null))
                .ToList();
        }
    }
}
