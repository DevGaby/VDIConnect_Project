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
    public class VDIController : ApiController
    {
        /// <summary>
        /// Controleur de gestion des VDI
        /// </summary>
       
            /// <summary>
            ///  Methode qui recherche l'ensemble des VDI de l'application
            /// </summary>
            /// <returns> La liste des VDI de l'application </returns>
            [HttpGet]
            [Route("api/vdi/GetVDIs", Name = "GetVDIs")]
            public IHttpActionResult GetVDIs()
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    try
                    {
                        List<VDI> VDIs = db.VDI.Where(x => x.Archive == false).Include(x => x.Enterprise).Include(x => x.Person).ToList();
                        if (VDIs == null)
                            return NotFound();

                        return Ok(VDIs);
                    }
                    catch (Exception exp)
                    {
                        return BadRequest(string.Format("Erreur dans la méthode GetVDIs:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                    }
                }
            }

            /// <summary>
            /// Méthode qui recherche le VDI possédant l'Id passé en paramétre
            /// </summary>
            /// <param name="idVDI"></param>
            /// <returns> Le VDI possédant l'Id passé en paramétre </returns>
            [HttpGet]
            [Route("api/vdi/GetVDI/{idVDI}", Name = "GetVDI")]
            public IHttpActionResult GetVDI(int idVDI)
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    try
                    {
                        VDI vdi = db.VDI.Where(x => x.Id == idVDI).Include(x => x.Enterprise).Include(x => x.Person).FirstOrDefault();
                        return Ok(vdi);
                    }
                    catch (Exception exp)
                    {
                        return BadRequest(string.Format("Erreur dans la méthode GetVDI:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                    }
                }

            }

            /// <summary>
            /// Methode qui recherche l'ensemble des VDI d'une entrepsie possédant l'Id passé en parametre
            /// </summary>
            /// <param name="idEnterprise"></param>
            /// <returns> La liste des VDI de l'entreprise </returns>
            [HttpGet]
            [Route("api/vdi/GetVDIsByEnterprise/{idEnterprise}", Name = "GetVDIsByEnterprise")]
            public IHttpActionResult GetVDIsByEnterprise(int idEnterprise)
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    try
                    {
                        List<VDI> VDIs = db.VDI.Where(x => x.IdEnterprise == idEnterprise && x.Archive == false).Include(x => x.Enterprise).Include(x => x.Person).ToList();
                        if (VDIs == null)
                            return NotFound();

                        return Ok(VDIs);
                    }
                    catch (Exception exp)
                    {
                        return BadRequest(string.Format("Erreur dans la méthode GetVDIsByEnterprise:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                    }
                }
            }

            /// <summary>
            /// Méthode qui crée un VDI
            /// </summary>
            /// <param name="vdi"></param>
            /// <returns> Le VDI crée </returns>
            [HttpPost]
            [Route("api/vdi/PostVDI", Name = "PostVDI")]
            public IHttpActionResult PostVDI([FromBody]VDI vdi)
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    try
                    {
                        db.VDI.Add(vdi);
                        db.SaveChanges();
                        return Ok(vdi);
                    }
                    catch (Exception exp)
                    {
                        return BadRequest(string.Format("Erreur dans la méthode PostVDI:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                    }
                }
            }

            /// <summary>
            /// Méthode de modification d'un VDI
            /// </summary>
            /// <param name="idVDI"></param>
            /// <param name="vdi"></param>
            /// <returns> Le VDI Modifié</returns>
            [HttpPut]
            [Route("api/vdi/PutVDI/{idVDI}", Name = "PutVDI")]
            public IHttpActionResult PutVDI(int idVDI, [FromBody]VDI vdi)
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    try
                    {
                        VDI vdiModify = db.VDI.Find(idVDI);
                        if (vdiModify == null)
                            return NotFound();

                        vdiModify.IdEnterprise = vdi.IdEnterprise;
                        vdiModify.IdPerson = vdi.IdPerson;
                        db.Entry(vdiModify).State = EntityState.Modified;
                        db.SaveChanges();
                        return Ok(vdiModify);
                    }
                    catch (Exception exp)
                    {
                        return BadRequest(string.Format("Erreur dans la méthode PutVDI:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                    }
                }
            }

            /// <summary>
            /// Méthode d'archivage d'un VDI
            /// </summary>
            /// <param name="idVDI"></param>
            /// <returns> > Le VDI archivé </returns>
            [HttpPut]
            [Route("api/vdi/ArchivedVDI/{idVDI}", Name = "ArchivedVDI")]
            public IHttpActionResult ArchivedVDI(int idVDI)
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    try
                    {
                        VDI archivedVDI = db.VDI.Find(idVDI);
                        archivedVDI.Archive = false;

                        return Ok(archivedVDI);
                    }
                    catch (Exception exp)
                    {
                        return BadRequest(string.Format("Erreur dans la méthode ArchivedVDI:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                    }
                }
            }
        }
    }

