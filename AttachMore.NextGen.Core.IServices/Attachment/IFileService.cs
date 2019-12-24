using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.Attachment
{
    /// <summary>
    /// IFile Service
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.IBaseService{TEntity}" />
    public interface IFileService : IBaseService<Files>
    {
        /// <summary>
        /// Uploads the specified filebytes.
        /// </summary>
        /// <param name="Filebytes">The filebytes.</param>
        string Upload(Stream Filebytes, string fileName, int attachmentId, IFormFile fileDetails);

        /// <summary>
        /// Downloads the specified attachment identifier.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        //byte[] Download(int attachmentId);

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <returns></returns>
        List<Files> GetFiles(int AttachmentId);

    }
}
