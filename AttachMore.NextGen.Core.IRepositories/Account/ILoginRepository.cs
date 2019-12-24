using AttachMore.NextGen.Core.DomainModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IRepositories.Account
{
    /// <summary>
    /// Interface Login Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.IRepository{AttachMore.NextGen.Core.DomainModels.Login.UserWithToken}" />
    public interface ILoginRepository : IRepository<UserWithToken>
    {
    }
}
