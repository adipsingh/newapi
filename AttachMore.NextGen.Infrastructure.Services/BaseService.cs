using AttachMore.NetGen.Core.Security.Auth;
using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Core.Exceptions.APIExceptions;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Core.IServices;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services
{
    /// <summary>
    /// Base Service Class
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.IBaseService" />
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {


        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
