using System;

namespace CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        [TestMethod]
        public void CreateEmtyListWithZeroElemements()
        {
            var numbers = new DynamicList<int>();
            Assert.AreEqual(0, numbers.Count, "Number of elements is not equal to zero.");
        }

        [TestMethod]
        public void ConstructingListWithOneElementMustAddElementInList()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(5);

            Assert.AreEqual(5, numbers[0], "The list element's value is not equal of value of added element.");
            Assert.AreEqual(1, numbers.Count, "The count is not equal of 1.");
        }

        [TestMethod]
        public void ConstructingListWithMoreElementsMustGetCorectElementsCount()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(0);
            numbers.Add(1);
            numbers.Add(-4);

            Assert.AreEqual(3, numbers.Count, "Invalid count of elements.");
        }

        [TestMethod]
        public void ConstructingListWithFewElementsChangeValueInSomePosition()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(0);
            numbers.Add(1);
            numbers.Add(-4);
            numbers[0] = 100;

            Assert.AreEqual(100, numbers[0], "Value is not equal of expected.");
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentOutOfRangeException))]
        public void AgainstANegativeIndexShouldThrowArgumentOutOfRangeException()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(10);
            var number = numbers[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AgainstIndexGreaterThanTheNumberOfElementsShouldThrowArgumentOutOfRangeException()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(10);
            var number = numbers[numbers.Count];
        }

        [TestMethod] public void FoundingElementInListShouldReturnIndexOfElement()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(10);
            numbers.Add(12);
            numbers.Add(-14);
            var index = numbers.IndexOf(-14);

            Assert.AreEqual(2, index, "Invalid index.");
        }

        [TestMethod]
        public void RemovingElementAtIndexShouldRemoveElementOfList()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(15);
            numbers.Add(10);
            var number = numbers.RemoveAt(0);
            var result = numbers.IndexOf(0);

            Assert.AreEqual(-1, result, "The elements is founded.");
            Assert.AreEqual(10, numbers[0], "Do not reorders the elements.");
        }


        [TestMethod]
        public void RemovingElementAtIndexShouldReturnElement()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(15);
            var number = numbers.RemoveAt(0);

            Assert.AreEqual(15, number, "Value is not equal of expected.");
        }

        [TestMethod]
        public void RemovingElementAtIndexShouldDecreaseCount()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(15);
            var number = numbers.RemoveAt(0);

            Assert.AreEqual(0, numbers.Count, "The count does not decrease.");
        }

        [TestMethod]
        public void FoundingElementInListShouldNotFoundIt()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(10);
            numbers.Add(12);
            numbers.Add(-14);

            var initialCount = numbers.Count;
            var index = numbers.Remove(12);

            Assert.IsFalse(numbers.Contains(12), "The element is not removed.");
            Assert.IsTrue(numbers.Count < initialCount,  "The count does not decrease.");
            Assert.AreEqual(1, index, "Return invalid index.");
        }
    }
}
