using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Core.IRepositories.Attachment;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Infrastructure.Component.Enums.Notification;
using AttachMore.NextGen.Infrastructure.Component.Mapper;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Attachment
{
    /// <summary>
    /// AttachmentNotificationSettingsService
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Attachment.IAttachmentNotificationSettingsService" />
    public class AttachmentNotificationSettingsService : IAttachmentNotificationSettingsService
    {
        /// <summary>
        /// The m attachment notification settings service
        /// </summary>
        IAttachmentNotificationSettingsRepository m_AttachmentNotificationSettingsRepository;

        /// <summary>
        /// The m notificatoin repository
        /// </summary>
        INotificationDetailsRepository m_NotificationDetailsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentNotificationSettingsService"/> class.
        /// </summary>
        public AttachmentNotificationSettingsService(IAttachmentNotificationSettingsRepository AttachmentNotificationSettingsService, INotificationDetailsRepository NotificationDetailsRepository)
        {
            this.m_AttachmentNotificationSettingsRepository = AttachmentNotificationSettingsService;
            this.m_NotificationDetailsRepository = NotificationDetailsRepository;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="NotImplementedException"></exception>
        public AttachmentNotificationSettingsModel Add(AttachmentNotificationSettingsModel model)
        {
            try
            {
                var entity = new AttachmentNotificationSettings()
                {
                    AttachmentId = model.AttachmentId,
                    ByEmail = model.ByEmail,
                    ByText = model.ByText,
                    WhenDownload = model.WhenDownload,
                    WhenExpired = model.WhenExpired,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };
                this.m_AttachmentNotificationSettingsRepository.Add(entity);
                this.AddNotificationDetails(model);

                return model;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }


        /// <summary>
        /// Adds the notification details.
        /// </summary>
        /// <param name="model">The model.</param>
        private void AddNotificationDetails(AttachmentNotificationSettingsModel model)
        {
            foreach (var item in model.notifyInfo)
            {
                NotificationDetails details = new NotificationDetails();
                details.AttachmentId = model.AttachmentId;
                details.NotiicationSendOn = item.notifyText;
                details.type = model.ByEmail != false ? (int)NotificationDetailsEnum.Email : (int)NotificationDetailsEnum.Text;
                this.m_NotificationDetailsRepository.Add(details);
            }
        }
    }
}
