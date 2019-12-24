using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Component.Constants
{
    /// <summary>
    /// Constancs of application
    /// </summary>
    public static class Constant
    {
        /*Forgot Password Mail Constants*/
        /// <summary>
        /// The reset password URL
        /// </summary>
        public const string ResetPassword = "://" + "http://attachmore.incredtech.com" + "/account/ResetPassword#token=";

        /// <summary>
        /// The subject
        /// </summary>
        public const string Subject = "AttachMore ResetPassword";
    }
}
