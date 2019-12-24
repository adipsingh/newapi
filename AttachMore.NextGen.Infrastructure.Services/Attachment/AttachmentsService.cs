using AttachMore.NextGen.Core.IRepositories.Attachment;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using AttachMore.NextGen.Core.DomainModels.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttachMore.NextGen.Infrastructure.AWS.AttachmentAssociation;
using AttachMore.NextGen.ServiceModel.Request.Attachment;
using AttachMore.NextGen.Core.IServices.Account;
using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using AttachMore.NextGen.Core.IServices.Log;
using AttachMore.NextGen.Infrastructure.Component.Enums.ActivityLogs;
using AttachMore.NextGen.Infrastructure.Component.Mapper;
using AttachMore.NextGen.Infrastructure.Component.Enums.Attachment;
using AttachMore.NextGen.Core.DomainModels;

namespace AttachMore.NextGen.Infrastructure.Services.Attachment
{
    /// <summary>
    /// AttachmentsService Class
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Services.BaseService{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.Attachments}" />
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Attachment.IAttachmentsService" />
    public class AttachmentsService : IAttachmentsService
    {
        /// <summary>
        /// The m upload attachments
        /// </summary>
        FileAssociation m_FileAssociation = new FileAssociation();

        /// <summary>
        /// The m attachment repository
        /// </summary>
        private IAttachmentsRepository m_AttachmentRepository;

        /// <summary>
        /// The m download repository
        /// </summary>
        private IDownloadRepository m_DownloadRepository;

        /// <summary>
        /// The m account service
        /// </summary>
        private IAccountService m_AccountService;

        /// <summary>
        /// The m log service
        /// </summary>
        private ILogService m_LogService;

