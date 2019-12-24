using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Attachment
{
    /// <summary>
    /// AttachmentDetailModel class
    /// </summary>
    public class AttachmentDetailModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentDetailModel"/> class.
        /// </summary>
        public AttachmentDetailModel()
        {
            FileDetails = new List<Files>();
        }

        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        public Int64 AttachmentID { get; set; }

        /// <summary>
        /// Gets or sets the name of the attachment.
        /// </summary>
        /// <value>
        /// The name of the attachment.
        /// </value>
        public string AttachmentName { get; set; }

        /// <summary>
        /// Gets or sets the size of the attachment.
        /// </summary>
        /// <value>
        /// The size of the attachment.
        /// </value>
        public decimal AttachmentSize { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the file details.
        /// </summary>
        /// <value>
        /// The file details.
        /// </value>
        public List<Files> FileDetails { get; set; }
    }
}
