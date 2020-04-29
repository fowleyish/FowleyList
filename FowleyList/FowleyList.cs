using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FowleyList
{
    public class FowleyList<T>
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
            get => items[index];
            set => items[index] = value;
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
                    if (items[i].Equals(item))
                    {
                        int currentIndexValue = i;
                        for (int j = currentIndexValue; j < count; j++)
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
            FowleyList<T> newArray = new FowleyList<T>();
            for (int i = 0; i < l1.Count; i++)
            {
                if (l2.Exists(l1[i]))
                {
                    l1.Remove(l1[i]);
                }
            }
        }


    }
}
