using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.DataAccess.Repositories;

namespace ConnectAppAPI.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext _context; /*= new AppDbContext();*/
        private Repository<Chat> chatRepository;
        private Repository<Media> mediaRepository;
        private Repository<Message> messageRepository;
        private Repository<AspNetUser> aspUserRepository;

        public UnitOfWork(AppDbContext context) 
        {
            this._context = context;
        }


        public Repository<Chat> ChatRepository
        {
            get
            {
                if (chatRepository == null)
                {
                    chatRepository = new Repository<Chat>(_context);
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
                    mediaRepository = new Repository<Media>(_context);
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
                    messageRepository = new Repository<Message>(_context);
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
                    aspUserRepository = new Repository<AspNetUser>(_context);
                }
                return aspUserRepository;
            }
        }

        public void Save()
        {
           _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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