using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VDIConnect_API.DAL;
using VDIConnect_API.Models;

namespace VDIConnect_API.Controllers
{
    public class CommentaryController : ApiController
    {
        [HttpGet]
        [Route("api/commentary/GetCommentaries/", Name = "GetCommentaries")]
        public IHttpActionResult GetCommentaries()
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    List<Commentary> commentaries = db.Commentary.ToList();
                    return Ok(commentaries);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode GetCommentaries:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }
    }
}
