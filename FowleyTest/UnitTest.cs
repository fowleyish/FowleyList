using Microsoft.VisualStudio.TestTools.UnitTesting;
using FowleyList;

namespace FowleyTest
{
    [TestClass]
    public class UnitTest
    {
        //  +====================+
        //  |     Add() tests    |
        //  +====================+



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
            actual = testList[0];
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
            actual = testList[2];
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
        public void Add_IncreaseArrayCapacity_ReturnIndexValueAfterIncrement()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            int fourthItem = 56;
            int fifthItem = 90;
            int expected = 20;
            int actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            testList.Add(fourthItem);
            testList.Add(fifthItem);
            actual = testList[1];
            // assert
            Assert.AreEqual(expected, actual);
        }



        //  +====================+
        //  |   Remove() tests   |
        //  +====================+




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
        public void Remove_RemoveItemFromEmptyList_DoNothing()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            // act
            testList.Remove(1);
        }



        //  +====================+
        //  |  ToString() tests  |
        //  +====================+


        [TestMethod]
        public void ToString_CompressListToSingleString_ReturnString()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            string expected = "942042";
            string actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            actual = testList.ToString();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_CompressListToStringWithDelim_ReturnStringWithDelim()
        {
            // arrange
            FowleyList<int> testList = new FowleyList<int>();
            int firstItem = 94;
            int secondItem = 20;
            int thirdItem = 42;
            string expected = "94, 20, 42";
            string actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            actual = testList.ToString(", ");
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_CompressStringListToSingleStringWithDelim_ReturnStringWithDelim()
        {
            // arrange
            FowleyList<string> testList = new FowleyList<string>();
            string firstItem = "buh";
            string secondItem = "BUH";
            string thirdItem = "buh buh";
            string expected = "buh BUH buh buh";
            string actual;
            // act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            actual = testList.ToString(" ");
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_CompressEmptyListToString_ReturnNothing()
        {
            // arrange 
            FowleyList<int> testList = new FowleyList<int>();
            string expected = "";
            string actual;
            // act
            actual = testList.ToString();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_CompressEmptyListToStringWithDelimiter_ReturnNothing()
        {
            // arrange 
            FowleyList<int> testList = new FowleyList<int>();
            string expected = "";
            string actual;
            // act
            actual = testList.ToString("WAH");
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
