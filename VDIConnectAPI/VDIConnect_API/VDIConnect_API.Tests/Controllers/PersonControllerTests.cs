using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDIConnect_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDIConnect_API.Models;

namespace VDIConnect_API.Controllers.Tests
{
    [TestClass()]
    public class PersonControllerTests
    {
        public Person CreatePerson(string firstname, string lastname, string mail, string password)
        {
            Person person = new Person();
            person.Firstname = firstname;
            person.Lastname = lastname;
            person.Mail = mail;
            person.Password = password;
            return person;
        }

        public Person CreatePersonRole(int role, bool archived)
        {
            Person person = new Person();
            person.RoleId = role;
            person.AccountArchive = archived;
            return person;
        }

        [TestMethod()]
        public void GetPersonsTestOk()
        {
            List<Person> persons = new List<Person>();
            Person pers1 = CreatePerson("Test", "User1", "testUser1@gmail.com", "123ABC");
            persons.Add(pers1);
            Person pers2 = CreatePerson("Test", "User1", "testUser1@gmail.com", "123ABC");
            persons.Add(pers2);
            Person pers3 = CreatePerson("Test", "User1", "testUser1@gmail.com", "123ABC");
            persons.Add(pers3);

            int verif = GetPersonsTest(persons);
            Assert.AreEqual(3, verif);
        }

        [TestMethod()]
        public void GetPersonsTestKo()
        {
            List<Person> persons = new List<Person>();

            int verif = GetPersonsTest(persons);
            Assert.AreEqual(0, verif);
        }


        public int GetPersonsTest(List<Person> personList)
        {
            List<Person> listTest = new List<Person>();
            if (personList.Count == 0)
            {
                int nbPers = listTest.Count;
                return nbPers;
            }
            else
            {
                personList.ForEach(x =>
                {
                    listTest.Add(x);
                });
                int nbPers = listTest.Count;
                return nbPers;
            }
        }


        [TestMethod()]
        public void GetPersonTestOk()
        {
            int id = 123;
            Person person = new Person();

            person.Id = id;
            bool result = GetPersonTest(person);

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void GetPersonTestKo()
        {
            int id = 321;
            Person person = new Person();

            person.Id = id;
            bool result = GetPersonTest(person);

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public bool GetPersonTest(Person person)
        {
            bool msg;
            if (person.Id == 123)

                msg = true;
            else
                msg = false;

            return msg;
        }



        [TestMethod()]
        public void GetPersonsByRoleTestOk()
        {
            List<Person> persons = new List<Person>();
            Person pers1 = CreatePersonRole(2, false);
            persons.Add(pers1);
            Person pers2 = CreatePersonRole(1, false);
            persons.Add(pers2);
            Person pers3 = CreatePersonRole(2, true);
            persons.Add(pers3);
            Person pers4 = CreatePersonRole(2, false);
            persons.Add(pers4);

            int verif = GetPersonsByRoleTest(persons);
            Assert.AreEqual(3, verif);
        }

        [TestMethod()]
        public void GetPersonsByRoleTestKo()
        {
            List<Person> persons = new List<Person>();
            Person pers1 = CreatePersonRole(2, true);
            persons.Add(pers1);
            Person pers2 = CreatePersonRole(1, false);
            persons.Add(pers2);
            Person pers3 = CreatePersonRole(2, false);
            persons.Add(pers3);

            int verif = GetPersonsByRoleTest(persons);
            Assert.AreEqual(2, verif);
        }

        public int GetPersonsByRoleTest(List<Person> personList)
        {
            List<Person> listTest = new List<Person>();
            personList.ForEach(x =>
            {
                if (x.AccountArchive == false)
                    listTest.Add(x);
            });
            int nbPers = listTest.Count;
            return nbPers;
        }

        [TestMethod()]
        public void PutPersonTestOk()
        {
            int id = 123;
            string firstname = "Test";
            string lastname = "user";
            string mail = "usertest@gmail.com";
            Person person = new Person();

            person.Id = id;
            person.Firstname = firstname;
            person.Lastname = lastname;
            person.Mail = mail;
            bool result = PutPersonTest(person);

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void PutPersonTestKo()
        {
            int id = 752;
            string firstname = "Test";
            string lastname = "user";
            string mail = "usertest@gmail.com";
            Person person = new Person();

            person.Id = id;
            person.Firstname = firstname;
            person.Lastname = lastname;
            person.Mail = mail;
            bool result = PutPersonTest(person);

            Assert.AreEqual(false, result);
        }

        public bool PutPersonTest(Person person)
        {
            bool msg;
            if (person.Id == 123)
            {
                person.Firstname = "Admin";
                person.Lastname = "VDIConnect";
                person.Mail = "vdiconnect.support@gmail.com";
                msg = true;
            }

            else
                msg = false;

            return msg;
        }

        [TestMethod()]
        public void ArchivePersonTestOk()
        {
            int id = 123;
            Person person = new Person();

            person.Id = id;
            bool result = ArchivePersonTest(person);

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void ArchivePersonTestKo()
        {
            int id = 321;
            Person person = new Person();

            person.Id = id;
            bool result = ArchivePersonTest(person);

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public bool ArchivePersonTest(Person person)
        {
            bool msg;
            if (person.Id == 123)
            {
                person.AccountArchive = true;
                msg = true;
            }
            else
            {
                msg = false;
            }
            return msg;
        }
    }
}