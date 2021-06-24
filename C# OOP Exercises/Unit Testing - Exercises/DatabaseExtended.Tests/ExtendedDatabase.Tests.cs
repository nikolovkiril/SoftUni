using System;
using System.ComponentModel;
//using DatabaseExtended;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person[] persons;

        [SetUp]
        public void Setup()
        {
            Person person = new Person(23, "Pesho");
            Person person2 = new Person(33, "Gosho");
            persons = new Person[] { person, person2 };
            database = new ExtendedDatabase(persons);
        }
        [Test]
        public void PersonConstructorWorkCorrectly()
        {
            string name = "Pesho";
            long id = 1233223;
            var person = new Person(id, name);
            Assert.AreEqual(person.Id, id);
            Assert.AreEqual(person.UserName, name);
        }

        [Test]

        public void DatbaseConstructorWithEmptyCollection()
        {
           database = new ExtendedDatabase();

            Assert.AreEqual(0,database.Count);
        }
        [Test]
        public void DatbaseConstructorWorkCorrectly()
        {
            Person person = new Person(23, "Pesho");
            Person person2 = new Person(33, "Gosho");

            persons = new Person[] { person, person2 };
            database = new ExtendedDatabase(persons);
            int expectedCount = 2;
            int actualCount = database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AddRangeMethodThrowException()
        {
            persons = new Person[17];
            Assert.Throws<ArgumentException>(() =>  new ExtendedDatabase(persons));

        }
        [Test]
        public void Test_Add_Range_Exception()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            Assert.Throws<ArgumentException>(() =>
                this.database = new ExtendedDatabase(people));
        }
        [Test]
        public void AddMethodThrowException()
        {
            persons = new Person[15];
            for (int i = 1; i < persons.Length; i++)
            {
                persons[i] = new Person(i + 1, $"{i + 1}nqkuvSITam");
                database.Add(persons[i]);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Wert")));
        }
        [Test]
        public void AddMethodWorkCorrectly()
        {
            database.Add(new Person(44, "awds"));
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        public void Test_Add_Person_With_Existing_Username()
        {
            Person person = new Person(104, "Pesho");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }
        [Test]
        public void AddMethodThrowExceptionWithUser()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(33, "Pesho")));
        }
        [Test]
        public void Test_Add_Null_People()
        {
            Person[] people = new Person[5];

            Assert.Throws<NullReferenceException>(() =>
                this.database = new ExtendedDatabase(people));
        }
        [Test]
        public void AddMethodThrowExceptionWithId()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(23, "asd")));
        }
        [Test]
        public void RemoveMethodIsWorkTrue()
        {
            var expectedCount = 1;
            database.Remove();
            var actualCount = database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void RemoveMethodThrowExeptionIfCountIsZero()
        {
            database.Remove();
            database.Remove();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void FindByUsernameIsWorkCorrectly()
        {
            string nameToSearch = "Pesho";
            Person founfPerson = database.FindByUsername(nameToSearch);
            Assert.AreEqual(nameToSearch, founfPerson.UserName);
        }

        [Test]
        public void FindByUsernameThrowExeptionWithNullReference()
        {
            string nameToSearch = null;
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(nameToSearch));
        }
        [Test]
        public void FindByUsernameThrowExeptionWhenNameIsNotFound()
        {
            string nameToSearch = "sdvkso";
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(nameToSearch));
        }
        [Test]
        public void FindByIdMethodWorkCorrectly()
        {
            int idToSearch = 23;
            Person founfPerson = database.FindById(idToSearch);
            Assert.AreEqual(idToSearch, founfPerson.Id);
        }
        [Test]
        public void FindByIdThrowExeptionWithNullReference()
        {
            int idToSearch = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(idToSearch));
        }
        [Test]
        public void FindByIdThrowExeptionWhenIdIsNotFound()
        {
            int idToSearch = 44;
            Assert.Throws<InvalidOperationException>(() => database.FindById(idToSearch));
        }
    }

}