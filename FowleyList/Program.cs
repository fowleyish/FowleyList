using System;
using System.Collections.Generic;

namespace FowleyList
{
    class Program
    {
        static void Main(string[] args)
        {
            FowleyList<int> fowleyList = new FowleyList<int>();
            fowleyList.Add(1);
            fowleyList.Add(4);
            fowleyList.Add(7);
            fowleyList.Add(14);
            fowleyList.Add(22);
            fowleyList.Add(24);
            fowleyList.Add(43);
            fowleyList.Add(100);
            fowleyList.Add(101);
            fowleyList.Remove(4);
            Console.WriteLine(fowleyList.ToString());
        }
    }
}
