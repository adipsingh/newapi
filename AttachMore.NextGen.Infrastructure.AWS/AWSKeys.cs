using System;
using System.Collections.Generic;
using System.Text;

namespace AttachMore.NextGen.Infrastructure.AWS
{
    /// <summary>
    /// AWSKeys configuration class
    /// </summary>
    public static class AWSKeys
    {
        /// <summary>
        /// Gets or sets the access key.
        /// </summary>
        /// <value>
        /// The access key.
        /// </value>
        public static string accessKey { get; set; }

        /// <summary>
        /// Gets or sets the secrate key.
        /// </summary>
        /// <value>
        /// The secrate key.
        /// </value>
        public static string secrateKey { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public static string region { get; set; }
    }
}
