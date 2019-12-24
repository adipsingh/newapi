using AttachMore.NextGen.Core.DomainModels.Login;
using AttachMore.NextGen.Core.Framework.Attributes;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using AttachMore.NextGen.ServiceFactory.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Service.API.Controllers.Account
{
    /// <summary>
    /// AccountAssociationController
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Service.API.Controllers.APIBaseController{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account.User}" />
    public class AccountAssociationController<TEntity> : APIBaseController<TEntity> where TEntity : class
    {

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="Request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public override IActionResult Post([FromBody] object Request)
        {
            this.RequestObject = Request;
            var entity = this.Factory.CreateRequest();
            if (ModelState.IsValid)
            {
                var result = this.Service.Add(entity);
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }
    }
}
