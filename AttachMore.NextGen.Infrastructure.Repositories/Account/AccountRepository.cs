using AttachMore.NextGen.Core.IRepositories;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Repositories.Account
{
    /// <summary>
    /// AccountRepository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account.User, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="IAccountRepository" />
    public class AccountRepository : Repository<User, NextGenContext>, IAccountRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AccountRepository(NextGenContext context)
            : base(context)
        {
        }
    }
}
