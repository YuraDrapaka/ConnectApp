using AppDbContextAPI.DataAccess;
using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context = new AppDbContext();

        private GenericRepository<Chat> chatRepository;
        private GenericRepository<Media> mediaRepository;
        private GenericRepository<Message> messageRepository;
        private GenericRepository<AspNetUser> aspUserRepository;

        public GenericRepository<Chat> ChatRepository
        {
            get
            {
                if (chatRepository == null)
                {
                    chatRepository = new GenericRepository<Chat>(context);
                }
                return chatRepository;
            }
        }

        public GenericRepository<Media> MediaRepository
        {
            get
            {
                if (mediaRepository == null)
                {
                    mediaRepository = new GenericRepository<Media>(context);
                }
                return mediaRepository;
            }
        }
        public GenericRepository<Message> MessageRepository
        {
            get
            {
                if (messageRepository == null)
                {
                    messageRepository = new GenericRepository<Message>(context);
                }
                return messageRepository;
            }
        }
        public GenericRepository<AspNetUser> AspUserRepository
        {
            get
            {
                if (AspUserRepository == null)
                {
                    aspUserRepository = new GenericRepository<AspNetUser>(context);
                }
                return aspUserRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}