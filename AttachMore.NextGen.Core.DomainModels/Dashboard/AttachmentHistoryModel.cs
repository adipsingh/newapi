using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Dashboard
{
    /// <summary>
    /// Attachment History model
    /// </summary>
    public class AttachmentHistoryModel
    {
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        public Int64 AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets the type of the attachment.
        /// </summary>
        /// <value>
        /// The type of the attachment.
        /// </value>
        public string AttachmentType { get; set; }

        /// <summary>
        /// Gets or sets the name of the attachment.
        /// </summary>
        /// <value>
        /// The name of the attachment.
        /// </value>
        public string AttachmentName { get; set; }

        /// <summary>
        /// Gets or sets the expiried on.
        /// </summary>
        /// <value>
        /// The expiried on.
        /// </value>
        public DateTime AttachmentExpiriedOn { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime AttachmentCreationDate { get; set; }

        /// <summary>
        /// Gets or sets the attachment purged date.
        /// </summary>
        /// <value>
        /// The attachment purged date.
        /// </value>
        public DateTime AttachmentPurgedDate { get; set; }

        /// <summary>
        /// Converts to taldownload.
        /// </summary>
        /// <value>
        /// The total download.
        /// </value>
        public int TotalDownload { get; set; }

        /// <summary>
        /// Gets or sets the size of the attachment.
        /// </summary>
        /// <value>
        /// The size of the attachment.
        /// </value>
        public decimal AttachmentSize { get; set; }

        /// <summary>
        /// Attachment Status
        /// </summary>
        public int Status { get; set; }
    }
}
