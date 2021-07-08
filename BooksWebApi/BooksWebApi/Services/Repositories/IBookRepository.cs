using BooksWebApi.Entities;
using System;

namespace BooksWebApi.Services.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBookDetails(Guid bookId);
    }
}
