using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Component.Enums.ActivityLogs
{
    public enum LogsActivityType
    {
        /// <summary>
        /// The file upload
        /// </summary>
        FileUpload = 1,

        /// <summary>
        /// The file download
        /// </summary>
        FileDownload = 2,

        /// <summary>
        /// The file expired
        /// </summary>
        FileExpired = 3,

        /// <summary>
        /// The file pruged
        /// </summary>
        FilePruged = 4,

        /// <summary>
        /// The sign up
        /// </summary>
        SignUp = 5,

        /// <summary>
        /// The login
        /// </summary>
        Login = 6,

        /// <summary>
        /// The log out
        /// </summary>
        LogOut = 7,

        /// <summary>
        /// The attachment upload
        /// </summary>
        AttachmentUpload = 8,
        /// <summary>
        /// The attachment expiry settings
        /// </summary>
        AttachmentExpirySettings = 9,

        /// <summary>
        /// The attachment notification settings
        /// </summary>
        AttachmentNotificationSettings = 10,

        /// <summary>
        /// The attachment security settings
        /// </summary>
        AttachmentSecuritySettings = 11
    }
}
