using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Core.IRepositories.Attachment;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Attachment
{
    /// <summary>
    /// AttachmentSecuritySettingsService Class
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Attachment.IAttachmentSecuritySettingsService" />
    public class AttachmentSecuritySettingsService : IAttachmentSecuritySettingsService
    {
        /// <summary>
        /// The m attachment security settings repository
        /// </summary>
        IAttachmentSecuritySettingsRepository m_AttachmentSecuritySettingsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentSecuritySettingsService"/> class.
        /// </summary>
        /// <param name="AttachmentSecuritySettingsRepository">The attachment security settings repository.</param>
        public AttachmentSecuritySettingsService(IAttachmentSecuritySettingsRepository AttachmentSecuritySettingsRepository)
        {
            this.m_AttachmentSecuritySettingsRepository = AttachmentSecuritySettingsRepository;
        }


        /// <summary>
        /// Gets the security settings.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public AttachmentSecuritySettingsModel GetSecuritySettings(int AttachmentId)
        {
            try
            {
                var SettingResult = this.m_AttachmentSecuritySettingsRepository.GetAll().Where(a => a.AttachmentId == AttachmentId).FirstOrDefault();
                if (SettingResult == null)
                {
                    return null;
                }
                var model = new AttachmentSecuritySettingsModel()
                {
                    AttachmentId = SettingResult.AttachmentId,
                    AccessCompany = SettingResult.AccessCompany,
                    AccessContactNumber = SettingResult.AccessContactNumber,
                    AccessEmail = SettingResult.AccessEmail,
                    AccessName = SettingResult.AccessName,
                    AccessPassword = SettingResult.AccessPassword,
                    AccessPayment = SettingResult.AccessPayment
                };

                return model;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Adds the specified settings.
        /// </summary>
        /// <param name="Settings">The settings.</param>
        /// <exception cref="NotImplementedException"></exception>
        public AttachmentSecuritySettingsModel Add(AttachmentSecuritySettingsModel model)
        {
            try
            {
                var entity = new AttachmentSecuritySettings
                {
                    AttachmentId = model.AttachmentId,
                    AccessCompany = model.AccessCompany,
                    AccessContactNumber = model.AccessContactNumber,
                    AccessEmail = model.AccessEmail,
                    AccessName = model.AccessName,
                    AccessPassword = model.AccessPassword,
                    AccessPayment = model.AccessPayment
                };

                this.m_AttachmentSecuritySettingsRepository.Add(entity);
                return model;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }
    }
}
