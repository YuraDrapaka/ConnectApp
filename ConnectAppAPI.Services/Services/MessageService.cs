using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.Services.Services
{
    public class MessageService : IMessageService
    {
        public void AddMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessageById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAllMessages()
        {
            throw new NotImplementedException();
        }

        public Message GetMessageById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessagesByChat(int chatId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessagesByUser(string userID)
        {
            throw new NotImplementedException();
        }

        public void UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
