using System;
using System.Collections.Generic;
using System.Text;

namespace FowleyList
{
    public class FowleyList<T>
    {
        // Member vars
        private T[] items;
        public T[] Items { get; set; }
        private int count;
        public int Count { get; set; }
        private int capacity;
        public int Capacity { get; set; }

        // Constructor
        public FowleyList()
        {
            items = new T[4];
            count = 0;
            capacity = 4;
        }

        // Methods
        public void Add(T item)
        {
            
        }

        public void Remove(T item)
        {

        }
    }
}
