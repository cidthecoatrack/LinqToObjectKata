using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqToObjectKata;
using System.Collections.Generic;

namespace LinqToObjectKata.Test
{
    [TestClass]
    public class AnyBucketTests
    {
        [TestMethod]
        public void CanUseAny()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.Any();
        }

        [TestMethod]
        public void FindsAny()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(numbers.Any());
        }

        [TestMethod]
        public void FindsAnyByPredicate()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(numbers.Any(x => x % 2 == 0));
        }

        [TestMethod]
        public void CanUseDistinct()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.Distinct();
        }

        [TestMethod]
        public void DistinctWorks()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 3, 4, 5 };
            Assert.AreEqual(5, numbers.Distinct().Count());
        }

        [TestMethod]
        public void DistinctWorksWithPredicateThing()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 3, 4, 5 };
            Assert.AreEqual(5, numbers.Distinct(new ThisIsMyComparerDammit()).Count());
        }

        [TestMethod]
        public void CanUseWhere()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.Where(x => x > 2);
        }

        [TestMethod]
        public void WhereReturnsNumbersGreaterThanTwo()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(3, numbers.Where(x => x > 2).Count());
        }

        [TestMethod]
        public void EmptyArrayDoesntBreakWhere()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.IsNotNull(numbers.Where(x => false));
        }

        [TestMethod]
        public void WhereReturnsNumbersGreaterThanOneWithEvenIndexes()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(2, numbers.Where((x, i) => x > 1 && i % 2 == 0).Count());
        }

        [TestMethod]
        public void CanFindFirst()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.First();
        }

        [TestMethod]
        public void FindsFirstElement()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(1, numbers.First());
        }

        [TestMethod]
        public void FindsFirstSatisfactoryElement()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(2, numbers.First(x => x % 2 == 0));
        }

        [TestMethod]
        public void CanFindLast()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.Last();
        }

        [TestMethod]
        public void FindsLast()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(5, numbers.Last());
        }

        [TestMethod]
        public void FindsLastByPredicate()
        {
            IEnumerable<Int32> numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(4, numbers.Last(x => x % 2 == 0));
        }

        [TestMethod]
        public void AssertTruth()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CountExists()
        {
            IEnumerable<Int32> numbers = new Int32[] { 1, 2, 3, 4, 5 };
            numbers.Count();
        }

        [TestMethod]
        public void CanCountEnumerableOfOneItem()
        {
            IEnumerable<Int32> numbers = new Int32[] { 1 };
            Assert.AreEqual(1, numbers.Count());
        }

        [TestMethod]
        public void CanCountEnumerableOfAnySize()
        {
            List<Int32> numbers = new List<Int32>();
            Random random = new Random();
            Int32 count = 0;

            while (random.Next() > random.Next() / 2)
            {
                numbers.Add(random.Next());
                count++;
            }

            Assert.AreEqual(count, numbers.Count());
        }

        [TestMethod]
        public void CanCountUsingPredicate()
        {
            IEnumerable<Int32> numbers = new Int32[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(3, numbers.Count(x => x > 2));
        }

        [TestMethod]
        public void CanCountEnumerableOfAnySizeUsingPredicate()
        {
            List<Int32> numbers = new List<Int32>();
            Random random = new Random();
            Int32 count = 0;

            while (random.Next() > random.Next() / 2)
            {
                Int32 number = random.Next();
                numbers.Add(number);
                if (number < Int32.MaxValue / 2)
                    count++;
            }

            Assert.AreEqual(count, numbers.Count(x => x < Int32.MaxValue / 2));
        }

        private class ThisIsMyComparerDammit : IEqualityComparer<Int32>
        {
            public Boolean Equals(Int32 x, Int32 y)
            {
                return (Math.Abs(x - y) < 1);
            }

            public Int32 GetHashCode(Int32 obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
