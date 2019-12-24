using AttachMore.NextGen.Core.DomainModels.Login;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;

namespace AttachMore.NextGen.Infrastructure.Repositories.Account
{
    /// <summary>
    /// LoginRepository Class
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Core.DomainModels.Login.UserWithToken}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Account.ILoginRepository" />
    public class LoginRepository : Repository<UserWithToken, NextGenContext>, ILoginRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="tokenBuilder">The token builder.</param>
        public LoginRepository(NextGenContext context)
            : base(context)
        {

        }


    }
}
