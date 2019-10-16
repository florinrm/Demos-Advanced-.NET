using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class CollectionsDemo
    {
        public static void Main(string[] args)
        {
            // colectii orientate pe obiect - care contin doar object, ele pot fi eterogene ca tip de date

            #region ArrayList
            // ArrayList contine doar object
            ArrayList arrayList = new ArrayList();
            arrayList.Add(100);
            string str = "Decebal";
            arrayList.Add(str);
            arrayList.AddRange(new object[] { 1, "fulala", 'c' });

            foreach (var element in arrayList) {
                Console.WriteLine(element);
            }

            // accesarea unui element in ArrayList
            object obj = arrayList[2];

            /*
            // sort nu merge pe un ArrayList eterogen (adica int, string, object etc.), caci nu are cum sa ii compare
            arrayList.Sort();
            int index = arrayList.BinarySearch(str);
            Console.WriteLine(index);
            */

            arrayList.Clear();
            arrayList.Add(42);
            arrayList.Add(124);
            arrayList.Add(10);
            arrayList.Add(420);
            Console.WriteLine("Unsorted");
            foreach (var element in arrayList) {
                Console.WriteLine(element);
            }
            // aici merge sortat arrayList, este omogen acum
            arrayList.Sort();
            Console.WriteLine("Sorted");
            foreach (var element in arrayList) {
                Console.WriteLine(element);
            }
            Console.WriteLine();
            #endregion

            #region Stack - objects only
            // Stack - aici putem avea doar obiecte
            Stack st1 = new Stack();
            st1.Push(1);
            st1.Push('c');
            st1.Push("C# rullz");
            var top = st1.Peek();
            Console.WriteLine("Top of the stack: " + top);
            while (st1.Count != 0) {
                Console.WriteLine("We popped: " + st1.Pop());
            }
            Console.WriteLine();
            #endregion

            #region Queue - objects only
            Queue q1 = new Queue();
            q1.Enqueue(1);
            q1.Enqueue(new object());
            q1.Enqueue("C# beats Java");
            top = q1.Peek();
            Console.WriteLine("Top of the queue: " + top);
            while (q1.Count != 0) {
                Console.WriteLine("We dequeued: " + q1.Dequeue());
            }
            Console.WriteLine();
            #endregion

            #region Hashtable
            Hashtable hashtable = new Hashtable();
            hashtable['c'] = 250;
            object c = hashtable['c'];

            #endregion
            // colectii generice - tipizate

            #region List
            List<int> integersList = new List<int>();
            integersList.Add(1);
            integersList.AddRange(new int[] { 2, 3, 4, 5 });
            Console.WriteLine("Elements from integersList");
            foreach (var elem in integersList) {
                Console.WriteLine(elem);
            }
            #endregion
        }
    }
}
