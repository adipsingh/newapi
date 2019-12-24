using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.GuestLink
{
    /// <summary>
    /// Seurity Setting Model
    /// </summary>
    public class SecuritySettingsModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the gust link identifier.
        /// </summary>
        /// <value>
        /// The gust link identifier.
        /// </value>
        public int GustLinkId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GuestLinks_SecuritySettings"/> is email.
        /// </summary>
        /// <value>
        ///   <c>true</c> if email; otherwise, <c>false</c>.
        /// </value>
        public bool Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GuestLinks_SecuritySettings"/> is company.
        /// </summary>
        /// <value>
        ///   <c>true</c> if company; otherwise, <c>false</c>.
        /// </value>
        public bool Company { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GuestLinks_SecuritySettings"/> is name.
        /// </summary>
        /// <value>
        ///   <c>true</c> if name; otherwise, <c>false</c>.
        /// </value>
        public bool Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GuestLinks_SecuritySettings"/> is phone.
        /// </summary>
        /// <value>
        ///   <c>true</c> if phone; otherwise, <c>false</c>.
        /// </value>
        public bool Phone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GuestLinks_SecuritySettings"/> is password.
        /// </summary>
        /// <value>
        ///   <c>true</c> if password; otherwise, <c>false</c>.
        /// </value>
        public bool Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [password protected page].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [password protected page]; otherwise, <c>false</c>.
        /// </value>
        public bool PasswordProtectedPage { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
