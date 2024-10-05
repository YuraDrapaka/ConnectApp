using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDbContextAPI.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace ConnectAppAPI.Services.Services
{
    //public class UsersService : IRepository<AspNetUser, AppDbContext>
    //{
    //    private readonly AppDbContext _context;

    //    public async AspNetUser CreateAsync(AppDbContext context)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public AspNetUser Delete(AspNetUser entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<AspNetUser> GetAllAsync()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public AspNetUser? GetByIdAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public AspNetUser? UpdateAsync(AspNetUser entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class UserServiceOneOne : IUsersRepository
    {
        private readonly AppDbContext _context;

        //Constructor
        public UserServiceOneOne(AppDbContext context)
        {
            _context = context;
        }

        //Methods
        public IEnumerable<AspNetUser> GetUsers()
        {
            return _context.AspNetUsers.ToList();
        }
        public AspNetUser GetUserByID(string userId)
        {
            return _context.AspNetUsers.Find(userId);
        }
        public void InsertUser(AspNetUser user)
        {
            _context.AspNetUsers.Add(user);
        }
        public void DeleteUser(string userID)
        {
            _context.AspNetUsers.Remove(GetUserByID(userID));

            //Or example from Documentation
            //AspNetUser user = _context.AspNetUsers.Find(userID);
            //_context.AspNetUsers.Remove(user);
        }
        public void UpdateUsers(AspNetUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }



        //private readonly AppDbContext _context;
        //public UserServiceOne(AppDbContext context) 
        //{
        //    _context = context;
        //}
        //public List<AspNetUser> GetAll()
        //{
        //    var users = new List<AspNetUser>();
        //    return users;
        //}
    }
}
