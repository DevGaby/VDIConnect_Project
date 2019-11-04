
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
    [Authorize]
    public class AuthenticationController : ApiController
    {
        public class AuthUser
        {
            public int id;
            public string firstname;
            public string lastname;
            public string password;
            public string token;
            public string mail;
            public string phone;
            public string role;
        }

        public class LoggedUser
        {
            public int id;
            public string firstname;
            public string lastname;
            public string mail;
            public string role;
            public string token;
        }

        /// <summary>
        /// Connexion
        /// </summary>
        /// <param name="userC"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("api/auth/Login")]
        public IHttpActionResult Login([FromBody]AuthUser userC)
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    Person user = db.Person.Where(x => x.Mail == userC.mail).FirstOrDefault();
                    LoggedUser logUser = new LoggedUser();
                    if (user == null)
                        return BadRequest("Error contact technical support");

                    bool validPass = BCrypt.Net.BCrypt.Verify(userC.password, user.Password);
                    if (user.Mail == userC.mail && validPass == true)
                    {
                        logUser.id = user.Id;
                        logUser.mail = user.Mail;
                        logUser.lastname = user.Lastname;
                        logUser.firstname = user.Firstname;
                        logUser.role = db.Role.Where(x => x.Id == user.RoleId).Select(x => x.Label).FirstOrDefault();
                        return Ok(logUser);
                    }
                    return Unauthorized();
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode Login:\n Message : {0};\n  InnerException : {1};\n Stacktrace : {2}\n", exp.Message, exp.InnerException, exp.StackTrace));
                }
            }
        }

        /// <summary>
        /// Inscription
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("api/auth/Register")]
        public IHttpActionResult Register([FromBody]Person newUser)
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    Person user = db.Person.Where(x => x.Mail == newUser.Mail).FirstOrDefault();
                    if (user != null)
                        return BadRequest("User existing");

                    //Formatage du Prenom
                    Int32 fisrstnameLength = newUser.Firstname.Length - 1;
                    string firstname = newUser.Firstname;
                    string firstLetter = firstname.Substring(0, 1);
                    string lastLetter = firstname.Substring(1, fisrstnameLength);

                    newUser.Firstname = firstLetter + lastLetter;
                    newUser.AccountArchive = false;
                    newUser.Lastname = newUser.Lastname.ToUpper();
                    newUser.RoleId = db.Role.Where(x => x.Label == "User").Select(x => x.Id).FirstOrDefault();
                    newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

                    db.Person.Add(newUser);
                    db.SaveChanges();
                    return Ok(newUser);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode Register: Message : {0};  InnerException : {1}; Stacktrace : {2}", exp.Message, exp.InnerException, exp.StackTrace));
                }

            }
        }

        public class UserPwdEditor
        {
            public string currentPwd;
            public string newPwd;
        }

        /// <summary>
        /// Modification MDP
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("api/auth/Edit/{userId}")]
        public IHttpActionResult EditUserPwd(int userId, [FromBody]UserPwdEditor user)
        {
            using (VDIConnectContext db = new VDIConnectContext())
            {
                try
                {
                    var oldUser = db.Person.Find(userId);
                    string pwd = BCrypt.Net.BCrypt.HashPassword(user.newPwd);

                    if (oldUser == null)
                        return NotFound();

                    bool verifyPwd = BCrypt.Net.BCrypt.Verify(user.currentPwd, oldUser.Password);

                    if (!verifyPwd)
                        return BadRequest("Error password");

                    else if (oldUser.Password == pwd)
                        return BadRequest("Old password is same of new");

                    oldUser.Password = pwd;
                    db.Entry(oldUser).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok(oldUser);
                }
                catch (Exception exp)
                {
                    return BadRequest(string.Format("Erreur dans la méthode EditUserPwd: Message : {0};  InnerException : {1}; Stacktrace : {2}", exp.Message, exp.InnerException, exp.StackTrace));
                }

            }
        }

    }
}
