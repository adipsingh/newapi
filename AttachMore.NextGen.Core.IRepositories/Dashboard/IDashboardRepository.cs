using AttachMore.NextGen.Core.DomainModels.Dashboard;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IRepositories.Dashboard
{
    /// <summary>
    /// Dashboard repositoty Inerface
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.IRepository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.Attachments}" />
    public interface IDashboardRepository : IRepository<Attachments>
    {
        /// <summary>
        /// Dashboards the association data.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IQueryable<DashboardStats> DashboardAssociationData(string spName, SqlParameter[] parameters);

        /// <summary>
        /// Dashboards the stats.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        DashboardStats DashboardStats(string Email);

        /// <summary>
        /// Dashboards the history.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        List<AttachmentHistoryModel> DashboardHistory(string Email);

        /// <summary>
        /// Dashboards the user detail.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        DashboardUserDetailsModel DashboardUserDetail(string Email);

        /// <summary>
        /// Dashboards the data usage.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        DataUsageModel DashboardDataUsage(string Email);

        /// <summary>
        /// Dashboards the file status.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        AttachmentDetailModel DashboardFileStatus(int attachmentId, string Email);
    }
}
