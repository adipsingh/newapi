using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.GuestLink
{
    /// <summary>
    /// Guest Link Model
    /// </summary>
    public class GuestLinksModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestLinksModel"/> class.
        /// </summary>
        public GuestLinksModel()
        {
            ExpirySettings = new ExpirySettingsModel();
            SecuritySettings = new SecuritySettingsModel();
        }

        /// <summary>
        /// Gets or sets the guest setting identifier.
        /// </summary>
        /// <value>
        /// The guest setting identifier.
        /// </value>
        public int GuestLinkID { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the link.
        /// </summary>
        /// <value>
        /// The name of the link.
        /// </value>
        public string LinkName { get; set; }

        /// <summary>
        /// Gets or sets the link URL.
        /// </summary>
        /// <value>
        /// The link URL.
        /// </value>
        public string LinkUrl { get; set; }

        /// <summary>
        /// Gets or sets the upload limit.
        /// </summary>
        /// <value>
        /// The upload limit.
        /// </value>
        public decimal UploadLimit { get; set; }

        /// <summary>
        /// Gets or sets the guest identifier.
        /// </summary>
        /// <value>
        /// The guest identifier.
        /// </value>
        public string GuestId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Int16? Status { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime? CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the expiry settings.
        /// </summary>
        /// <value>
        /// The expiry settings.
        /// </value>
        public ExpirySettingsModel ExpirySettings { get; set; }

        /// <summary>
        /// Gets or sets the security settings.
        /// </summary>
        /// <value>
        /// The security settings.
        /// </value>
        public SecuritySettingsModel SecuritySettings { get; set; }
    }
}
