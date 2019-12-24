using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Attachment
{
    /// <summary>
    /// DownLoadAttachmentModel Class
    /// </summary>
    public class DownLoadAttachmentModel
    {
        /// <summary>
        /// Gets or sets the attachment bytes.
        /// </summary>
        /// <value>
        /// The attachment bytes.
        /// </value>
        public byte[] AttachmentBytes { get; set; }

        /// <summary>
        /// Gets or sets the file count.
        /// </summary>
        /// <value>
        /// The file count.
        /// </value>
        public int FileCount { get; set; }

        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        /// <value>
        /// The type of the file.
        /// </value>
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }
    }
}
