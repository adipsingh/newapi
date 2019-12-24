using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment
{
    /// <summary>
    /// Log Entity
    /// </summary>
    public class Logs
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the log entity.
        /// </summary>
        /// <value>
        /// The name of the log entity.
        /// </value>
        public string LogEntityName { get; set; }

        /// <summary>
        /// Gets or sets the file identifier.
        /// </summary>
        /// <value>
        /// The file identifier.
        /// </value>
        public int LogEntityId { get; set; }

        /// <summary>
        /// Gets or sets the type of the activity log.
        /// </summary>
        /// <value>
        /// The type of the activity log.
        /// </value>
        public int ActivityLogType { get; set; }

        /// <summary>
        /// Gets or sets the log description.
        /// </summary>
        /// <value>
        /// The log description.
        /// </value>
        public string LogDescription { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>
        /// The ip address.
        /// </value>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public int Status { get; set; }
    }
}
