using AttachMore.NextGen.Core.DomainModels.ApplicationSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Service.API.ExtantionMethods
{
    /// <summary>
    /// SetApplicationComponents this class will set application.json keys to model class
    /// </summary>
    public static class SetApplicationComponents
    {
        /// <summary>
        /// Awses the configuration.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="configurations">The configurations.</param>
        /// <returns></returns>
        public static IServiceCollection AWSConfiguration(this IServiceCollection service, IConfiguration configurations)
        {
            var settingConfig = configurations.GetSection("AWSConfigSettings");
            var settings = settingConfig.Get<AWSConfigSettings>();
            return service;
        }

        /// <summary>
        /// Mails the settings.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="configurations">The configurations.</param>
        /// <returns></returns>
        public static IServiceCollection MailSettings(this IServiceCollection service, IConfiguration configurations)
        {
            var settingConfig = configurations.GetSection("MailSettings");
            var mailSetting = settingConfig.Get<MailSettings>();
            return service;
        }

        /// <summary>
        /// Applications the setting.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="configurations">The configurations.</param>
        /// <returns></returns>
        public static IServiceCollection ApplicationSetting(this IServiceCollection service, IConfiguration configurations)
        {
            var settingConfig = configurations.GetSection("Applications");
            var ApplicationSettings = settingConfig.Get<Application>();
            return service;
        }
    }
}
