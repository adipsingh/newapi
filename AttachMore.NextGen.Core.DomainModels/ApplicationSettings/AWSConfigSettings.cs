using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.ApplicationSettings
{
    /// <summary>
    /// AWSConfigSettings setting class for AWS
    /// </summary>
    public class AWSConfigSettings
    {
        /// <summary>
        /// Gets or sets the aws error log bucket.
        /// </summary>
        /// <value>
        /// The aws error log bucket.
        /// </value>
        public static string awsErrorLogBucket { get; set; }

        /// <summary>
        /// Gets or sets the name of the aws bucket.
        /// </summary>
        /// <value>
        /// The name of the aws bucket.
        /// </value>
        public static string awsBucketName { get; set; }

        /// <summary>
        /// Gets or sets the aws access key identifier.
        /// </summary>
        /// <value>
        /// The aws access key identifier.
        /// </value>
        public static string awsAccessKeyId { get; set; }

        /// <summary>
        /// Gets or sets the aws secret accesskey.
        /// </summary>
        /// <value>
        /// The aws secret accesskey.
        /// </value>
        public static string awsSecretAccesskey { get; set; }

        /// <summary>
        /// Gets or sets the aws region endpoint.
        /// </summary>
        /// <value>
        /// The aws region endpoint.
        /// </value>
        public static string awsRegionEndpoint { get; set; }

    }
}
