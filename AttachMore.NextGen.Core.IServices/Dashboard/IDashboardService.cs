using AttachMore.NextGen.Core.DomainModels.Dashboard;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.Dashboard
{
    /// <summary>
    /// Dashboard Service Interface.
    /// </summary>
    public interface IDashboardService
    {
        /// <summary>
        /// Gets the dashboad association.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        DashboardStats DashboadStats(string Email);

        /// <summary>
        /// Attachments the history.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        List<AttachmentHistoryModel> AttachmentHistory(string email);

        /// <summary>
        /// Attachments the files.
        /// </summary>
        /// <param name="attachmentid">The attachmentid.</param>
        /// <returns></returns>
        AttachmentDetailModel AttachmentFilesDetail(int attachmentid, string Email);

        /// <summary>
        /// Dashboards the user information.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        DashboardUserDetailsModel DashboardUserInfo(string Email);

        /// <summary>
        /// Dashboards the data usage.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        DataUsageModel DashboardDataUsage(string Email);
    }
}
