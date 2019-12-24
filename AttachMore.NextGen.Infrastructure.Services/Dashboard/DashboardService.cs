using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Core.DomainModels.Dashboard;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Core.IRepositories.Attachment;
using AttachMore.NextGen.Core.IRepositories.Dashboard;
using AttachMore.NextGen.Core.IServices.Account;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Core.IServices.Dashboard;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Dashboard
{
    /// <summary>
    /// Dashboard Service Class 
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Dashboard.IDashboardService" />
    public class DashboardService : IDashboardService
    {
        /// <summary>
        /// The m dashboard repository
        /// </summary>
        private readonly IDashboardRepository m_DashboardRepository;

        /// <summary>
        /// The m account service
        /// </summary>
        private readonly IAccountService m_AccountService;

        /// <summary>
        /// The m download service
        /// </summary>
        private readonly IDownloadRepository m_DownloadRepository;

        /// <summary>
        /// The m file service
        /// </summary>
        private readonly IFileService m_FileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardService"/> class.
        /// </summary>
        /// <param name="DashboardRepository">The dashboard repository.</param>
        public DashboardService(IDashboardRepository DashboardRepository, IAccountService accountService, IFileService FileService, IDownloadRepository DownloadRepository)
        {
            this.m_DashboardRepository = DashboardRepository;
            this.m_AccountService = accountService;
            this.m_FileService = FileService;
            this.m_DownloadRepository = DownloadRepository;
        }

        /// <summary>
        /// Gets the dashboad association.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DashboardStats DashboadStats(string Email)
        {
            try
            {
                var param = new SqlParameter[] { new SqlParameter("@LOGGEDINUSEREMAIL", Email) };
                var Stats = m_DashboardRepository.DashboardStats(Email);
                return Stats;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Attachments the history.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<AttachmentHistoryModel> AttachmentHistory(string email)
        {
            try
            {
                var result = this.m_DashboardRepository.DashboardHistory(email);
                return result;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Dashboards the data usage.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DataUsageModel DashboardDataUsage(string Email)
        {
            try
            {
                var result = this.m_DashboardRepository.DashboardDataUsage(Email);
                result.TotalData = 1;
                return result;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Attachments the files.
        /// </summary>
        /// <param name="attachmentid">The attachmentid.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public AttachmentDetailModel AttachmentFilesDetail(int attachmentid, string Email)
        {
            try
            {
                var LoggedInUserDetail = LoggedInUserId(Email);
                //AttachmentDetailModel model = new AttachmentDetailModel();
                var resultFiles = this.m_FileService.GetFiles(attachmentid).ToList();
                var attachmentResult = this.m_DashboardRepository.DashboardFileStatus(attachmentid, Email);
                //var attachmentResult = this.m_DashboardRepository.GetAll().Where(a => a.AttachmentId == attachmentid).FirstOrDefault();
                //var TotalDownload = this.m_DownloadRepository.GetAll().Where(a => a.AttachmentId == attachmentid).ToList();
                if (attachmentResult != null && resultFiles != null)
                {
                    attachmentResult.DownloadURL = attachmentResult.DownloadURL + "/" + attachmentid;
                    attachmentResult.AttachmentId = attachmentid;
                    attachmentResult.FilesDetail = resultFiles;
                    attachmentResult.TotalFileInAttachment = resultFiles.Count();
                    attachmentResult.UploadedBy = LoggedInUserDetail.FirstName + " " + LoggedInUserDetail.LastName;
                    attachmentResult.Payments = 0;
                }
                return attachmentResult;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Dashboards the user information.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DashboardUserDetailsModel DashboardUserInfo(string Email)
        {
            try
            {
                DashboardUserDetailsModel model = new DashboardUserDetailsModel();
                model = this.m_DashboardRepository.DashboardUserDetail(Email);
                model.UserRole = "Admin";
                return model;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Users the information.
        /// </summary>
        /// <param name="email">The email.</param>
        private UserModel LoggedInUserId(string email)
        {
            var userInfo = this.m_AccountService.GetUserInfo(email);
            return userInfo;
        }
    }
}
