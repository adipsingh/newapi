using AttachMore.NextGen.Core.IRepositories.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Repositories.Attachment
{
    /// <summary>
    /// Download Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.Download, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Attachment.IDownloadRepository" />
    public class DownloadRepository : Repository<Download, NextGenContext>, IDownloadRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DownloadRepository(NextGenContext context)
            : base(context)
        {

        }
    }
}