        /// <summary>
        /// The m attachment security setting service
        /// </summary>
        private IAttachmentSecuritySettingsService m_AttachmentSecuritySettingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentsService" /> class.
        /// </summary>
        public AttachmentsService(IAttachmentsRepository attachmentRepository, IDownloadRepository downloadRepository,
            IAttachmentSecuritySettingsService AttachmentSecuritySettingService, IAccountService accountService, ILogService LogService)
        {
            m_AttachmentRepository = attachmentRepository;
            m_DownloadRepository = downloadRepository;
            m_AttachmentSecuritySettingService = AttachmentSecuritySettingService;
            m_AccountService = accountService;
            this.m_LogService = LogService;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public AttachmentModel Add(AttachmentModel Model, string userEmail, string SentBy)
        {
            try
            {
                //var result = AttachmentMapper<AttachmentsModel, Attachments>.Map(entity);

                var user = LoggedInUser(userEmail);
                Attachments attachments = new Attachments()
                {
                    AccountId = Model.AccountId,
                    AttachmentId = Model.AttachmentId,
                    CreationDate = DateTime.Now,
                    DeletedOn = Model.DeletionDate,
                    DownloadUrl = Model.DownloadUrl,
                    ExpiriedOn = Model.ExpiryDate,
                    PurgedOn = Model.ExpiryDate.AddDays(3),
                    Name = Model.Name,
                    TotalSize = Model.TotalSize,
                    Status = Model.Status,
                    UserId = user.Id,
                    SentBy = SentBy == "Guest" ? (int)AttachmentSentByEnum.GuestSent : (int)AttachmentSentByEnum.WebSent,
                    GuestLinkId = Model.GuestLinkID == 0 ? 0 : Model.GuestLinkID
                };

                m_AttachmentRepository.Add(attachments);
                Model.AttachmentId = attachments.AttachmentId;
                Model.DownloadUrl = attachments.DownloadUrl + "/" + attachments.AttachmentId;
                Model.SentBy = attachments.SentBy == (int)AttachmentSentByEnum.GuestSent ? AttachmentSentByEnum.GuestSent.ToString() : AttachmentSentByEnum.WebSent.ToString();

                this.m_LogService.LogActivity((int)LogsActivityType.FileUpload, "File Uploaded by Guest User", (int)attachments.AttachmentId, "Attachment", user.Id);


                return Model;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Updates the specified attachment name.
        /// </summary>
        /// <param name="AttachmentName">Name of the attachment.</param>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string Update(string AttachmentName, int attachmentId, string userEmail)
        {
            try
            {
                //var attachment = this.m_AttachmentRepository.GetById(attachmentId);
                var user = this.m_AttachmentRepository.Query<User>().Where(a => a.Email == userEmail).FirstOrDefault();
                var attachment = this.m_AttachmentRepository.Query<Attachments>().Where(a => a.AttachmentId == attachmentId && a.UserId == user.Id).FirstOrDefault();
                if (attachment != null)
                {
                    var userId = LoggedInUser(userEmail).Id;
                    attachment.Name = AttachmentName;
                    m_AttachmentRepository.Edit(attachment);
                    return attachment.Name;
                }
                return "No Attachment Found";

            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Downloads the specified attachment identifier.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns></returns>
        public DownLoadAttachmentModel DownloadAttachment(AttachmentDownloadRequest model, string LoggedInUserEmail)
        {
            Download entity = new Download();
            DownLoadAttachmentModel DownloadAttachment = new DownLoadAttachmentModel();
            byte[] bytes = null;

            try
            {
                var user = LoggedInUser(LoggedInUserEmail);
                if (IsAuthorizedUser(model))
                {
                    var result = this.m_AttachmentRepository.Query<Files>().Where(a => a.AttachmentId == model.AttachmentId).ToList();

                    if (result.Count == 0)
                    {
                        DownloadAttachment.AttachmentBytes = bytes;
                        DownloadAttachment.FileCount = result.Count;
                        return DownloadAttachment;
                    }

                    entity.AccessEmail = model.AccessEmail == "" ? null : model.AccessEmail;
                    entity.AccessPassword = model.Password;
                    entity.DownloadDate = DateTime.Now;
                    entity.AttachmentId = model.AttachmentId;
                    entity.UserId = user.Id;
                    m_DownloadRepository.Add(entity);

                    DownloadAttachment = m_FileAssociation.DownloadZipFileFromS3(model.AttachmentId, result);
                    this.m_LogService.LogActivity((int)LogsActivityType.FileUpload, "File Download by User" + user.FirstName + " " + user.LastName + "", (int)model.AttachmentId, "Attachment", user.Id);
                    return DownloadAttachment;
                }
                return null;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Gets the attachment detail.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <returns></returns>
        public AttachmentDetailModel GetAttachmentDetail(int AttachmentId)
        {
            try
            {
                var fileDetails = m_AttachmentRepository.Query<Files>().Where(a => a.AttachmentId == AttachmentId).ToList();
                var attachment = m_AttachmentRepository.GetAll().Where(a => a.AttachmentId == AttachmentId).FirstOrDefault();
                var result = new AttachmentDetailModel()
                {
                    AttachmentID = attachment.AttachmentId,
                    AttachmentName = attachment.Name,
                    AttachmentSize = attachment.TotalSize,
                    FileDetails = fileDetails
                };
                return result;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Determines whether [is authorized user] [the specified model].
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <c>true</c> if [is authorized user] [the specified model]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsAuthorizedUser(AttachmentDownloadRequest model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.AccessEmail) && string.IsNullOrEmpty(model.Password))
                {
                    return true;
                }
                var securitySettings = m_AttachmentSecuritySettingService.GetSecuritySettings(model.AttachmentId);
                if (securitySettings == null)
                {
                    var message = "Security settings Not found for this Attachment.";
                    throw new Exception(message);
                }
                if (securitySettings.AccessPassword == model.Password && securitySettings.AccessEmail == model.AccessEmail)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Loggeds the in user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        private UserModel LoggedInUser(string email)
        {
            var result = this.m_AccountService.GetUserInfo(email);
            return result;
        }
    }
}
