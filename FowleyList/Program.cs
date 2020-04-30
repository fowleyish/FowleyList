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
            Console.WriteLine(fowleyList.ToString(", "));

            FowleyList<int> killMe = new FowleyList<int>();
            killMe.Add(22);
            killMe.Add(22);
            killMe.Add(13);
            killMe.Add(100);
            Console.WriteLine(killMe.ToString(", "));

            FowleyList<int> added = fowleyList + killMe;
            Console.WriteLine("===ADDED===");
            Console.WriteLine(added.ToString(", "));

            FowleyList<int> subtracted = fowleyList - killMe;
            Console.WriteLine("===SUBTRACTED===");
            Console.WriteLine(subtracted.ToString(", "));

        }
    }
}
