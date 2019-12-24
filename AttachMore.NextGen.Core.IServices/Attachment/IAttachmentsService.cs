using AttachMore.NextGen.Core.DomainModels;
using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using AttachMore.NextGen.ServiceModel.Request.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.Attachment
{
    /// <summary>
    /// IAttachmentsService Interface
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.IBaseService{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.Attachments}" />
    public interface IAttachmentsService
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns></returns>
        AttachmentModel Add(AttachmentModel entity, string userEmail, string SentBy);

        /// <summary>
        /// Gets the attachment detail.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <returns></returns>
        AttachmentDetailModel GetAttachmentDetail(int AttachmentId);

        /// <summary>
        /// Downloads the attachment.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        DownLoadAttachmentModel DownloadAttachment(AttachmentDownloadRequest model, string LoggedInUserEmail);

        /// <summary>
        /// Updates the specified attachment name.
        /// </summary>
        /// <param name="AttachmentName">Name of the attachment.</param>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns></returns>
        string Update(string AttachmentName, int attachmentId, string userEmail);
    }
}
