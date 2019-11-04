using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VDIConnect_API.DAL;
using VDIConnect_API.Models;

namespace VDIConnect_API.Controllers
{
    public class EnterpriseController : ApiController
    {
        /// <summary>
        /// Methode qui recherche l'ensemble des entreprises de l'application
        /// </summary>
        /// <returns>La liste des entreprises de l'application </returns>
        [HttpGet]
        [Route("api/enterprise/GetEnterprises")]
        public IHttpActionResult GetEnterprises()
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    List<Enterprise> enterprises = db.Enterprise.Where(x => x.Delete == false).ToList();
                    if (enterprises == null)
                        return NotFound();

                    return Ok(enterprises);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode GetEnterprises:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                }
            }
        }

        /// <summary>
        /// Methode qui recherche l'entreprise possédant l'Id passé en parametre
        /// </summary>
        /// <param name="idEnterprise"></param>
        /// <returns> L'entreprise possédant l'Id </returns>
        [HttpGet]
        [Route("api/enterprise/GetEnterprise/{idEnterprise}", Name = "GetEnterprise")]
        public IHttpActionResult GetEnterprise(int idEnterprise)
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    Enterprise enterprise = db.Enterprise.Find(idEnterprise);
                    if (enterprise == null)
                        return NotFound();

                    return Ok(enterprise);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode GetEnterprise:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                }
            }
        }

        /// <summary>
        /// Méthode de création d'une entreprise
        /// </summary>
        /// <param name="enterprise"></param>
        /// <returns> l'entreprise créee </returns>
        [HttpPost]
        [Route("api/enterprise/PostEnterprise")]
        public IHttpActionResult PostEnterprise([FromBody]Enterprise enterprise)
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    enterprise.Name = enterprise.Name.ToUpper();
                    db.Enterprise.Add(enterprise);
                    db.SaveChanges();
                    return Ok(enterprise);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode GetEnterprise:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                }
            }
        }

        /// <summary>
        /// Méthode de modification d'une entreprise possédant l'Id passé en parametre
        /// </summary>
        /// <param name="idEnterprise"></param>
        /// <param name="enterprise"></param>
        /// <returns> L'entreprise modifiée </returns>
        [HttpPut]
        [Route("api/enterprise/PutEnterprise/{idEnterprise}", Name = "PutEnterprise")]
        public IHttpActionResult PutEnterprise(int idEnterprise, [FromBody] Enterprise enterprise)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    Enterprise enterpriseModify = db.Enterprise.Find(idEnterprise);
                    if (enterpriseModify == null)
                        return NotFound();

                    enterpriseModify.Name = enterprise.Name;

                    db.Entry(enterpriseModify).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok(enterpriseModify);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode PutEnterprise:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }

        /// <summary>
        /// Méthode d'archivage d'une entreprise possédant l'Id passé en parametre
        /// </summary>
        /// <param name="idEnterprise"></param>
        /// <returns> L'entreprise archivé </returns>
        [HttpPut]
        [Route("api/enterprise/ArchiveEnterprise/{idEnterprise}", Name = "ArchiveEnterprise")]
        public IHttpActionResult ArchiveEnterprise(int idEnterprise)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    Enterprise enterpriseArchived = db.Enterprise.Find(idEnterprise);
                    if (enterpriseArchived == null)
                        return NotFound();

                    enterpriseArchived.Delete = true;

                    db.Entry(enterpriseArchived).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok(enterpriseArchived);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode PutEnterprise:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }

    }
}
