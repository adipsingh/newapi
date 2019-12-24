using AttachMore.NextGen.Core.IRepositories;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Repositories
{
    /// <summary>
    /// Repository Class
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.IRepository{TEntity}" />
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext

    {
        /// <summary>
        /// The context
        /// </summary>
        private TContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        private DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(TContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="Entity">The entity.</param>
        public virtual void Add(TEntity Entity)
        {
            _context.Set<TEntity>().Add(Entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> result = _context.Set<TEntity>();
            return result;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetById(int Id)
        {
            TEntity result = _dbSet.Find(Id);
            return result;
        }

        public IQueryable<TEntity> FetchFromSP(string spName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches from sp.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IQueryable<TEntity> FetchFromSP(string spName, SqlParameter[] parameters)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().FromSql(spName);
            return query;
        }
    }
}
