using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDbContextAPI.DataAccess;


namespace ConnectAppAPI.Services.Services
{
    public class UsersService : IRepository<AspNetUser, AppDbContext>
    {
        private readonly AppDbContext _context;

        public async AspNetUser CreateAsync(AppDbContext context)
        {
            throw new NotImplementedException();
        }

        public AspNetUser Delete(AspNetUser entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<AspNetUser> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public AspNetUser? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public AspNetUser? UpdateAsync(AspNetUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
