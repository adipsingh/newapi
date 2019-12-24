using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IRepositories.Attachment
{
    /// <summary>
    /// IFile Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.IRepository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.Files}" />
    public interface IFileRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
    }
}
