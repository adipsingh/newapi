using AttachMore.NextGen.Core.DomainModels.Account;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices
{
    /// <summary>
    /// IBaseService Interface
    /// </summary>
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        TEntity Add(TEntity entity);
    }
}
