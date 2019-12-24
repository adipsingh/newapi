using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Core.DomainModels.Login;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.Account
{
    /// <summary>
    /// IRegisterService
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.IBaseService{AttachMore.NextGen.Core.DomainModels.Login.UserWithToken}" />
    public interface IRegisterService
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        UserWithTokenModel Add(RegisterModel entity);

        /// <summary>
        /// Gets a uthenticate.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        UserWithTokenModel GetAUthenticate(string Email, string password);


    }
}
