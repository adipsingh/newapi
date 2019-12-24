using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels
{
    /// <summary>
    /// Common Attachment Model for All Type of attachment like User Attachmennt and Guest Attachment.
    /// </summary>
    public class AttachmentModel
    {
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        public Int64 AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { set; get; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        /// <value>
        /// The expiry date.
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the purged on.
        /// </summary>
        /// <value>
        /// The purged on.
        /// </value>
        public DateTime PurgedOn { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        [Required]
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the download URL.
        /// </summary>
        /// <value>
        /// The download URL.
        /// </value>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Converts to talsize.
        /// </summary>
        /// <value>
        /// The total size.
        /// </value>
        [Required]
        public decimal TotalSize { get; set; }

        /// <summary>
        /// Converts to talcount.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the deletion date.
        /// </summary>
        /// <value>
        /// The deletion date.
        /// </value>
        public DateTime DeletionDate { get; set; }

        /// <summary>
        /// Gets or sets the guest link identifier.
        /// </summary>
        /// <value>
        /// The guest link identifier.
        /// </value>
        public int GuestLinkID { get; set; }

        /// <summary>
        /// Gets or sets the sent by.
        /// </summary>
        /// <value>
        /// The sent by.
        /// </value>
        public string SentBy { get; set; }
    }
}
