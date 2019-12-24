using AttachMore.NextGen.Core.DomainModels.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.Attachment
{
    /// <summary>
    /// IAttachmentNotificationSettingsService Interface
    /// </summary>
    public interface IAttachmentNotificationSettingsService
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        AttachmentNotificationSettingsModel Add(AttachmentNotificationSettingsModel model);
    }
}
