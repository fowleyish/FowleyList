using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;
using System.Text;
using System.IO;

namespace FowleyList
{
    public class FowleyList<T> : IEnumerable // set constrictors for accepting only lists of certain types (no objects, etc) for sorting
    {
        // Member vars
        private T[] items;
        public T[] Items
        {
            get => items;
            set => items = value;
        }
        public T this[int index]
        {
            get
            {
                if (index <= count)
                {
                    return items[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                items[index] = value;
            }
        }
        private int count;
        public int Count 
        {
            get => count;
            set => count = value;
        }
        private int capacity;
        public int Capacity 
        {
            get => capacity;
            set => capacity = value;
        }

        // Constructor
        public FowleyList()
        {
            items = new T[4];
            count = 0;
            capacity = 4;
        }

        // Allows for list enumeration
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        // Methods

        // Increases the capacity of the array when the count threshold is reached
        public void IncreaseCapacity()
        {
            capacity *= 2; // Double capacity
            T[] oldList = items;
            items = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                items[i] = oldList[i]; // Assigns all values from the original array to the new increased-capacity array
            }
        }

        // Adds an item to a list
        public void Add(T item)
        {
            if ( count == capacity ) // Increases capacity if the count and capacity are the same; this resolves indexing issues
            {
                IncreaseCapacity();
            }
            count++; // Increment count
            int maxIndex = count - 1; // Get the last index of the array
            items[maxIndex] = item; // ...and assign the item value to that index
        }

        // Removes an item from a list. See Remove() documentation in the repo root README.md
        public bool Remove(T item)
        {
            if (Exists(item)) // If the item exists...
            {
                for (int i = 0; i < count; i++) // ...loop through this array...
                {
                    if (items[i].Equals(item)) // ...and where they match...
                    {                          
                        int currentIndexValue = i; // 1. Record this index value
                        for (int j = currentIndexValue; j < count -1; j++) // 2. Loop through the remaining array items
                        {
                            items[j] = items[j + 1]; // 3. And push the items to the last index, thus overriding the identified match value
                        }
                    }
                }
                count--; // Decrement count
                return true;
            }
            else // If there is no match, then this returns false and nothing happens to the array
            {
                return false;
            }
        }

        // Checks to see if a specified item exists in a list
        public bool Exists(T item)
        {
            bool exists = false; // init return
            for (int i = 0; i < capacity; i++)
            {
                if (items[i].Equals(item)) // If this value matches the passed value, return true
                {
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        // Note on the following method:
        // When passing an argument into this ToString(),
        // use of the "override" keyword is forbidden.
        // Therefore, this is a unique method rather than
        // an override of the native ToString() Array method.
        public string ToString(string delim = "") // Optional delimiter when invoking method
        {
            string str = "";
            for (int i = 0; i < count; i++)
            {
                str += items[i];
                if (i != count - 1) // IF statement prevents writing delimiter after last index
                {
                    str += delim;
                }
            }
            return str;
        }

        // + override
        public static FowleyList<T> operator +(FowleyList<T> l1, FowleyList<T> l2)
        {
            FowleyList<T> newArray = new FowleyList<T>(); // newArray to return
            for (int i = 0; i < l1.count; i++) // Add all items from the first list
            {
                newArray.Add(l1[i]);
            }
            for (int i = 0; i < l2.count; i++) // Add all items from the second list
            {
                newArray.Add(l2[i]);
            }
            return newArray;
        }

        // - override
        public static FowleyList<T> operator -(FowleyList<T> l1, FowleyList<T> l2)
        {
            FowleyList<T> itemsToRemove = new FowleyList<T>(); // Create new ref list for removal of items
            FowleyList<T> returnArray = l1; // Create new ref list and populate values with l1, which prevents accidentally changing l1
            for (int i = 0; i < l1.Count; i++) // Loop through l1...
            {
                if (l2.Exists(l1[i]))
                {
                    itemsToRemove.Add(l1[i]); 
                    l2.Remove(l1[i]);
                }
            } // ...and remove whatever items match between the two lists
            foreach (T x in itemsToRemove)
            {
                returnArray.Remove(x); // from the temp itemsToRemove list, Remove() all items from the returnArray
            }
            return returnArray;
        }

        // "Zips" two lists together
        public FowleyList<T> Zip(FowleyList<T> zipper)
        {
            FowleyList<T> zippedList = new FowleyList<T>(); // Create new list
            FowleyList<T> biggestList; // Create new list reference for the list with the highest count
            // Determine which of the two lists has the highest count
            if (count > zipper.count)
            {
                biggestList = this; 
            }
            else
            {
                biggestList = zipper;
            }
            // Get highest and lowest counts of lists
            int biggestCount = Math.Max(count, zipper.count);
            int smallestCount = Math.Min(count, zipper.count);
            for (int i = 0; i < biggestCount; i++) // Set max loop iteration using the count of the biggest list
            {
                if (i < smallestCount)
                {
                    zippedList.Add(this[i]);
                    zippedList.Add(zipper[i]);
                }
                else // If the count has exceeded the smaller list, only add values from the bigger list
                {
                    zippedList.Add(biggestList[i]);
                }
            }
            return zippedList;
        }

        //public FowleyList<T> Sort()
        //{

        //}
    }
}
