using BooksWebApi.Services.Repositories;
using System;

namespace BooksWebApi.Services.UnitsOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }
}
