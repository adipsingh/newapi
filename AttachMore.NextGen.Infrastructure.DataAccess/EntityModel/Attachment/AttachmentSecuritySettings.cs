using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment
{
    /// <summary>
    /// AttachmentSecuritySettings Class
    /// </summary>
    public class AttachmentSecuritySettings
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
        /// Gets or sets the access password.
        /// </summary>
        /// <value>
        /// The access password.
        /// </value>
        public string AccessPassword { get; set; }

        /// <summary>
        /// Gets or sets the access email.
        /// </summary>
        /// <value>
        /// The access email.
        /// </value>
        public string AccessEmail { get; set; }

        /// <summary>
        /// Gets or sets the name of the access.
        /// </summary>
        /// <value>
        /// The name of the access.
        /// </value>
        public string AccessName { get; set; }

        /// <summary>
        /// Gets or sets the access company.
        /// </summary>
        /// <value>
        /// The access company.
        /// </value>
        public string AccessCompany { get; set; }

        /// <summary>
        /// Gets or sets the access contact number.
        /// </summary>
        /// <value>
        /// The access contact number.
        /// </value>
        public string AccessContactNumber { get; set; }

        /// <summary>
        /// Gets or sets the access payment.
        /// </summary>
        /// <value>
        /// The access payment.
        /// </value>
        public decimal AccessPayment { get; set; }
    }
}
