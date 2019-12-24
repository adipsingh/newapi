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
    /// User Package Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Packages.UserPackages, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Package.IUserPackageRepository" />
    public class UserPackageRepository : Repository<UserPackages, NextGenContext>, IUserPackageRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPackageRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserPackageRepository(NextGenContext context)
            : base(context)
        {
        }
    }
}
