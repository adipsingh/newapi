using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment
{
    /// <summary>
    /// Notificatoin Details 
    /// </summary>
    public class NotificationDetails
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        public int AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets the notiication send on.
        /// </summary>
        /// <value>
        /// The notiication send on.
        /// </value>
        public string NotiicationSendOn { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int type { get; set; }
    }
}
