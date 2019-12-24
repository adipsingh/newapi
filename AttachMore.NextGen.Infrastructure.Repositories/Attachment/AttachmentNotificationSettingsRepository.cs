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
    /// AttachmentNotificationSettingsRepository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.AttachmentNotificationSettings, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Attachment.IAttachmentNotificationSettingsRepository" />
    public class AttachmentNotificationSettingsRepository : Repository<AttachmentNotificationSettings, NextGenContext>, IAttachmentNotificationSettingsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentNotificationSettingsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AttachmentNotificationSettingsRepository(NextGenContext context)
            : base(context)
        {

        }
    }
}
