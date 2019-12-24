using AttachMore.NextGen.Core.DomainModels.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.Package
{
    /// <summary>
    /// User Package Service
    /// </summary>
    public interface IPackageService
    {
        /// <summary>
        /// Gets all package.
        /// </summary>
        /// <returns></returns>
        List<PackageModel> GetAllPackage();

        /// <summary>
        /// Adds the user package.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        bool AddUserPackage(UserPackagesModel model);
    }
}
