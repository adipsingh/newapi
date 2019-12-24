using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Dashboard
{
    /// <summary>
    /// DataUserage calculation class
    /// </summary>
    public class DataUsageModel
    {
        /// <summary>
        /// Gets or sets the usage.
        /// </summary>
        /// <value>
        /// The usage.
        /// </value>
        public decimal Usage { get; set; }

        /// <summary>
        /// Converts to taldata.
        /// </summary>
        /// <value>
        /// The total data.
        /// </value>
        public int TotalData { get; set; }

        /// <summary>
        /// Gets or sets the remaining.
        /// </summary>
        /// <value>
        /// The remaining.
        /// </value>
        public decimal Remaining { get; set; }
    }
}
