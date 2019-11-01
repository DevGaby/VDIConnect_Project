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
    public class TypeInterestController : ApiController
    {
        /// <summary>
        /// Méthode qui retourne tous les types d'intêret de l'application
        /// </summary>
        /// <returns> Liste de l'ensemble des types d'intêret de l'application </returns>
        [HttpGet]
        [Route("api/interest/GetTypesInterest", Name = "GetTypesInterest")]
        public IHttpActionResult GetTypesInterest()
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    List<TypeInterest> typesInterest = db.TypeInterest.ToList();
                    if (typesInterest == null)
                        return NotFound();

                    return Ok(typesInterest);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode GetTypesInterest:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                }
            }
        }

        /// <summary>
        /// Methode qui recherche le type d'intêret possédant l'Id passé en parametre
        /// </summary>
        /// <param name="idTypeInterest"></param>
        /// <returns> L'entreprise possédant l'Id </returns>
        [HttpGet]
        [Route("api/interest/GetTypeInterest/{idTypeInterest}", Name = "GetTypeInterest")]
        public IHttpActionResult GetTypeInterest(int idTypeInterest)
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    TypeInterest typeInterest = db.TypeInterest.Find(idTypeInterest);
                    if (typeInterest == null)
                        return NotFound();

                    return Ok(typeInterest);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode GetTypeInterest:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                }
            }
        }

        /// <summary>
        /// Méthode de création d'un type d'intêret
        /// </summary>
        /// <param name="typeinterest"></param>
        /// <returns> l'entreprise créee </returns>
        [HttpPost]
        [Route("api/interest/PostTypeInterest", Name = "PostTypeInterest")]
        public IHttpActionResult PostTypeInterest([FromBody]TypeInterest typeinterest)
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    typeinterest.Label = typeinterest.Label.ToUpper();
                    db.TypeInterest.Add(typeinterest);
                    db.SaveChanges();
                    return Ok(typeinterest);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode PostTypeInterest:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                }
            }
        }

        /// <summary>
        /// Méthode de modification d'un type intêret possédant l'Id passé en parametre
        /// </summary>
        /// <param name="idTypeInterest"></param>
        /// <param name="typeinterest"></param>
        /// <returns> Le type d'intêret modifié </returns>
        [HttpPut]
        [Route("api/interest/PutTypeInterest/{idTypeInterest}", Name = "PutTypeInterest")]
        public IHttpActionResult PutTypeInterest(int idTypeInterest, [FromBody] TypeInterest typeinterest)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    TypeInterest interestModify = db.TypeInterest.Find(idTypeInterest);
                    if (interestModify == null)
                        return NotFound();

                    interestModify.Label = typeinterest.Label.ToUpper(); ;

                    db.Entry(interestModify).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok(interestModify);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode PutTypeInterest:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }
    }
}
