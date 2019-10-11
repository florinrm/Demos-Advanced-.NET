using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class CollectionsDemo
    {
        public static void Main(string[] args)
        {
            // colectii orientate pe obiect
            // ArrayList contine doar object
            ArrayList arrayList = new ArrayList();
            arrayList.Add(100);
            arrayList.Add("Decebal");
            arrayList.AddRange(new object[] { 1, "fulala", 'c' });

            foreach (var element in arrayList) {
                Console.WriteLine(element);
            }


            List<int> integersList = new List<int>();
            integersList.Add(1);
            integersList.AddRange(new int[] { 2, 3, 4, 5 });
            Console.WriteLine("Elements from integersList");
            foreach (var elem in integersList) {
                Console.WriteLine(elem);
            }
        }
    }
}
