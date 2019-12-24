using AttachMore.NextGen.Core.IRepositories;
using AttachMore.NextGen.Core.IRepositories.Package;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Repositories.Package
{
    /// <summary>
    /// User Package repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Packages.Package, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Package.IPackageRepository" />
    public class PackageRepository : Repository<DataAccess.EntityModel.Packages.Package, NextGenContext>, IPackageRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public PackageRepository(NextGenContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Gets all package.
        /// </summary>
        /// <param name="UserEmail">The user email.</param>
        /// <returns></returns>
        public List<DataAccess.EntityModel.Packages.Package> GetAllPackage(string UserEmail)
        {
            var UserPackage = base.GetAll().ToList();
            return UserPackage;
        }
    }
}
