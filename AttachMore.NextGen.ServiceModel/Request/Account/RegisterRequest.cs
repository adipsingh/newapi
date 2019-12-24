using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.ServiceModel.Request.Account
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.ServiceModel.Request.RequestBase" />
    public class RegisterRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone numner.
        /// </summary>
        /// <value>
        /// The phone numner.
        /// </value>
        [Required]
        public string PhoneNumber { get; set; }
    }
}
