using AttachMore.NextGen.Core.DomainModels.Login;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IRepositories.Account
{
    /// <summary>
    /// Register Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.IRepository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account.User}" />
    public interface IRegisterRepository : IRepository<User>
    {
    }
}
