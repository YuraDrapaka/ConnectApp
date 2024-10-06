using AppDbContextAPI.DataAccess;
using ConnectAppAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.DataAccess.Repositories
{
    public class MediaRepository : GenericRepository<Media>
    {
        public MediaRepository(AppDbContext context) : base(context)
        {

        }
    }
}
