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
    /// AttachmentsRepository Class
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.Attachments, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Attachment.IAttachmentsRepository" />
    public class AttachmentsRepository : Repository<Attachments, NextGenContext>, IAttachmentsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AttachmentsRepository(NextGenContext context)
            : base(context)
        {

        }
    }
}
