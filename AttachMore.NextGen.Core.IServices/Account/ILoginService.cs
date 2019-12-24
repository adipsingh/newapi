using AttachMore.NextGen.Core.DomainModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.Account
{

    /// <summary>
    /// Login Service Interface
    /// </summary>
    public interface ILoginService : IBaseService<LoginModel>
    {
        /// <summary>
        /// Gets a uthenticate.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        UserWithTokenModel GetAUthenticate(LoginModel model);
    }
}
