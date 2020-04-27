using Microsoft.VisualStudio.TestTools.UnitTesting;
using FowleyList;

namespace FowleyTest
{
    [TestClass]
    public class UnitTest
    {
        // Add() tests

        [TestMethod]
        public void Add_AddingOneValueToEmptyFowleyList_AddedValueGoesToIndexZero()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int itemToAdd = 10;
            int expected = 10;
            int actual;
            // act
            testList.Add(itemToAdd);
            actual = testList.Items[0];
            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Add_AddingOneValueToEmptyFowleyList_CountOfFowleyListIncrements()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int itemToAdd = 10;
            int expected = 1;
            int actual;
            // act
            testList.Add(itemToAdd);
            actual = testList.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItemsToExistingFowleyList_ReturnLastIndexValue()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            int expected = 42;
            int actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            actual = testList.Items[2];
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItemsToExistingFowleyList_ReturnCount()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            int expected = 3;
            int actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            actual = testList.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void Add_AddItemsOverFowleyListCapacity_ReturnError()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            int fourthItem = 95;
            int fifthItem = 100;
            int expected = 4;
            int actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            testList.Add(fourthItem);
            testList.Add(fifthItem);
            actual = testList.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }


        // Remove() tests

        [TestMethod]
        public void Remove_RemoveValueFromList_ReturnListCount()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            int expected = 2;
            int actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            // act
            testList.Remove(94);
            actual = testList.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Remove_RemoveSeveralItemsFromList_ReturnListCount()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            int expected = 1;
            int actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            // act
            testList.Remove(94);
            testList.Remove(20);
            actual = testList.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_RemoveItemFromList_ReturnLastIndex()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            int expected = 42;
            int actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            testList.Remove(20);
            actual = testList.Items[1];
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_RemoveSeveralItemsFromList_ReturnLastIndex()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            int expected = 42;
            int actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            testList.Remove(20);
            testList.Remove(94);
            actual = testList.Items[0];
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void Remove_RemoveItemFromEmptyList_ReturnIndexOutOfRangeException()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            // act
            testList.Remove(1);
        }
    }
}
