using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.Services.Interfaces
{
    //public interface IRepository<T, K> : IDisposable
    //{
    //    List<T> read();

    //    T readById(K id);
    //    T create(T entity);
    //    T update(T entity);
    //    T delete(T entity);
    //}

    public interface IRepositoryGeneric<T, K> :IDisposable
    {
        List<T> GetAllAsync();
        T? GetByIdAsync(K id);
        T CreateAsync(K entity);
        T? UpdateAsync(K entity);
        T Delete(K entity);
    }
}
