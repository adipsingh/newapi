using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Dashboard
{
    /// <summary>
    /// proc resutl POCO Class
    /// </summary>
    public class DashboardStats
    {
        /// <summary>
        /// Gets or sets the uploads.
        /// </summary>
        /// <value>
        /// The uploads.
        /// </value>
        public int UPLOADS { get; set; }

        /// <summary>
        /// Gets or sets the downloads.
        /// </summary>
        /// <value>
        /// The downloads.
        /// </value>
        public int DOWNLOADS { get; set; }

        /// <summary>
        /// Gets or sets the filesreceived.
        /// </summary>
        /// <value>
        /// The filesreceived.
        /// </value>
        public int FILESRECEIVED { get; set; }

        /// <summary>
        /// Gets or sets the expiringlinks.
        /// </summary>
        /// <value>
        /// The expiringlinks.
        /// </value>
        public int EXPIRINGLINKS { get; set; }

        /// <summary>
        /// Gets or sets the filespurging.
        /// </summary>
        /// <value>
        /// The filespurging.
        /// </value>
        public int FILESPURGING { get; set; }

        /// <summary>
        /// Gets or sets the purchasedfiles.
        /// </summary>
        /// <value>
        /// The purchasedfiles.
        /// </value>
        public int PURCHASEDFILES { get; set; }
    }
}
