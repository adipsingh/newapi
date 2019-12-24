using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Service.API.Controllers.Common
{
    /// <summary>
    /// UploadController class
    /// </summary>
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        /// <summary>Initializes a new instance of the <see cref="UploadController"/> class.</summary>
        public UploadController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Value", "harjap" };
        }

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="Request">The request.</param>
        [HttpPost]
        public void Post([FromForm] object Request)
        {
            if (HttpContext.Request.Form.Files.Count() > 0)
            {
                for (int i = 0; i < HttpContext.Request.Form.Files.Count(); i++)
                {
                    byte[] bytes;
                    using (var ms = new MemoryStream())
                    {
                        HttpContext.Request.Form.Files[i].CopyToAsync(ms);
                        bytes = ms.ToArray();
                    }
                }
            }
        }
    }
}
