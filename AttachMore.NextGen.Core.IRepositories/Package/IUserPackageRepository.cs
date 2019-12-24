using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IRepositories.Package
{
    /// <summary>
    /// Iuser Package Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.IRepository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Packages.UserPackages}" />
    public interface IUserPackageRepository : IRepository<UserPackages>
    {
    }
}
