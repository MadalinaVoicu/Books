using BooksWebApi.Services.Repositories;
using System;

namespace BooksWebApi.Services.UnitsOfWork
{
    public interface IBookUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }

        IAuthorRepository Authors { get; }

        int Complete();
    }
}
