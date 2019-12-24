using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment
{
    /// <summary>
    /// AttachmentNotificationSettings model
    /// </summary>
    public class AttachmentNotificationSettings
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
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        /// <value>
        /// The updated on.
        /// </value>
        public DateTime? UpdatedOn { get; set; }
    }
}
