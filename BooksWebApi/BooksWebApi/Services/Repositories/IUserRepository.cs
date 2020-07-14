using BooksWebApi.Entities;
using System.Collections.Generic;

namespace BooksWebApi.Services.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
