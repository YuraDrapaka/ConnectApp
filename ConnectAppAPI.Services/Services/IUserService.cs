using ConnectAppAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.Services.Interfaces
{
    public interface IUserService
    {
        AspNetUser GetUserById(string userid);
        IEnumerable<AspNetUser> GetAllUsers();
        IEnumerable<AspNetUser> GetUserContacts(string id);
        void AddUser(AspNetUser user);
        void UpdateUser(AspNetUser userId);
        void DeleteUser(AspNetUser userId);

    }
}
