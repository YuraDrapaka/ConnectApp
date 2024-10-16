using ConnectAppAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.Services.Services
{
    public interface IChatService
    {
        Chat GetChatById(int id);
        IEnumerable<Chat> GetAllChats();
        IEnumerable<Chat> GetChatsForUser(string userId);
        IEnumerable<Chat> GetChannels();
        void AddChat(Chat chat);
        void UpdateChat(Chat chat);
        void DeleteChat(int id);

    }
}
