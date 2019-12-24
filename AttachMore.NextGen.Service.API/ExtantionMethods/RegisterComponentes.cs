using AttachMore.NextGen.Core.IRepositories;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Core.IRepositories.Attachment;
using AttachMore.NextGen.Core.IRepositories.Common;
using AttachMore.NextGen.Core.IRepositories.Dashboard;
using AttachMore.NextGen.Core.IRepositories.GuestLink;
using AttachMore.NextGen.Core.IRepositories.Log;
using AttachMore.NextGen.Core.IRepositories.Package;
using AttachMore.NextGen.Core.IServices.Account;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Core.IServices.Common;
using AttachMore.NextGen.Core.IServices.Dashboard;
using AttachMore.NextGen.Core.IServices.GuestLink;
using AttachMore.NextGen.Core.IServices.Log;
using AttachMore.NextGen.Core.IServices.Package;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.Repositories;
using AttachMore.NextGen.Infrastructure.Repositories.Account;
using AttachMore.NextGen.Infrastructure.Repositories.Attachment;
using AttachMore.NextGen.Infrastructure.Repositories.Common;
using AttachMore.NextGen.Infrastructure.Repositories.Dashboard;
using AttachMore.NextGen.Infrastructure.Repositories.GuestLink;
using AttachMore.NextGen.Infrastructure.Repositories.Log;
using AttachMore.NextGen.Infrastructure.Repositories.Package;
using AttachMore.NextGen.Infrastructure.Services.Account;
using AttachMore.NextGen.Infrastructure.Services.Attachment;
using AttachMore.NextGen.Infrastructure.Services.Common;
using AttachMore.NextGen.Infrastructure.Services.Dashboard;
using AttachMore.NextGen.Infrastructure.Services.GuestLink;
using AttachMore.NextGen.Infrastructure.Services.Log;
using AttachMore.NextGen.Infrastructure.Services.Package;
using AttachMore.NextGen.Service.API.Controllers.Account;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Service.API.ExtantionMethods
{
    /// <summary>
    /// Register Componentes
    /// </summary>
    public static class RegisterComponentes
    {
        /// <summary>
        /// Registers the di.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<,>));

            services.AddTransient(typeof(AccountAssociationController<>), typeof(AccountAssociationController<>));

            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ILoginRepository, LoginRepository>();

            services.AddTransient<IRegisterService, RegisterService>();
            services.AddTransient<IRegisterRepository, RegisterRepository>();

            services.AddTransient(typeof(IFileRepository<>), typeof(FileRepository<>));
            services.AddTransient(typeof(IFileService), typeof(FileService));

            services.AddTransient(typeof(IAttachmentsRepository), typeof(AttachmentsRepository));
            services.AddTransient(typeof(IAttachmentsService), typeof(AttachmentsService));

            services.AddTransient<IAttachmentExpirySettingsRepository, AttachmentExpirySettingsRepository>();
            services.AddTransient<IAttachmentExpirySettingsService, AttachmentExpirySettingsService>();

            services.AddTransient<IAttachmentSecuritySettingsRepository, AttachmentSecuritySettingsRepository>();
            services.AddTransient<IAttachmentSecuritySettingsService, AttachmentSecuritySettingsService>();

            services.AddTransient<IAttachmentNotificationSettingsRepository, AttachmentNotificationSettingsRepository>();
            services.AddTransient<IAttachmentNotificationSettingsService, AttachmentNotificationSettingsService>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<IDownloadRepository, DownloadRepository>();

            services.AddTransient<IDashboardRepository, DashboardRepository>();
            services.AddTransient<IDashboardService, DashboardService>();

            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<ILogService, LogService>();

            services.AddTransient<IPackageRepository, PackageRepository>();
            services.AddTransient<IPackageService, PackageService>();

            services.AddTransient<IUserPackageRepository, UserPackageRepository>();

            services.AddTransient<INewsLettersRepository, NewsLettersRepository>();
            services.AddTransient<INewsLettersService, NewsLettersService>();

            services.AddTransient<INotificationDetailsRepository, NotificationDetailsRepositoy>();

            services.AddTransient<IGuestLinkRepository, GuestLinkRepository>();
            services.AddTransient<IGuestLinkService, GuestLinkService>();

            services.AddTransient<IGuestLinkExpirySettingsRepository, GuestLinkExpirySettingRepository>();
            services.AddTransient<IGuestLinkSecuritySettingsRepository, GuestLinkSecuritySettingsRepository>();

            return services;
        }

        /// <summary>
        /// Adds the database configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddDBConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NextGenContext>(options => options.UseSqlServer(configuration.GetConnectionString("NextGenEnities")));
            services.AddSingleton<IConfiguration>(_ => configuration);
            return services;
        }

    }
}
