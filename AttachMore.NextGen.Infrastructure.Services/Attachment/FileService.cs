using AttachMore.NextGen.Core.IRepositories.Attachment;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Core.IServices.Log;
using AttachMore.NextGen.Infrastructure.AWS;
using AttachMore.NextGen.Infrastructure.AWS.AttachmentAssociation;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Attachment
{
    /// <summary>
    /// File Service
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Services.BaseService{TEntity}" />
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Attachment.IFileService{TEntity}" />
    public class FileService : BaseService<Files>, IFileService
    {
        /// <summary>
        /// The m upload attachments
        /// </summary>
        FileAssociation m_UploadAttachments = new FileAssociation();

        /// <summary>
        /// The m file repository
        /// </summary>
        private readonly IFileRepository<Files> m_FileRepository;

        /// <summary>
        /// The m log service
        /// </summary>
        private readonly ILogService m_LogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileService{TEntity}"/> class.
        /// </summary>
        /// <param name="FileRepository">The file repository.</param>
        public FileService(IFileRepository<Files> FileRepository,ILogService LogService)
        {
            this.m_FileRepository = FileRepository;
            this.m_LogService = LogService;
        }


        /// <summary>
        /// Uploads the specified file bytes.
        /// </summary>
        /// <param name="fileBytes">The file bytes.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="fileDetails">The file details.</param>
        /// <returns></returns>
        public string Upload(Stream fileBytes, string fileName, int attachmentId, IFormFile fileDetails)
        {
            string signedURL = string.Empty;
            try
            {
                var UploadResult = m_UploadAttachments.Upload(fileBytes, fileName, attachmentId);

                if (UploadResult == HttpStatusCode.OK.ToString())
                {
                    var FileS3Url = m_UploadAttachments.GetSignedURL(fileName, attachmentId);

                    var entity = new Files()
                    {
                        Date = DateTime.Now,
                        Status = 1,
                        AttachmentId = attachmentId,
                        FileSize = (Int32)fileDetails.Length,
                        FileType = fileDetails.ContentType,
                        FileName = fileDetails.FileName,
                        FileURL = FileS3Url
                    };
                    this.m_FileRepository.Add(entity);
                    return "Success";
                }
                return UploadResult;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        public List<Files> GetFiles(int AttachmentId)
        {
            try
            {
                List<Files> result = this.m_FileRepository.GetAll().Where(a => a.AttachmentId == AttachmentId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }
    }
}
