using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.DataAccess.Repositories;

namespace ConnectAppAPI.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context = new AppDbContext();

        private Repository<Chat> chatRepository;
        private Repository<Media> mediaRepository;
        private Repository<Message> messageRepository;
        private Repository<AspNetUser> aspUserRepository;

        public Repository<Chat> ChatRepository
        {
            get
            {
                if (chatRepository == null)
                {
                    chatRepository = new Repository<Chat>(context);
                }
                return chatRepository;
            }
        }

        public Repository<Media> MediaRepository
        {
            get
            {
                if (mediaRepository == null)
                {
                    mediaRepository = new Repository<Media>(context);
                }
                return mediaRepository;
            }
        }
        public Repository<Message> MessageRepository
        {
            get
            {
                if (messageRepository == null)
                {
                    messageRepository = new Repository<Message>(context);
                }
                return messageRepository;
            }
        }
        public Repository<AspNetUser> AspUserRepository
        {
            get
            {
                if (AspUserRepository == null)
                {
                    aspUserRepository = new Repository<AspNetUser>(context);
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