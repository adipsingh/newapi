using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AttachcMore.NextGen.Core.IAWS.IAttachmentAssociation
{
    /// <summary>
    ///  IUploadAttachments Interface
    /// </summary>
    public interface IUploadAttachments
    {
        /// <summary>
        /// Uploads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="AccessKey">The access key.</param>
        /// <param name="SecretKey">The secret key.</param>
        /// <param name="BucketName">Name of the bucket.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <returns></returns>
        string Upload(Stream file, string FileName, int AttachmentId);
    }
}
