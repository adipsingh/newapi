using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Attachment
{
    /// <summary>
    /// AttachmentNotificationSettingsModel Model
    /// </summary>
    public class AttachmentNotificationSettingsModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentNotificationSettingsModel"/> class.
        /// </summary>
        public AttachmentNotificationSettingsModel()
        {
            notifyInfo = new List<NotificationDetailsModel>();
        }
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        public int AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [when download].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [when download]; otherwise, <c>false</c>.
        /// </value>
        public bool WhenDownload { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [when expired].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [when expired]; otherwise, <c>false</c>.
        /// </value>
        public bool WhenExpired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [by email].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [by email]; otherwise, <c>false</c>.
        /// </value>
        public bool ByEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [by text].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [by text]; otherwise, <c>false</c>.
        /// </value>
        public bool ByText { get; set; }

        /// <summary>
        /// Gets or sets the notify information.
        /// </summary>
        /// <value>
        /// The notify information.
        /// </value>
        public List<NotificationDetailsModel> notifyInfo { get; set; }
    }
}
