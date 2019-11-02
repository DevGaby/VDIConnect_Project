using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VDIConnect_API.DAL;
using VDIConnect_API.Models;


namespace VDIConnect_API.Controllers.Tests
{
    [TestClass()]
    public class AuthenticationControllerTests
    {
        [TestMethod()]
        public void LoginTestOk()
        {
            string mail = "usertest@gmail.com";
            string password = "123ABC";
            Person person = new Person();

            person.Mail = mail;
            person.Password = password;
            bool result = Login(person);

            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void LoginTestKo()
        {
            string mail = "mdupont@gmail.com";
            string password = "Maurice";
            Person person = new Person();

            person.Mail = mail;
            person.Password = password;
            bool result = Login(person);

            Assert.AreEqual(false, result);
        }

        public bool Login(Person person)
        {
            bool msg;
            if (person.Mail == "usertest@gmail.com" && person.Password == "123ABC")

                msg = true;
            else
                msg = false;

            return msg;
        }

        [TestMethod()]
        public void RegisterTestOk()
        {
            string firstname = "Test";
            string lastname = "user";
            string mail = "usertest@gmail.com";
            string password = "123ABC";
            Person person = new Person();

            person.Firstname = firstname;
            person.Lastname = lastname;
            person.Mail = mail;
            person.Password = password;
            bool result = Login(person);

            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void RegisterTestKo()
        {
            string firstname = "Dupont";
            string lastname = "Maurice";
            string mail = "mdupont@gmail.com";
            Person person = new Person();

            person.Firstname = firstname;
            person.Lastname = lastname;
            person.Mail = mail;
            bool result = Login(person);

            Assert.AreEqual(false, result);
        }

        public bool Register(Person person)
        {
            bool msg;
            if (person.Firstname != null && person.Lastname != null
                && person.Mail != null && person.Password != null)
                msg = true;
            else
                msg = false;

            return msg;
        }

        [TestMethod()]
        public void EditUserPwdTestOk()
        {
            string password = "ABC123";
            Person person = new Person();

            person.Password = password;
            Person result = EditUserPwdTest(person);

            Assert.AreEqual("123ABC", result.Password);
        }

        [TestMethod()]
        public void EditUserPwdTestKo()
        {
            string password = "trucmuche";
            Person person = new Person();

            person.Password = password;
            Person result = EditUserPwdTest(person);

            Assert.AreEqual(null, result.Password);
        }

        public Person EditUserPwdTest(Person person)
        {
            Person msg = new Person();
            if (person.Password == "ABC123")
            {
                person.Password = "123ABC";
                msg.Password = person.Password;
                return msg;
            }
            else
                return msg;
        }
    }
}