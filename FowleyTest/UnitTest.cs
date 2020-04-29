using Microsoft.VisualStudio.TestTools.UnitTesting;
using FowleyList;
using System;

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



        //  +============================+
        //  |  operator+ overload tests  |
        //  +============================+



        [TestMethod]
        public void Plus_AddTwoLists_ReturnNewList()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);
            int expected = 6;
            int actual;
            // act
            list3 = list1 + list2;
            actual = list3.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] 
        public void Plus_AddTwoLists_ReturnValueAtIndex3()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);
            int expected = 4;
            int actual;
            // act
            list3 = list1 + list2;
            actual = list3[3];
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Plus_AddEmptyListAndListWithValues_ReturnNewListIdenticalToFirstList()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            int expected = 3;
            int actual;
            // act
            list3 = list1 + list2;
            actual = list3.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Plus_AddTwoEmptyLists_ReturnNothing()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            int expected = 0;
            int actual;
            // act
            list3 = list1 + list2;
            actual = list3.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }



        //  +============================+
        //  |  operator- overload tests  |
        //  +============================+



        [TestMethod]
        public void Minus_SubtractOneListFromAnotherList_ReturnMinimizedList()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(3);
            list2.Add(5);
            list2.Add(6);
            string expected = "1,2";
            string actual;
            // act
            list3 = list1 - list2;
            actual = list3.ToString(",");
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_SubtractOneListFromAnotherListWithNoMatches_ReturnOriginalList()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);
            string expected = "1,2,3";
            string actual;
            // act
            list3 = list1 - list2;
            actual = list3.ToString(",");
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_SubtractAnEmptyListFromAnotherList_ReturnOriginalList()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            string expected = "1,2,3";
            string actual;
            // act
            list3 = list1 - list2;
            actual = list3.ToString(",");
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_SubtractOneListFromAnEmptyList_ReturnCount0()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);
            int expected = 0;
            int actual;
            // act
            list3 = list1 - list2;
            actual = list3.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_SubtractOneListFromItself_ReturnEmptyList()
        {
            // arrange
            FowleyList<string> list1 = new FowleyList<string>();
            FowleyList<string> list2;
            list1.Add("no");
            list1.Add("no");
            list1.Add("never");
            int expected = 0;
            int actual;
            // act
            list2 = list1 - list1;
            actual = list2.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_SubtractTwoEmptyLists_ReturnEmptyList()
        {
            // arrange
            FowleyList<string> list1 = new FowleyList<string>();
            FowleyList<string> list2 = new FowleyList<string>();
            FowleyList<string> list3;
            int expected = 0;
            int actual;
            // act
            list3 = list1 - list2;
            actual = list3.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_SubtractOneListFromAnotherListWithRepeatingValues_ReturnMinimizedList()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            list1.Add(1);
            list1.Add(2);
            list1.Add(2);
            list2.Add(2);
            list2.Add(5);
            list2.Add(1);
            string expected = "2";
            string actual;
            // act
            list3 = list1 - list2;
            actual = list3.ToString(",");
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_SubtractOneListWithRepeatingValuesFromAnotherList_ReturnMinimizedList()
        {
            // arrange
            FowleyList<int> list1 = new FowleyList<int>();
            FowleyList<int> list2 = new FowleyList<int>();
            FowleyList<int> list3;
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(3);
            list2.Add(3);
            list2.Add(2);
            string expected = "1,2";
            string actual;
            // act
            list3 = list1 - list2;
            actual = list3.ToString(",");
            // assert
            Assert.AreEqual(expected, actual);
        }

    }
}
