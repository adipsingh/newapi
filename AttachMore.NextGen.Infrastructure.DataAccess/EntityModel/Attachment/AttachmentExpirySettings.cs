using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment
{
    /// <summary>
    /// AttachmentExpirySettings Model
    /// </summary>
    public class AttachmentExpirySettings
    {

        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        [Key]
        public int AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets the downloads limit.
        /// </summary>
        /// <value>
        /// The downloads limit.
        /// </value>
        public int DownloadsLimit { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        /// <value>
        /// The expiry date.
        /// </value>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the deletion date.
        /// </summary>
        /// <value>
        /// The deletion date.
        /// </value>
        public DateTime DeletionDate { get; set; }
    }
}
