using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using AttachMore.NextGen.ServiceModel.Request.Account;
using AttachMore.NextGen.ServiceModel.Response.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttachMore.NextGen.Infrastructure.DataAccess.Extentions;
using AttachMore.NextGen.Core.DomainModels.Login;

namespace AttachMore.NextGen.ServiceFactory.Account
{
    public class RegisterFactory : FactoryBase<UserWithToken, RegisterRequest, RegisterResponse>
    {
        public override UserWithToken MapRequest(params object[] parameters)
        {
            var Product = new UserWithToken()
            {
                FirstName = this.RequestObject.FirstName,
                LastName = this.RequestObject.LastName,
                Password = this.RequestObject.Password.Encrypt(),
                Email = this.RequestObject.Email,
                PhoneNumber = this.RequestObject.PhoneNumber
            };
            return Product;
        }
    }
}
