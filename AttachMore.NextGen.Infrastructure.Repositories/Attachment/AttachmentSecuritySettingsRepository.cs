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
    /// AttachmentSecuritySettingsRepository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.AttachmentSecuritySettings, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Attachment.IAttachmentSecuritySettingsRepository" />
    public class AttachmentSecuritySettingsRepository : Repository<AttachmentSecuritySettings, NextGenContext>, IAttachmentSecuritySettingsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentSecuritySettingsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AttachmentSecuritySettingsRepository(NextGenContext context)
            : base(context)
        {

        }
    }
}
