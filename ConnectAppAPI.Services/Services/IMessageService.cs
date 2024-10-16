using ConnectAppAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.Services.Interfaces
{
    public interface IMessageService
    {
        Message GetMessageById(int id);
        IEnumerable<Message> GetAllMessages();
        IEnumerable<Message> GetMessagesByChat(int chatId);
        IEnumerable<Message> GetMessagesByUser(string userID);
        void AddMessage(Message message);
        void UpdateMessage(Message message);
        void DeleteMessage(Message message);
        void DeleteMessageById(int id);
        
        
    }
}
