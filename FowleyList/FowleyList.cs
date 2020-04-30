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

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        // Methods
        public void IncreaseCapacity()
        {
            // copy values to new list
            capacity *= 2;
            T[] oldList = items;
            items = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                items[i] = oldList[i];
            }
        }

        public void Add(T item)
        {
            if ( count == capacity )
            {
                IncreaseCapacity();
            }
            count++;
            int maxIndex = count - 1;
            items[maxIndex] = item;
        }

        public bool Remove(T item)
        {
            if (Exists(item))
            {
                for (int i = 0; i < count; i++)
                {
                    if (items[i].Equals(item)) // PROBLEM: continues to grab items after whatever
                    {                          // temparray with what I want to keep?
                        int currentIndexValue = i;
                        for (int j = currentIndexValue; j < count -1; j++)
                        {
                            items[j] = items[j + 1]; 
                        }
                    }
                }
                count--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Exists(T item)
        {
            bool exists = false;
            for (int i = 0; i < capacity; i++)
            {
                if (items[i].Equals(item))
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
        public string ToString(string delim = "")
        {
            string str = "";
            for (int i = 0; i < count; i++)
            {
                str += items[i];
                if (i != count - 1)
                {
                    str += delim;
                }
            }
            return str;
        }

        public static FowleyList<T> operator +(FowleyList<T> l1, FowleyList<T> l2)
        {
            FowleyList<T> newArray = new FowleyList<T>();
            for (int i = 0; i < l1.count; i++)
            {
                newArray.Add(l1[i]);
            }
            for (int i = 0; i < l2.count; i++)
            {
                newArray.Add(l2[i]);
            }
            return newArray;
        }

        public static FowleyList<T> operator -(FowleyList<T> l1, FowleyList<T> l2)
        {
            FowleyList<T> itemsToRemove = new FowleyList<T>();
            FowleyList<T> returnArray = l1;
            for (int i = 0; i < l1.Count; i++)
            {
                if (l2.Exists(l1[i]))
                {
                    itemsToRemove.Add(l1[i]);
                    l2.Remove(l1[i]);
                }
            }
            foreach (T x in itemsToRemove)
            {
                returnArray.Remove(x);
            }
            return returnArray;
        }

        public FowleyList<T> Zip(FowleyList<T> zipper)
        {

        }

        public FowleyList<T> Sort()
        {

        }
    }
}
