using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework0;
using System.Collections.Generic;

namespace LinkedListTests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void CompareLists_MyAndNet_TrueReturned()
        {
            var test = new MyLinkedList<string>();
            var netList = new List<string>();
            Assert.AreEqual(netList.Add("my1"),test.Add("my1"));
            test.Add("my2");
            test.Insert(1, "my3");
            test.Add("my4");
            test.Remove("my3");
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            test.Clear();
        }
    }
}
