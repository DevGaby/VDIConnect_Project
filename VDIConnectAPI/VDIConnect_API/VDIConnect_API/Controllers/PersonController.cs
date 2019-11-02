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
    public class PersonController : ApiController
    {
        // <summary>
        /// Methode qui recherche l'ensemble des utilisateurs non archivé de l'application
        /// </summary>
        /// <returns> Liste des utilisateurs </returns>
        [HttpGet]
        [Route("api/person/GetPersons/", Name = "GetPersons")]
        public IHttpActionResult GetPersons()
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    List<Person> persons = db.Person.Where(x => x.AccountArchive == false).Include(x => x.Role).ToList();
                    return Ok(persons);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode GetPersons:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }

        /// <summary>
        /// Methode qui cherche l'utilisateur possédant l'Id passé en parametre
        /// </summary>
        /// <param name="idPerson"></param>
        /// <returns> L'utilisateur possédant l'Id </returns>
        [HttpGet]
        [Route("api/person/GetPerson/{idPerson}", Name = "GetPerson")]
        public IHttpActionResult GetPerson(int idPerson)
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    Person person = db.Person.Where(x => x.Id == idPerson).Include(x => x.Role).FirstOrDefault();
                    if (person == null)
                    {
                        return NotFound();
                    }
                    return Ok(person);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode GetPerson:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                }
            }
        }

        /// <summary>
        ///  Methode qui cherche les utilisateurs possédant le roleId passé en parametre
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns> La liste des utilisateurs non archivé possédant ce role</returns>
        [HttpGet]
        [Route("api/person/GetPersonsByRole/{roleId}", Name = "GetPersonsByRole")]
        public IHttpActionResult GetPersonsByRole(int roleId)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    List<Person> persons = db.Person.Where(x => x.RoleId == roleId && x.AccountArchive == false).Include(x => x.Role).ToList();
                    return Ok(persons);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode GetPersons:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }


        /// <summary>
        /// Méthode qui créee un nouvelle utilisateur
        /// </summary>
        /// <param name="person"></param>
        /// <returns> L'utilisateur crée </returns>
        [HttpPost]
        [Route("api/person/PostPerson/", Name = "PostPerson")]
        public IHttpActionResult PostPerson([FromBody]Person person)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    person.AccountArchive = false;
                    person.Lastname = person.Lastname.ToUpper();

                    /// Formatage du Prenom
                    string firstname = person.Firstname;

                    db.Person.Add(person);
                    db.SaveChanges();
                    return Ok(person);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode PostPerson: Message : {0};  InnerException : {1}; Stacktrace : {2}", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }


        /// <summary>
        /// Modifie les informations de l'utilisateur possédant l'Id passée en parametre
        /// </summary>
        /// <param name="idPerson"></param>
        /// <param name="person"></param>
        /// <returns> L'utilisateur modifié </returns>
        [HttpPut]
        [Route("api/person/PutPerson/{idPerson}", Name = "PutPerson")]
        public IHttpActionResult PutPerson(int idPerson, [FromBody] Person person)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    Person personModify = db.Person.Find(idPerson);
                    if (personModify == null)
                        return NotFound();

                    personModify.Lastname = person.Lastname.ToUpper();
                    personModify.Firstname = person.Firstname;
                    personModify.Username = person.Username;
                    personModify.Mail = person.Mail;
                    personModify.Phone = person.Phone;
                    personModify.Username = person.Username;
                    personModify.City = person.City;
                    personModify.Phone = person.Phone;
                    personModify.RoleId = person.RoleId;

                    db.Entry(personModify).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok(personModify);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode PutPerson:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }

        /// <summary>
        /// Méthode d'archivage d'un utilisateur
        /// </summary>
        /// <param name="idPerson"></param>
        /// <returns> L'utilisateur archivé </returns>
        [HttpPut]
        [Route("api/person/ArchivePerson/{idPerson}", Name = "ArchivePerson")]
        public IHttpActionResult ArchivePerson(int idPerson)
        {
            try
            {
                using (VDIConnectContext db = new VDIConnectContext())
                {
                    Person archivedPerson = db.Person.Find(idPerson);
                    if (archivedPerson == null)
                        return NotFound();
                    // List<Event> eventOrganiser = db.Event.Where(x => x.DateEnd != null && x.IdHote == personId || x.IdVDI == personId).ToList();

                    archivedPerson.AccountArchive = true;
                    db.Entry(archivedPerson).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok(archivedPerson);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(string.Format("Erreur dans la méthode ArchivePerson:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
            }
        }
    }
}

