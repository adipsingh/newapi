using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment
{
    /// <summary>
    /// Download Entity Model
    /// </summary>
    public class Download
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int64 Id { get; set; }

        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        public int AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets the access email.
        /// </summary>
        /// <value>
        /// The access email.
        /// </value>
        public string AccessEmail { get; set; }

        /// <summary>
        /// Gets or sets the access password.
        /// </summary>
        /// <value>
        /// The access password.
        /// </value>
        public string AccessPassword { get; set; }

        /// <summary>
        /// Gets or sets the download date.
        /// </summary>
        /// <value>
        /// The download date.
        /// </value>
        public DateTime DownloadDate { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the access amount.
        /// </summary>
        /// <value>
        /// The access amount.
        /// </value>
        public decimal AccessAmount { get; set; }
    }
}
