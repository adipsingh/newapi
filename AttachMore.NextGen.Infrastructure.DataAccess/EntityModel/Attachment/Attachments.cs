using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment
{
    /// <summary>
    /// Attachments Entity
    /// </summary>
    public class Attachments
    {
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        [Key]
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
        /// Converts to talsize.
        /// </summary>
        /// <value>
        /// The total size.
        /// </value>
        [Required]
        public decimal TotalSize { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        /// <value>
        /// The expiry date.

        public DateTime ExpiriedOn { get; set; }

        /// <summary>
        /// Gets or sets the purge on.
        /// </summary>
        /// <value>
        /// The purge on.
        /// </value>
        public DateTime PurgedOn { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

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
        /// Gets or sets the deletion date.
        /// </summary>
        /// <value>
        /// The deletion date.
        /// </value>
        public DateTime DeletedOn { get; set; }

        /// <summary>
        /// Gets or sets the guest link identifier.
        /// </summary>
        /// <value>
        /// The guest link identifier.
        /// </value>
        public int GuestLinkId { get; set; }

        /// <summary>
        /// Gets or sets the send by.
        /// </summary>
        /// <value>
        /// The send by.
        /// </value>
        public int SentBy { get; set; }
    }
}
