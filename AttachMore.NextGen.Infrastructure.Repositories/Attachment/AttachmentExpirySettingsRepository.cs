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
    /// AttachmentExpirySettings Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.AttachmentExpirySettings, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Attachment.IAttachmentExpirySettingsRepository" />
    public class AttachmentExpirySettingsRepository : Repository<AttachmentExpirySettings, NextGenContext>, IAttachmentExpirySettingsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentExpirySettingsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AttachmentExpirySettingsRepository(NextGenContext context)
            : base(context)
        {

        }
    }
}
