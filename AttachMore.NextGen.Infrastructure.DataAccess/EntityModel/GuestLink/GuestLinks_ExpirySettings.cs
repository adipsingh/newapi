using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink
{
    /// <summary>
    /// Guest Link Expiry Setting
    /// </summary>
    public class GuestLinks_ExpirySettings
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
        /// Gets or sets the gust link identifier.
        /// </summary>
        /// <value>
        /// The gust link identifier.
        /// </value>
        public int GustLinkId { get; set; }

        /// <summary>
        /// Gets or sets the upload limit.
        /// </summary>
        /// <value>
        /// The upload limit.
        /// </value>
        public int UploadLimit { get; set; }

        /// <summary>
        /// Gets or sets the number of uses.
        /// </summary>
        /// <value>
        /// The number of uses.
        /// </value>
        public int NumberOfUses { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }
    }
}
