using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink
{
    /// <summary>
    /// Guest Upload 
    /// </summary>
    public class GuestLinks
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestLinks"/> class.
        /// </summary>
        public GuestLinks()
        {
            ExpirySettings = new GuestLinks_ExpirySettings();
            SecuritySettings = new GuestLinks_SecuritySettings();
        }

        /// <summary>
        /// Gets or sets the guest setting identifier.
        /// </summary>
        /// <value>
        /// The guest setting identifier.
        /// </value>
        [Key]
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
        /// Gets or sets a value indicating whether this instance is allow add recipient.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is allow add recipient; otherwise, <c>false</c>.
        /// </value>
        public bool IsAllowAddRecipient { get; set; }

        /// <summary>
        /// Gets or sets the guest identifier.
        /// </summary>
        /// <value>
        /// The guest identifier.
        /// </value>
        public string GuestId { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        /// 
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Int16? Status { get; set; }

        /// <summary>
        /// Gets or sets the expiry setting.
        /// </summary>
        /// <value>
        /// The expiry setting.
        /// </value>
        [NotMapped]
        public virtual GuestLinks_ExpirySettings ExpirySettings { get; set; }

        /// <summary>
        /// Gets or sets the expriry security setting.
        /// </summary>
        /// <value>
        /// The expriry security setting.
        /// </value>
        [NotMapped]
        public virtual GuestLinks_SecuritySettings SecuritySettings { get; set; }
    }
}
