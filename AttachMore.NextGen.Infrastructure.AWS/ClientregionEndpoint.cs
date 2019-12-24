using Amazon;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachMore.NextGen.Infrastructure.AWS
{
    public static class ClientregionEndpoint
    {
        public static RegionEndpoint AmazonGetRegionEndpointFromHost(string host)
        {
            switch (host.ToLower())
            {
                case "ap-northeast-1":
                    return RegionEndpoint.APNortheast1;
                case "ap-northeast-2":
                    return RegionEndpoint.APNortheast2;
                //case "ap-south-1":
                //return Amazon.RegionEndpoint.APSouth1;
                case "ap-southeast-1":
                    return RegionEndpoint.APSoutheast1;
                case "ap-southeast-2":
                    return RegionEndpoint.APSoutheast2;
                case "cn-north-1":
                    return RegionEndpoint.CNNorth1;
                case "eu-central-1":
                    return RegionEndpoint.EUCentral1;
                case "eu-west-1":
                    return RegionEndpoint.EUWest1;
                case "sa-east-1":
                    return RegionEndpoint.SAEast1;
                case "us-east-1":
                    return RegionEndpoint.USEast1;
                //case "us-east-2":
                //return Amazon.RegionEndpoint.USEast2;
                case "us-govcloudwest-1":
                    return RegionEndpoint.USGovCloudWest1;
                case "us-west-1":
                    return RegionEndpoint.USWest1;
                case "us-west-2":
                    return RegionEndpoint.USWest2;
                default:
                    return null;
            }
        }
    }
}
