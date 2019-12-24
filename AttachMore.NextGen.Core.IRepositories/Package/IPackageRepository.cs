using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IRepositories.Package
{
    /// <summary>
    /// User Package Inerface
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.IRepository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Packages.Package}" />
    public interface IPackageRepository : IRepository<Infrastructure.DataAccess.EntityModel.Packages.Package>
    {
        /// <summary>
        /// Gets all package.
        /// </summary>
        /// <param name="UserEmail">The user email.</param>
        /// <returns></returns>
        List<Infrastructure.DataAccess.EntityModel.Packages.Package> GetAllPackage(string UserEmail);
    }
}
