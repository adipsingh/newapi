using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Service.API.Controllers
{
    /// <summary>
    /// Api Base Controller
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="AttachMore.NextGen.Service.API.Controllers.BaseController{TEntity}" />
    public abstract class APIBaseController<TEntity> : BaseController<TEntity> where TEntity : class
    {

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public virtual IActionResult Post([FromBody] object request)
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

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get([FromBody] object request)
        {
            return new ObjectResult("");
        }
    }
}
