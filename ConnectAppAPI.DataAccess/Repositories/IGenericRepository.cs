using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAppAPI.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetByIDAsync(object id);
        Task InsertAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task DeleteAsync(TEntity entityToDelete);
        Task UpdateAsync(TEntity entityToUpdate);
    }

    //public interface IGenericRepository<TEntity> where TEntity : class
    //{
    //    public IEnumerable<TEntity> Get(
    //        Expression<Func<TEntity, bool>> filter = null,
    //        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    //        string includeProperties = "");

    //    public TEntity GetByID(object id);
    //    public void Insert(TEntity entity);
    //    public void Delete(object id);
    //    public void Delete(TEntity entityToDelete);
    //    public void Update(TEntity entityToUpdate);
    //}
}