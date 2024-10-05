using AppDbContextAPI.DataAccess;
using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.Services.Services
{
    public class MessageRepository : GenericRepository<Message>
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }
    }
}