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
    public class SessionController : ApiController
    {
        /// <summary>
        /// Methode qui recherche l'ensemble des sessions de l'application
        /// </summary>
        /// <returns> La liste des sessions </returns>
        [HttpGet]
        [Route("api/session/GetSessions", Name = "GetSessions")]
        public IHttpActionResult GetSessions()
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    List<Session> sessions = db.Session.Where(x => x.Delete == false).Include(x => x.TypeInterest).ToList();
                    return Ok(sessions);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode GetSessions:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }

        /// <summary>
        /// Methode qui recherche la session possédant l'Id passé en parametre
        /// </summary>
        /// <param name="idSession"></param>
        /// <returns> La session possédant l'Id </returns>
        [HttpGet]
        [Route("api/session/GetSession/{idSession}", Name = "GetSession")]
        public IHttpActionResult GetSession(int idSession)
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    Session session = db.Session.Where(x => x.Id == idSession).Include(x => x.TypeInterest).FirstOrDefault();
                    if (session == null)
                    {
                        return NotFound();
                    }
                    return Ok(session);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode GetPerson:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                }
            }
        }

        /// <summary>
        /// Méthode qui créee un nouvelle utilisateur
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/session/PostSession/", Name = "PostSession")]
        public IHttpActionResult PostSession([FromBody]Session session)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    session.DateStart = DateTime.Now;
                    session.DateEnd = DateTime.Now;
                    session.Delete = false;

                    db.Session.Add(session);
                    db.SaveChanges();
                    return Ok(session);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode PostSession: Message : {0};  InnerException : {1}; Stacktrace : {2}", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }

        /// <summary>
        /// Modifie les informations de la session possédant l'Id passée en parametre
        /// </summary>
        /// <param name="idSession"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/session/PutSession/{idSession}", Name = "PutSession")]
        public IHttpActionResult PutSession(int idSession, [FromBody] Session session)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    Session sessionModify = db.Session.Find(idSession);
                    if (sessionModify == null)
                        return NotFound();

                    sessionModify.Title = session.Title;
                    sessionModify.DateStart = session.DateStart;
                    sessionModify.DateEnd = session.DateEnd;
                    sessionModify.NbSeat = session.NbSeat;
                    sessionModify.Address = session.Address;
                    sessionModify.PostCode = session.PostCode;
                    sessionModify.City = session.City;
                    sessionModify.IdTypeInterest = session.IdTypeInterest;
                    sessionModify.IdHote = session.IdHote;
                    sessionModify.IdVDI = session.IdVDI;

                    db.Entry(sessionModify).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok(sessionModify);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode PutPerson:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }


        /// <summary>
        /// Méthode de suppression d'une session
        /// </summary>
        /// <param name="idSession"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/session/DeleteSession/{idSession}", Name = "DeleteSession")]
        public IHttpActionResult DeleteSession(int idSession)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    Session deletedSession = db.Session.Find(idSession);
                    if (deletedSession == null)
                        return NotFound();


                    deletedSession.Delete = true;
                    db.Entry(deletedSession).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok(deletedSession);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode DeleteSession:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }
    }
}
