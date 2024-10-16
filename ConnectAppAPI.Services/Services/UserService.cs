using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.Services.Services
{
    public class UserService : IUserService
    {
        void IUserService.AddUser(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        void IUserService.DeleteUser(AspNetUser userId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AspNetUser> IUserService.GetAllUsers()
        {
            throw new NotImplementedException();
        }

        AspNetUser IUserService.GetUserById(string userid)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AspNetUser> IUserService.GetUserContacts(string id)
        {
            throw new NotImplementedException();
        }

        void IUserService.UpdateUser(AspNetUser userId)
        {
            throw new NotImplementedException();
        }
    }
}
