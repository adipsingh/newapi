using AttachMore.NextGen.Core.DomainModels.Dashboard;
using AttachMore.NextGen.Core.IRepositories.Dashboard;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Repositories.Dashboard
{
    /// <summary>
    /// Dashboard Repository Class
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.Attachments, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Dashboard.IDashboardRepository" />
    public class DashboardRepository : Repository<Attachments, NextGenContext>, IDashboardRepository
    {
        NextGenContext m_Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DashboardRepository(NextGenContext context)
            : base(context)
        {
            this.m_Context = context;
        }

        /// <summary>
        /// Dashboards the association data.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IQueryable<DashboardStats> DashboardAssociationData(string spName, SqlParameter[] parameters)
        {
            IQueryable<DashboardStats> query = m_Context.Set<DashboardStats>().FromSql(spName);
            return query;
        }

        /// <summary>
        /// Dashboards the stats.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public DashboardStats DashboardStats(string Email)
        {
            DashboardStats model = new DashboardStats();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[DASHBOARD].[PROC_DASHBOARD_ATTACHMENT_ASSOCIATION]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LOGGEDINUSEREMAIL", Email);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    model.DOWNLOADS = (int)rdr["DOWNLOADS"];
                    model.EXPIRINGLINKS = (int)rdr["EXPIRINGLINKS"];
                    model.FILESPURGING = (int)rdr["FILESPURGING"];
                    model.FILESRECEIVED = (int)rdr["FILESRECEIVED"];
                    model.PURCHASEDFILES = (int)rdr["PURCHASEDFILES"];
                    model.UPLOADS = (int)rdr["UPLOADS"];
                }
                con.Close();
                return model;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public DashboardUserDetailsModel DashboardUserDetail(string Email)
        {
            DashboardUserDetailsModel model = new DashboardUserDetailsModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Dashboard.Proc_UserProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserEmail", Email);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    model.Name = rdr["Name"].ToString();
                    model.Status = (int)rdr["Status"] == null ? 0 : (int)rdr["Status"];
                    model.NextBillingDate = (DateTime)rdr["NextBillingDate"];
                    model.Expires = (DateTime)rdr["Expires"];
                    //model.PURCHASEDFILES = (int)rdr["PURCHASEDFILES"];
                    //model.UPLOADS = (int)rdr["UPLOADS"];
                }
                con.Close();
                return model;
            }
        }

        /// <summary>
        /// Dashboards the history.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public List<AttachmentHistoryModel> DashboardHistory(string Email)
        {
            List<AttachmentHistoryModel> listHistory = new List<AttachmentHistoryModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DASHBOARD.PROC_ATTACHMENT_HISTORY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LOGGEDINUSEREMAIL", Email);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AttachmentHistoryModel history = new AttachmentHistoryModel();
                    history.AttachmentId = Convert.ToInt64(rdr["ATTACHMENTID"].ToString());
                    history.AttachmentName = rdr["NAME"].ToString();
                    history.AttachmentSize = Convert.ToDecimal(rdr["SIZE"].ToString());
                    history.AttachmentType = rdr["FILETYPE"].ToString();
                    history.AttachmentExpiriedOn = Convert.ToDateTime(rdr["EXPIRIEDON"].ToString());
                    history.AttachmentCreationDate = Convert.ToDateTime(rdr["CREATIONDATE"].ToString());
                    history.AttachmentPurgedDate = Convert.ToDateTime(rdr["PURGEDON"].ToString());
                    history.TotalDownload = Convert.ToInt32(rdr["TOTALDOWNLOADS"].ToString());
                    history.Status = Convert.ToInt32(rdr["STATUS"].ToString());
                    listHistory.Add(history);
                }
                con.Close();
                return listHistory;
            }
        }

        /// <summary>
        /// Dashboards the data usage.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public DataUsageModel DashboardDataUsage(string Email)
        {
            DataUsageModel usage = new DataUsageModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DASHBOARD.PROC_DATA_USAGE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LOGGEDINUSEREMAIL", Email);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    usage.Usage = Convert.ToDecimal(rdr["Usage"].ToString());
                    usage.Remaining = Convert.ToDecimal(rdr["Remaining"].ToString());
                }
                con.Close();
                return usage;
            }
        }

        /// <summary>
        /// Dashboards the file status.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public AttachmentDetailModel DashboardFileStatus(int attachmentId, string Email)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DASHBOARD.PROC_FILE_DETAILS", con);
                AttachmentDetailModel FileDetails = new AttachmentDetailModel();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ATTACHMENTID", attachmentId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    FileDetails.DownloadURL = (string.IsNullOrEmpty(rdr["DOWNLOADURL"].ToString()) ? null : rdr["DOWNLOADURL"].ToString());
                    FileDetails.Name = string.IsNullOrEmpty(rdr["NAME"].ToString()) ? null : rdr["NAME"].ToString();
                    FileDetails.Status = string.IsNullOrEmpty(rdr["STATUS"].ToString()) ? 0 : Convert.ToInt32(rdr["STATUS"].ToString());
                    FileDetails.AttachmentSize = string.IsNullOrEmpty(rdr["TOTALSIZE"].ToString()) ? 0 : Convert.ToDecimal(rdr["TOTALSIZE"].ToString());
                    FileDetails.CreatedOn = Convert.ToDateTime(rdr["CREATIONDATE"].ToString());
                    FileDetails.PurgedOn = string.IsNullOrEmpty(rdr["PURGEDON"].ToString()) ? (DateTime?)null : Convert.ToDateTime(rdr["PURGEDON"].ToString());
                    FileDetails.TotalDownload = string.IsNullOrEmpty(rdr["TOTALDOWNLOAD"].ToString()) ? 0 : Convert.ToInt32(rdr["TOTALDOWNLOAD"].ToString());

                    FileDetails.ExpiredOn = string.IsNullOrEmpty(rdr["EXPIRYDATE"].ToString()) ? (DateTime?)null : Convert.ToDateTime(rdr["EXPIRYDATE"].ToString());
                    FileDetails.DownloadLimit = string.IsNullOrEmpty(rdr["DOWNLOADSLIMIT"].ToString()) ? 0 : Convert.ToInt32(rdr["DOWNLOADSLIMIT"].ToString());
                    FileDetails.DeleteAfter = string.IsNullOrEmpty(rdr["DELETEAFTER"].ToString()) ? (DateTime?)null : Convert.ToDateTime(rdr["DELETEAFTER"].ToString());

                    FileDetails.WhenDownload = string.IsNullOrEmpty(rdr["WHENDOWNLOAD"].ToString()) ? false : Convert.ToBoolean(rdr["WHENDOWNLOAD"].ToString());
                    FileDetails.WhenExpired = string.IsNullOrEmpty(rdr["WHENEXPIRED"].ToString()) ? false : Convert.ToBoolean(rdr["WHENEXPIRED"].ToString());
                    FileDetails.ByEmail = string.IsNullOrEmpty(rdr["BYEMAIL"].ToString()) ? false : Convert.ToBoolean(rdr["BYEMAIL"].ToString());
                    FileDetails.ByText = string.IsNullOrEmpty(rdr["BYTEXT"].ToString()) ? false : Convert.ToBoolean(rdr["BYTEXT"].ToString());

                    FileDetails.AccessPassword = string.IsNullOrEmpty(rdr["ACCESSPASSWORD"].ToString()) ? null : (rdr["ACCESSPASSWORD"].ToString());
                    FileDetails.AccessEmail = string.IsNullOrEmpty(rdr["ACCESSEMAIL"].ToString()) ? null : (rdr["ACCESSEMAIL"].ToString());
                    FileDetails.AccessName = string.IsNullOrEmpty(rdr["ACCESSNAME"].ToString()) ? null : (rdr["ACCESSNAME"].ToString());
                    FileDetails.AccessCompany = string.IsNullOrEmpty(rdr["ACCESSCOMPANY"].ToString()) ? null : (rdr["ACCESSCOMPANY"].ToString());
                    FileDetails.AccessContectNumber = string.IsNullOrEmpty(rdr["ACCESSCONTACTNUMBER"].ToString()) ? null : (rdr["ACCESSCONTACTNUMBER"].ToString());
                    FileDetails.AccessPayment = string.IsNullOrEmpty(rdr["ACCESSPAYMENT"].ToString()) ? 0 : (Convert.ToDecimal(rdr["ACCESSPAYMENT"].ToString()));
                }
                con.Close();
                return FileDetails;
            }
        }


        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        private string ConnectionString
        {
            get
            {
                return "Data Source = sql5004.site4now.net; Initial Catalog = DB_A451F9_attachmore; User ID = DB_A451F9_attachmore_admin; Password = Auth@Gou89";
            }
        }

    }
}
