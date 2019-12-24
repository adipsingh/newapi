using Amazon;
using Amazon.S3;
using AttachMore.NextGen.Core.DomainModels.ApplicationSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachMore.NextGen.Infrastructure.AWS
{
    /// <summary>
    /// AwsClient connection class
    /// </summary>
    public sealed class AwsClient
    {
        /// <summary>
        /// Gets or sets the accesskey.
        /// </summary>
        /// <value>
        /// The accesskey.
        /// </value>
        public static string _Accesskey
        {
            get
            {
                return AWSConfigSettings.awsAccessKeyId;
            }
        }

        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        /// <value>
        /// The secret key.
        /// </value>
        public static string _SecretKey
        {
            get
            {
                return AWSConfigSettings.awsSecretAccesskey;
            }
        }


        /// <summary>
        /// Gets the aws region end point.
        /// </summary>
        /// <value>
        /// The aws region end point.
        /// </value>
        public static string awsRegionEndPoint
        {
            get
            {
                return AWSConfigSettings.awsRegionEndpoint;
            }
        }

        /// <summary>
        /// Gets the name of the aws bucket.
        /// </summary>
        /// <value>
        /// The name of the aws bucket.
        /// </value>
        public static string awsBucketName
        {
            get
            {
                return AWSConfigSettings.awsBucketName;
            }
        }

        /// <summary>
        /// The instance
        /// </summary>
        private static AwsClient instance = null;

        /// <summary>
        /// Gets the get instance.
        /// </summary>
        /// <value>
        /// The get instance.
        /// </value>
        public static AwsClient GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AwsClient();
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
        }

        /// <summary>
        /// The client
        /// </summary>
        private static AmazonS3Client client = null;

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <returns></returns>
        public IAmazonS3 GetClient()
        {
            var client = new AmazonS3Client(_Accesskey, _SecretKey, Region);
            return client;
        }

        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        private static RegionEndpoint Region
        {
            get
            {
                return ClientregionEndpoint.AmazonGetRegionEndpointFromHost(awsRegionEndPoint);
            }
        }

    }
}
