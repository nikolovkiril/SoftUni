using System;
using System.Security.Cryptography;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database data;

        [SetUp]

        public void Setup()
        {
            this.data = new Database();
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        public void TestConstructorIfWork(int[] paramss)
        {
            int count = paramss.Length;
            this.data = new Database(paramss);
            int realCount = this.data.Count;

            Assert.AreEqual(count, realCount);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenCollectionIsBigger()
        {
            int[] paramss = new int[17];
            Assert.Throws<InvalidOperationException>(() => this.data = new Database(paramss));
        }

        [Test]
        public void AddIncreaseCount()
        {
            this.data.Add(3);
            this.data.Add(1);
            this.data.Add(11);
            int expectedCount = 3;
            int countAtTheMoment = this.data.Count;
            Assert.AreEqual(expectedCount, countAtTheMoment);
        }

        [Test]
        public void AddShouldThrowExceptionWhenCollectionIsBigger()
        {
            for (int i = 0; i < 16; i++)
            {
                this.data.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => this.data.Add(17));
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            this.data.Add(1);
            this.data.Add(2);
            this.data.Remove();
            int expectedCount = 1;
            int realCount = this.data.Count;
            Assert.AreEqual(expectedCount,realCount);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenCollectionIsEmpty()
        {
            this.data.Add(1);
            this.data.Add(2);
            this.data.Remove();
            this.data.Remove();
            Assert.Throws<InvalidOperationException>(() => this.data.Remove());
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] {  })]
        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16  })]
        public void FetchWorkCorrectly(int[] asd)
        {
            this.data = new Database(asd);
            int[] result = this.data.Fetch();
            CollectionAssert.AreEqual(asd, result);
        }
    }
}