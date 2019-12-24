using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Package
{
    /// <summary>
    /// UserPackage Model
    /// </summary>
    public class PackageModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the storage limit.
        /// </summary>
        /// <value>
        /// The storage limit.
        /// </value>
        public int StorageLimit { get; set; }

        /// <summary>
        /// Gets or sets the users limit.
        /// </summary>
        /// <value>
        /// The users limit.
        /// </value>
        public int UsersLimit { get; set; }

        /// <summary>
        /// Gets or sets the annual plan.
        /// </summary>
        /// <value>
        /// The annual plan.
        /// </value>
        public decimal AnnualPlan { get; set; }

        /// <summary>
        /// Gets or sets the monthly plan.
        /// </summary>
        /// <value>
        /// The monthly plan.
        /// </value>
        public decimal MonthlyPlan { get; set; }

        /// <summary>
        /// Gets or sets the saving with annual plan.
        /// </summary>
        /// <value>
        /// The saving with annual plan.
        /// </value>
        public decimal SavingWithAnnualPlan { get; set; }

        /// <summary>
        /// Gets or sets the downloads.
        /// </summary>
        /// <value>
        /// The downloads.
        /// </value>
        public string Downloads { get; set; }

        /// <summary>
        /// Gets or sets the link life.
        /// </summary>
        /// <value>
        /// The link life.
        /// </value>
        public string LinkLife { get; set; }

        /// <summary>
        /// Gets or sets the file life.
        /// </summary>
        /// <value>
        /// The file life.
        /// </value>
        public string FileLife { get; set; }

        /// <summary>
        /// Gets or sets the renew link.
        /// </summary>
        /// <value>
        /// The renew link.
        /// </value>
        public string RenewLink { get; set; }

        /// <summary>
        /// Gets or sets the software installation per user.
        /// </summary>
        /// <value>
        /// The software installation per user.
        /// </value>
        public int SoftwareInstallationPerUser { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
