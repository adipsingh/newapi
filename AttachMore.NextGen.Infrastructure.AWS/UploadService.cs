using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AttachMore.NextGen.Infrastructure.AWS
{
    public class UploadService
    {
        AmazonS3Config config = new AmazonS3Config
        {
            RegionEndpoint = RegionEndpoint.USEast1, //its default region set by amazon
        };

        /// <summary>
        /// Uploads the files.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="AccessKey">The access key.</param>
        /// <param name="SecretKey">The secret key.</param>
        /// <param name="BucketName">Name of the bucket.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <returns></returns>
        public string UploadFiles(Stream file, string AccessKey, string SecretKey, string BucketName, string FileName, int AttachmentId)
        {
            string response = string.Empty;
            IAmazonS3 client;
            try
            {
                using (client = new AmazonS3Client(AccessKey, SecretKey, config))
                {
                    var request = new PutObjectRequest()
                    {
                        Key = "Attachment_" + AttachmentId + "/" + FileName,
                        BucketName = BucketName,
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
        /// Gets the signed URL.
        /// </summary>
        /// <param name="AccessKey">The access key.</param>
        /// <param name="SecretKey">The secret key.</param>
        /// <param name="BucketName">Name of the bucket.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <returns></returns>
        public string GetSignedURL(string AccessKey, string SecretKey, string BucketName, string FileName, int AttachmentId)
        {
            string response = string.Empty;
            try
            {
                using (var client = new AmazonS3Client(AccessKey, SecretKey, config))
                {
                    var Request = new GetPreSignedUrlRequest()
                    {
                        BucketName = BucketName,
                        Key = "harjap" + AttachmentId,
                        Expires = DateTime.Now.AddDays(50)
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
        /// Gets the file from s3.
        /// </summary>
        /// <param name="AccessKey">The access key.</param>
        /// <param name="SecretKey">The secret key.</param>
        /// <param name="BucketName">Name of the bucket.</param>
        /// <returns></returns>
        public byte[] GetFileFromS3(string AccessKey, string SecretKey, string BucketName, int AttachmentId)
        {
            MemoryStream ms = new MemoryStream();
            IAmazonS3 client;
            using (client = new AmazonS3Client(AccessKey, SecretKey, config))
            {
                var request = new GetObjectRequest()
                {
                    BucketName = BucketName,
                    Key = "Attachment_" + AttachmentId + "/ImportentCommandsforVisualstudioCMD.txt",
                };

                using (GetObjectResponse response = client.GetObjectAsync(request).Result)
                using (Stream s = response.ResponseStream)
                {
                    s.CopyTo(ms);
                };
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Gets the object from s3.
        /// </summary>
        /// <param name="AccessKey">The access key.</param>
        /// <param name="SecretKey">The secret key.</param>
        /// <param name="BucketName">Name of the bucket.</param>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <param name="files">The files.</param>
        /// <returns></returns>
        public byte[] GetObjectFromS3(string AccessKey, string SecretKey, string BucketName, int AttachmentId, List<Files> files)
        {
            var content = new MultipartContent();
            IAmazonS3 client;
            ///try
            //{
            using (client = new AmazonS3Client(AccessKey, SecretKey, config))
            {
                List<byte[]> bytes = new List<byte[]>();
                IDictionary<string, byte[]> dictoinary = new Dictionary<string, byte[]>();


                foreach (var file in files)
                {
                    byte[] _byte = null;
                    using (var bytesMemotyStream = new MemoryStream())
                    {
                        var request = new GetObjectRequest()
                        {
                            BucketName = BucketName,
                            Key = "Attachment_" + AttachmentId + "/" + file.FileName,
                        };
                        using (GetObjectResponse responsefile = client.GetObjectAsync(request).Result)
                        {
                            using (Stream s = responsefile.ResponseStream)
                            {
                                s.CopyTo(bytesMemotyStream);
                            }

                            _byte = bytesMemotyStream.ToArray();
                            dictoinary.Add(file.FileName, _byte);
                            bytes.Add(_byte);
                        }
                    }
                }

                return CreateZip(dictoinary);

            }
            //}
            //catch (Exception ex)
            //{
            //    return new HttpResponseMessage(HttpStatusCode.BadRequest)
            //    {
            //        Content = new StringContent(ex.Message + ":" + ex.InnerException)
            //    };
            //}
        }

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



        public HttpResponseMessage Generate(Files file, MultipartContent content)
        {
            var stream = new MemoryStream();
            // processing the stream.

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = content
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = file.FileName
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");

            return result;
        }
    }
}
