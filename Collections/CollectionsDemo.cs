using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Collections
{
    public class CollectionsDemo
    {

        private class MyCompare : IComparer<int> {
            public int Compare(int x, int y) {
                return y - x;
            }
        }

        private class ComparableList<T> : List<T>, IComparable<T> {
            public int CompareTo(T other) {
                return (-1) * CompareTo(other);
            }
        }

        // Action
        private static void Increment(int n) {
            ++n;
        }

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
            hashtable[23] = "C# is da best";
            hashtable["something"] = "ceva";
            hashtable.Remove(23);

            Console.WriteLine("\nIterating through hashtable...");
            foreach(DictionaryEntry elem in hashtable) {
                Console.WriteLine(elem.Key + ": " + elem.Value);
            }

            #region SortedList
            // aici cheile trebuie sa fie de acelasi tip
            SortedList sortedList = new SortedList();
            sortedList['c'] = 'p';
            sortedList.Add('a', 42);
            sortedList.Remove('a');
            sortedList['a'] = "ceva";
            // exemplele de mai jos nu merg, pentru ca avem cheie de tip int, mai sus avem elemente cu cheie de tip char
            // sortedList.Add(1, 2);
            // sortedList[34] = 12;
            Console.WriteLine(sortedList.Count);

            Console.WriteLine("\nIterating through sorted list...");
            foreach(DictionaryEntry elem in sortedList) {
                Console.WriteLine(elem.Key + ": " + elem.Value);
            }
            #endregion

            #region BitArray
            // array de biti (0/1)
            BitArray bitArray = new BitArray(3); // trebuie mentionata capacitatea, se comporta fix ca un array de biti
            bitArray[0] = true;
            bitArray[1] = false;
            bitArray[2] = bitArray[1] ^ bitArray[0]; // xor

            Console.WriteLine("\nIterating through bit array...");
            foreach(var elem in bitArray) {
                Console.WriteLine(elem);
            }
            #endregion

            #endregion
            // colectii generice - tipizate

            #region List
            List<int> integersList = new List<int>();
            integersList.Add(1);
            integersList.AddRange(new int[] { 2, 3, 4, 5 });
            integersList.Remove(4);
            integersList.Sort();
            Console.WriteLine("\nIterating through list...");
            foreach (var elem in integersList) {
                Console.WriteLine(elem);
            }

            integersList.Sort(new MyCompare());
            Console.WriteLine("\nIterating through reversed list...");
            foreach (var elem in integersList) {
                Console.WriteLine(elem);
            }

            ComparableList<int> comparableList = new ComparableList<int>();
            comparableList.Add(5);
            comparableList.Add(8);
            comparableList.Add(1);
            comparableList.Add(20);
            comparableList.Add(3);

            Console.WriteLine("\nIterating to unsorted Comparable list...");
            foreach(var elem in comparableList) {
                Console.WriteLine(elem);
            }

            comparableList.Sort();

            Console.WriteLine("\nIterating to sorted Comparable list...");
            foreach (var elem in comparableList) {
                Console.WriteLine(elem);
            }

            #endregion

            #region Predicate + Action
            // Folosirea de Predicate, care de fapt e o functie booleana
            List<int> greaterThan3 = integersList.FindAll(x => x > 3); // putem folosi 

            // Action - se paseaza o metoda de tip void - lista se modifica in place
            greaterThan3.ForEach(Increment);
            #endregion

            #region LinkedList
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst("first"); // adaugam la capul listei
            linkedList.AddLast("last"); // adaugam la coada listei
            linkedList.AddAfter(linkedList.First, "second"); // adaugarea dupa un nod din lista inlantuita
            linkedList.AddBefore(linkedList.Last, "not last element"); // adaugarea inaintea unui nod din lista

            Console.WriteLine("\nIterating through linked list...");
            foreach(var node in linkedList) {
                Console.WriteLine(node);
            }
            #endregion

            #region Generic Stack
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(5);
            stack.Pop();
            int front = stack.Peek();
            #endregion

            #region Generic Queue
            Queue<int> queueInt = new Queue<int>();
            queueInt.Enqueue(42);
            queueInt.Enqueue(41);
            front = queueInt.Dequeue();
            #endregion

            #region Dictionary
            Dictionary<int, string> dict1 = new Dictionary<int, string>();
            dict1.Add(69, "ayyy");
            dict1.Add(420, "weeeeed");
            dict1.Remove(12);
            dict1.Remove(69);
            dict1[42] = "pwpik";
            Console.WriteLine("\nIterating through dictionary...");
            
            foreach(KeyValuePair<int, string> elem in dict1) {
                Console.WriteLine(elem.Key + ": " + elem.Value);
            }
            #endregion

            #region SortedDictionary
            SortedDictionary<int, string> dict2 = new SortedDictionary<int, string>();
            dict2.Add(69, "ayyy");
            dict2.Add(420, "weeeeed");
            dict2.Remove(12);
            dict2.Remove(69);
            dict2[42] = "pwpik";
            dict2[12] = "mwah";
            Console.WriteLine("\nIterating through sorted dictionary...");

            foreach (KeyValuePair<int, string> elem in dict2) {
                Console.WriteLine(elem.Key + ": " + elem.Value);
            }
            #endregion

            #region SortedList
            SortedList<int, string> dict3 = new SortedList<int, string>();
            dict3.Add(69, "ayyy");
            dict3.Add(420, "weeeeed");
            dict3.Remove(12);
            dict3.Remove(69);
            dict3[42] = "pwpik";
            dict3[12] = "mwah";
            Console.WriteLine("\nIterating through generic sorted list...");

            foreach (KeyValuePair<int, string> elem in dict3) {
                Console.WriteLine(elem.Key + ": " + elem.Value);
            }
            #endregion

            // colectii specializate
            #region StringCollection
            StringCollection stringCollection = new StringCollection();
            stringCollection.Add("ayy");
            stringCollection.Add("ceva");
            stringCollection.Add("auuuuch");
            stringCollection[1] = "altceva";
            stringCollection.RemoveAt(2);
            #endregion

            #region StringDictionary
            StringDictionary stringDictionary = new StringDictionary();
            stringDictionary.Add("first", "ayy");
            stringDictionary.Add("second", "altceva");
            stringDictionary["third"] = "ceva, dar mai altceva";

            Console.WriteLine("\nIterating through stringDictionary...");
            foreach(DictionaryEntry elem in stringDictionary) {
                Console.WriteLine(elem.Key + ": " + elem.Value);
            }
            #endregion

            #region NameValueCollection
            NameValueCollection collection = new NameValueCollection();
            collection.Add("ceva", "altceva");
            collection.Add("ceva", "inca ceva");
            collection.Add("ceva", "69");
            collection.Add("altceva", "nimic");

            Console.WriteLine("\nIterating through NameValueCollection...");
            foreach (string elem in collection) {
                Console.WriteLine(elem + ": " + collection.Get(elem));
            }
            #endregion
        }
    }
}
