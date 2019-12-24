using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.ApplicationSettings
{
    /// <summary>
    /// Mail Setting
    /// </summary>
    public class MailSettings
    {
        /// <summary>
        /// Gets or sets the SMTP server.
        /// </summary>
        /// <value>
        /// The SMTP server.
        /// </value>
        public static string smtpServer { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public static int port { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public static string userName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public static string password { get; set; }

        /// <summary>
        /// Gets or sets the reset link.
        /// </summary>
        /// <value>
        /// The reset link.
        /// </value>
        public static string ResetLink { get; set; }
    }
}
