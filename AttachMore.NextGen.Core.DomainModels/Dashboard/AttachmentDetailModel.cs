using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Dashboard
{
    /// <summary>
    /// Attachment Model
    /// </summary>
    public class AttachmentDetailModel
    {
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        public int AttachmentId { get; set; }

        /// <summary>
        /// Attachment Download URL 
        /// </summary>
        public string DownloadURL { get; set; }

        /// <summary>
        /// Attachment Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public int Status { get; set; }

        /// <summary>
        /// Attachment Total Size
        /// </summary>
        public decimal AttachmentSize { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the purged on.
        /// </summary>
        /// <value>
        /// The purged on.
        /// </value>
        public DateTime? PurgedOn { get; set; }

        /// <summary>
        /// Converts to taldownload.
        /// </summary>
        /// <value>
        /// The total download.
        /// </value>
        public int TotalDownload { get; set; }

        //===============Expiry settings

        /// <summary>
        /// Gets or sets the expired on.
        /// </summary>
        /// <value>
        /// The expired on.
        /// </value>
        public DateTime? ExpiredOn { get; set; }

        /// <summary>
        /// Gets or sets the download limit.
        /// </summary>
        /// <value>
        /// The download limit.
        /// </value>
        public int DownloadLimit { get; set; }

        /// <summary>
        /// Gets or sets the delete after.
        /// </summary>
        /// <value>
        /// The delete after.
        /// </value>
        public DateTime? DeleteAfter { get; set; }

        //=====================Notification Settings 

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

        //==============Security Settings
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
        /// Gets or sets the access contect number.
        /// </summary>
        /// <value>
        /// The access contect number.
        /// </value>
        public string AccessContectNumber { get; set; }

        /// <summary>
        /// Gets the access company.
        /// </summary>
        /// <value>
        /// The access company.
        /// </value>
        public string AccessCompany { get; set; }

        /// <summary>
        /// Gets or sets the access payment.
        /// </summary>
        /// <value>
        /// The access payment.
        /// </value>
        public decimal AccessPayment { get; set; }

        /// <summary>
        /// Gets or sets the payments.
        /// </summary>
        /// <value>
        /// The payments.
        /// </value>
        public int Payments { get; set; }

        /// <summary>
        /// Gets or sets the uploaded by.
        /// </summary>
        /// <value>
        /// The uploaded by.
        /// </value>
        public string UploadedBy { get; set; }

        /// <summary>
        /// Total Count of file in attachment.
        /// </summary>
        public int TotalFileInAttachment { get; set; }

        /// <summary>
        /// Files detail Model
        /// </summary>
        public List<Files> FilesDetail { get; set; }
    }
}
