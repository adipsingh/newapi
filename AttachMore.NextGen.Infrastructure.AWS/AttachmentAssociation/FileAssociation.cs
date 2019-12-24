using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace AttachMore.NextGen.Infrastructure.AWS.AttachmentAssociation
{
    /// <summary>
    /// UploadAttachments class
    /// </summary>
    public class FileAssociation
    {
        /// <summary>
        /// Uploads the files.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="AccessKey">The access key.</param>
        /// <param name="SecretKey">The secret key.</param>
        /// <param name="BucketName">Name of the bucket.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <returns></returns>
        public string Upload(Stream file, string FileName, int AttachmentId)
        {
            string response = string.Empty;
            IAmazonS3 client;
            AwsClient awsClientInstance = AwsClient.GetInstance;
            try
            {
                using (client = awsClientInstance.GetClient())
                {
                    var request = new PutObjectRequest()
                    {
                        Key = "Attachment_" + AttachmentId + "/" + FileName,
                        BucketName = AwsClient.awsBucketName,
                        CannedACL = S3CannedACL.PublicReadWrite,
                        InputStream = file,
                        //ContentType = "application/zip"
                    };
                    var result = client.PutObjectAsync(request).Result;
                    response = result.HttpStatusCode.ToString();
                };
            }
            catch (AmazonS3Exception ex)
            {
                response = ex.InnerException.Message;
            }
            return response;
        }

        /// <summary>
        /// Gets the object from s3.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <param name="files">The files.</param>
        /// <returns></returns>
        public DownLoadAttachmentModel DownloadZipFileFromS3(int AttachmentId, List<Files> files)
        {
            try
            {
                DownLoadAttachmentModel downloadAttachment = new DownLoadAttachmentModel();
                List<byte[]> bytes = new List<byte[]>();
                IDictionary<string, byte[]> dictoinary = new Dictionary<string, byte[]>();

                //If Attachment has only 1 file then return the file as it is.
                if (files.Count == 1)
                {
                    var attachmentBytes = GetAttachmentFromS3(AttachmentId, files[0]);
                    downloadAttachment.FileType = files[0].FileType;
                    downloadAttachment.AttachmentBytes = attachmentBytes;
                    downloadAttachment.FileCount = files.Count;
                    downloadAttachment.FileName = files[0].FileName;
                    return downloadAttachment;
                }

                //If Attachment has more then 1 file the create zip and return the zip as attachment.
                foreach (var file in files)
                {
                    var attachmentBytes = GetAttachmentFromS3(AttachmentId, file);
                    dictoinary.Add(file.FileName, attachmentBytes);
                    bytes.Add(attachmentBytes);
                }
                downloadAttachment.FileType = "application/zip";
                downloadAttachment.FileCount = files.Count;
                downloadAttachment.AttachmentBytes = CreateZip(dictoinary);
                return downloadAttachment;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Gets the attachment from s3.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public byte[] GetAttachmentFromS3(int AttachmentId, Files file)
        {
            byte[] _byte = null;
            IAmazonS3 client;
            AwsClient awsClientInstance = AwsClient.GetInstance;
            using (client = awsClientInstance.GetClient())
            {
                using (var bytesMemotyStream = new MemoryStream())
                {
                    var request = new GetObjectRequest()
                    {
                        BucketName = AwsClient.awsBucketName,
                        Key = "Attachment_" + AttachmentId + "/" + file.FileName,
                    };
                    using (GetObjectResponse responsefile = client.GetObjectAsync(request).Result)
                    {
                        using (Stream s = responsefile.ResponseStream)
                        {
                            s.CopyTo(bytesMemotyStream);
                        }

                        return _byte = bytesMemotyStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the signed URL.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <returns></returns>
        public string GetSignedURL(string FileName, int AttachmentId)
        {
            IAmazonS3 Client;
            AwsClient awsClientInstance = AwsClient.GetInstance;
            string response = string.Empty;
            try
            {
                using (var client = awsClientInstance.GetClient())
                {
                    var Request = new GetPreSignedUrlRequest()
                    {
                        BucketName = AwsClient.awsBucketName,
                        Key = "Attachment_" + AttachmentId + "/" + FileName,
                        Expires = DateTime.Now.AddYears(2)
                    };

                    response = client.GetPreSignedURL(Request);
                }
            }
            catch (AmazonS3Exception e)
            {
                response = "Error encountered ***. Message:'{0}' when getting URL" + e.Message;
            }
            return response;
        }

        /// <summary>
        /// Creates the zip.
        /// </summary>
        /// <param name="filedetails">The filedetails.</param>
        /// <returns></returns>
        public byte[] CreateZip(IDictionary<string, byte[]> filedetails)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in filedetails)
                    {
                        ZipArchiveEntry checkEntry = zipArchive.CreateEntry(file.Key);
                        using (var entryStream = checkEntry.Open())
                        using (var b = new BinaryWriter(entryStream))
                        {
                            b.Write(file.Value);
                        }
                    }
                }
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Getfiles the information.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        public void GetfileInfo(int AttachmentId)
        {
            AwsClient awsClientInstance = AwsClient.GetInstance;
            IAmazonS3 client;

            using (client = awsClientInstance.GetClient())
            {
                var request = new ListObjectsRequest()
                {
                    BucketName = AwsClient.awsBucketName,
                    Prefix = "Attachment_" + AttachmentId,
                };

                var response = client.ListObjectsAsync(request).Result;
            };
        }
    }
}
