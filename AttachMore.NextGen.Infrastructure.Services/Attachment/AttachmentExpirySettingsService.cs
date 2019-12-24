using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Core.IRepositories.Attachment;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using AttachMore.NextGen.Infrastructure.Repositories.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Attachment
{
    /// <summary>
    /// AttachmentExpirySettingsService class
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Attachment.IAttachmentExpirySettingsService" />
    public class AttachmentExpirySettingsService : IAttachmentExpirySettingsService
    {
        /// <summary>
        /// The m attachment expiry settings repository
        /// </summary>
        IAttachmentExpirySettingsRepository m_AttachmentExpirySettingsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentExpirySettingsService"/> class.
        /// </summary>
        public AttachmentExpirySettingsService(IAttachmentExpirySettingsRepository AttachmentExpirySettingsRepository)
        {
            this.m_AttachmentExpirySettingsRepository = AttachmentExpirySettingsRepository;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public AttachmentExpirySettingsModel Add(AttachmentExpirySettingsModel entity)
        {
            try
            {
                var model = new AttachmentExpirySettings()
                {
                    AttachmentId = entity.AttachmentId,
                    DeletionDate = entity.DeletionDate,
                    DownloadsLimit = entity.DownloadsLimit,
                    ExpiryDate = entity.ExpiryDate
                };

                this.m_AttachmentExpirySettingsRepository.Add(model);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}
