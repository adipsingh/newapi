using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Service.API.Controllers.Attachment
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IFileService m_FileService;

        public FileController(IFileService fileService)
        {
            this.m_FileService = fileService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Value", "Harjap" };
        }


        /// <summary>
        /// Gets the files information form s3. 
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("ShowAttachments")]
        public IActionResult ShowAttachments(int Id)
        {
            try
            {
                var result = this.m_FileService.GetFiles(Id);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        //[HttpPost("GetAttachments")]
        //public IActionResult Get(int Id)
        //{   
        //    byte[] b = this.m_FileService.Download(Id);
        //    const string contentType = "application/zip";
        //    HttpContext.Response.ContentType = contentType;
        //    var result = new FileContentResult(b, contentType)
        //    {
        //        FileDownloadName = "Attachment.zip"
        //    };
        //    return result;
        //}

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="Request">The request.</param>
        [HttpPost]
        public IActionResult Post([FromForm] formdata Request)
        {
            var request = HttpContext.Request;
            int attachmentid = Request.attachmentId;
            int totalcount = Request.totalCount;

            string response = string.Empty;
            Files entity = new Files();
            try
            {
                if (request.Form.Files.Count() > 0)
                {
                    using (var msbytes = new MemoryStream())
                    {
                        var fileDetails = request.Form.Files[0];
                        request.Form.Files[0].CopyTo(msbytes);
                        response = this.m_FileService.Upload(msbytes, fileDetails.FileName, attachmentid, fileDetails);
                        return Ok(response);
                    }
                }
                else
                {
                    return NotFound("Not file found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public class formdata
        {
            public int attachmentId { get; set; }
            public int totalCount { get; set; }
            public int totalSize { get; set; }
        }
    }
}
