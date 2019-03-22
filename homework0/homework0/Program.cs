using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework0
{
    class Program
    {
        static void SortKek(List<MyLinkedList<string>> kek)
        {
            for (int i = 0; i < kek.Count - 1; i++)
            {
                for (int j = i + 1; j < kek.Count; j++)
                {
                    if (kek[i].CompareTo(kek[j]) > 0)
                    {
                        var temp = kek[i];
                        kek[i] = kek[j];
                        kek[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Stopwatch s = Stopwatch.StartNew();
            var TestNet = new List<string>();
            //ListMethods(TestNet);
            s.Stop();
            Console.WriteLine($"Time taken: {s.Elapsed.TotalMilliseconds}ms");
            Console.WriteLine();
            Stopwatch s2 = Stopwatch.StartNew();
            
            var Test = new MyLinkedList<string>();

            Test.Add("my1");
            //Hard Cloning:
            /*var Test2 = (MyLinkedList<string>)Test.Clone();
            Test.Add("my2");
            foreach (var item in Test)
            {
                Console.WriteLine("Object that I clone:" + item);
            }
            foreach (var item in Test2)
            {
                Console.WriteLine("Clone:" + item);
            }*/

            List<MyLinkedList<string>> listArray = new List<MyLinkedList<string>>() { Test };
            var Test3 = new MyLinkedList<string>();
            Test3.Add("my2");
            Test3.Add("my3");
            listArray.Add(Test3);
            var Test4 = new MyLinkedList<string>();
            Console.WriteLine("Govno:" + Test);
            foreach (var govno in Test)
            {
                Console.WriteLine(govno);
            }
            Test4.Add("my4");
            listArray.Add(Test4);
            foreach (var item in listArray)
            {
                Console.WriteLine(item.Count);
            }
            Console.WriteLine("There is a sort:");
            /*listArray.Sort(delegate (MyLinkedList<string> x, MyLinkedList<string> y)
            {
               return x.Count.CompareTo(y.Count);
            });*/
            SortKek(listArray);
            //listArray.Sort(); //Ascending
            //List<MyLinkedList<string>>.Sort(listArray); //Descending
            foreach (var item in listArray)
            {
                Console.WriteLine(item.Count);
            }
            //ListMethods(Test);
            s2.Stop();
            Console.WriteLine($"Time taken: {s2.Elapsed.TotalMilliseconds}ms");
            Console.ReadKey();
        }

        private static void ListMethods(IList<string> test)
        {
            test.Add("my1");
            test.Add("my2");
            Console.WriteLine("I`m inserting 'my3' in 2-nd position:");
            test.Insert(1, "my3");
            Console.WriteLine("Index of the 'my3' element is: " + test.IndexOf("my3"));
            Console.WriteLine("Print 2-nd element of the list:" + test[1]);
            Console.WriteLine("Print out all elements of the list:");
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            test.Add("my4");
            Console.WriteLine("I recently added 'my4' and remove 'my3' and want to print out the list:");
            test.Remove("my3");
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Is the list contains string 'my'? Answer is: " + test.Contains("my1"));
            Console.WriteLine("How many elements list contains: " + test.Count);
            test.Clear();
            Console.WriteLine("I recently clear the list and want to print out all elements:");
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("How many elements list contains: " + test.Count);

            // Console.WriteLine(test.First.filling);
            //Console.WriteLine(test.MoveToNodeByIndex(2).filling);
        }
    }
}
