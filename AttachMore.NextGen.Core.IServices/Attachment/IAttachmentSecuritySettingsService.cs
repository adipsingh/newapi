using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.Attachment
{
    /// <summary>
    /// IAttachmentSecuritySettingsService Interface
    /// </summary>
    public interface IAttachmentSecuritySettingsService
    {
        /// <summary>
        /// Adds the specified settings.
        /// </summary>
        /// <param name="Settings">The settings.</param>
        AttachmentSecuritySettingsModel Add(AttachmentSecuritySettingsModel Settings);

        /// <summary>
        /// Gets the security settings.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <returns></returns>
        AttachmentSecuritySettingsModel GetSecuritySettings(int AttachmentId);
    }
}
