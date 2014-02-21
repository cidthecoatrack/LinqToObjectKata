using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqToObjectKata.Test
{
    [TestFixture]
    public class AnyBucketTests
    {
        [Test]
        public void CanUseAny()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.Any();
        }

        [Test]
        public void FindsAny()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(numbers.Any());
        }

        [Test]
        public void FindsAnyByPredicate()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(numbers.Any(x => x % 2 == 0));
        }

        [Test]
        public void AnyFalse()
        {
            var numbers = new List<Int32>();
            Assert.That(numbers.Any(), Is.False);
        }

        [Test]
        public void CanUseDistinct()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.Distinct();
        }

        [Test]
        public void DistinctWorks()
        {
            var numbers = new[] { 1, 2, 3, 3, 4, 5 };
            var distinct = numbers.Distinct();
            Assert.That(distinct, Contains.Item(1));
            Assert.That(distinct, Contains.Item(2));
            Assert.That(distinct, Contains.Item(3));
            Assert.That(distinct, Contains.Item(4));
            Assert.That(distinct, Contains.Item(5));
            Assert.AreEqual(5, distinct.Count());
        }

        [Test]
        public void DistinctWorksWithPredicateThing()
        {
            var numbers = new[] { 1, 2, 3, 3, 4, 6 };
            var distinct = numbers.Distinct(new ThisIsMyComparerDammit());
            Assert.That(distinct, Contains.Item(1));
            Assert.That(distinct, Contains.Item(6));
            Assert.AreEqual(2, distinct.Count());
        }

        [Test]
        public void CanUseWhere()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.Where(x => x > 2);
        }

        [Test]
        public void WhereReturnsNumbersGreaterThanTwo()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(3, numbers.Where(x => x > 2).Count());
        }

        [Test]
        public void EmptyArrayDoesntBreakWhere()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.IsNotNull(numbers.Where(x => false));
        }

        [Test]
        public void WhereReturnsNumbersGreaterThanOneWithEvenIndexes()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(2, numbers.Where((x, i) => x > 1 && i % 2 == 0).Count());
        }

        [Test]
        public void CanFindFirst()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.First();
        }

        [Test]
        public void FindsFirstElement()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(1, numbers.First());
        }

        [Test]
        public void FindsFirstSatisfactoryElement()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(2, numbers.First(x => x % 2 == 0));
        }

        [Test]
        public void CanFindLast()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.Last();
        }

        [Test]
        public void FindsLast()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(5, numbers.Last());
        }

        [Test]
        public void FindsLastByPredicate()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(4, numbers.Last(x => x % 2 == 0));
        }

        [Test]
        public void AssertTruth()
        {
            Assert.Pass();
        }

        [Test]
        public void CountExists()
        {
            var numbers = new Int32[] { 1, 2, 3, 4, 5 };
            numbers.Count();
        }

        [Test]
        public void CanCountEnumerableOfOneItem()
        {
            var numbers = new Int32[] { 1 };
            Assert.AreEqual(1, numbers.Count());
        }

        [Test]
        public void CanCountEnumerableOfAnySize()
        {
            var numbers = new List<Int32>();
            var random = new Random();
            var count = 0;

            while (random.Next() > random.Next() / 2)
            {
                numbers.Add(random.Next());
                count++;
            }

            Assert.AreEqual(count, numbers.Count());
        }

        [Test]
        public void CanCountUsingPredicate()
        {
            var numbers = new Int32[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(3, numbers.Count(x => x > 2));
        }

        [Test]
        public void CanCountEnumerableOfAnySizeUsingPredicate()
        {
            var numbers = new List<Int32>();
            var random = new Random();
            var count = 0;

            while (random.Next() > random.Next() / 2)
            {
                var number = random.Next();
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
                return (Math.Abs(x - y) < 2);
            }

            public Int32 GetHashCode(Int32 obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
