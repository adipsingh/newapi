using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Attachment
{
    /// <summary>
    /// Notificatoin Details model
    /// </summary>
    public class NotificationDetailsModel
    {
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        public int AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets the notify text.
        /// </summary>
        /// <value>
        /// The notify text.
        /// </value>
        public string notifyText { get; set; }

        /// <summary>
        /// Gets or sets the type of the notify.
        /// </summary>
        /// <value>
        /// The type of the notify.
        /// </value>
        public int notifyType { get; set; }
    }
}
