using ConnectAppAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.Services.Interfaces
{
    public interface IUsersRepository : IDisposable
    {
        IEnumerable<AspNetUser> GetUsers();
        AspNetUser? GetUserByID(string userId);
        void InsertUser(AspNetUser user);
        void DeleteUser(string userID);
        void UpdateUsers(AspNetUser user);
        void Save();
        //AspNetUser? GetByIdAsync(AspNetUser id);
        //AspNetUser CreateAsync();
        //AspNetUser UpdateAsync(AspNetUser user);

    }
    //public interface IRepository<T, K> : IDisposable
    //{
    //    List<T> GetAllAsync();
    //    T? GetByIdAsync(K id);
    //    T CreateAsync(K entity);
    //    T? UpdateAsync(K entity);
    //    T Delete(K entity);
    //}
}
