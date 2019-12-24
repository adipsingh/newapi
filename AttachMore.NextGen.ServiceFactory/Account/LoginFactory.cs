using AttachMore.NextGen.Core.DomainModels.Login;
using AttachMore.NextGen.ServiceModel.Request.Account;
using AttachMore.NextGen.ServiceModel.Response.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.ServiceFactory.Account
{
    /// <summary>
    /// Login Factory
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.ServiceFactory.FactoryBase{AttachMore.NextGen.Core.DomainModels.Login.UserWithToken, AttachMore.NextGen.ServiceModel.Request.Account.LoginRequest, AttachMore.NextGen.ServiceModel.Response.Account.LoginResponse}" />
    public class LoginFactory : FactoryBase<UserWithToken, LoginRequest, LoginResponse>
    {
        /// <summary>
        /// Maps the request.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public override UserWithToken MapRequest(params object[] parameters)
        {
            var UserWithToken = new UserWithToken
            {
                Email = this.RequestObject.Email,
                Password = this.RequestObject.Password
            };
            return UserWithToken;
        }
    }
}
