using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework0
{
    public class MyLinkedList<T> : IList<T>,IEnumerable<T>,IComparable,ICloneable
    {
        public MyLinkedListNode<T> firstNode;
        public MyLinkedListNode<T> lastNode;
        private int count = 0;

        public int Count {
            get => count;
        }
        
        public MyLinkedListNode<T> First => firstNode;

        public MyLinkedListNode<T> Last => lastNode;

        public bool IsReadOnly => false;

        public T this[int index] { get => MoveToNodeByIndex(index).filling; set => throw new NotImplementedException(); }

        /*public MyLinkedList(T firstElementValue)
        {
            firstNode = new MyLinkedListNode<T>(firstElementValue);
            lastNode = firstNode;
        }*/
        public MyLinkedList()
        {
            firstNode = null;
            lastNode = null;
        }

        public void AddLast(T fill)
        {
            if (fill == null)
            {
                throw new ArgumentNullException(nameof(fill));
            }

            if (lastNode == null)
            {
                lastNode = new MyLinkedListNode<T>(lastNode, fill);
                firstNode = lastNode;
            }
            else
            {
                lastNode = new MyLinkedListNode<T>(lastNode, fill);
            }
            count++;
        }

        public void AddFirst(T fill)
        {
            if (fill == null)
            {
                throw new ArgumentNullException(nameof(fill));
            }

            if (firstNode == null)
            {
                firstNode = new MyLinkedListNode<T>(fill, firstNode);
                lastNode = firstNode;
            }
            else
            {
                firstNode = new MyLinkedListNode<T>(fill, firstNode);
            }
            count++;
        }

        /*public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    MoveToNodeByIndex(i).filling = MoveToNodeByIndex(i+1).filling;
                }
                count--;
            }
        }*/
        public void RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Out of range!");
            }

            int currentIndex = 0;
            MyLinkedListNode<T> currentItem = this.firstNode;
            MyLinkedListNode<T> prevItem = null;
            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.next;
                currentIndex++;
            }
            if (this.count == 0)
            {
                this.firstNode = null;
            }
            else if (prevItem == null)
            {
                this.firstNode = currentItem.next;
                this.firstNode.previous = null;
            }
            else if (index == count - 1)
            {
                prevItem.next = currentItem.next;
                lastNode = prevItem;
                currentItem = null;
            }
            else
            {
                prevItem.next = currentItem.next;
                currentItem.next.previous = prevItem;
            }
            count--;
        }

        public void Clear()
        {
            firstNode = null;
            lastNode = null;
            count = 0;
        }
        public void Insert(int index, T fill)
        {
            count++;
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Out of range!");
            }
            MyLinkedListNode<T> newItem = new MyLinkedListNode<T>(fill);
            int currentIndex = 0;
            MyLinkedListNode<T> currentItem = this.firstNode;
            MyLinkedListNode<T> prevItem = null;
            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.next;
                currentIndex++;
            }
            if (index == 0)
            {
                newItem.previous = this.firstNode.previous;
                newItem.next = this.firstNode;
                this.firstNode.previous = newItem;
                this.firstNode = newItem;
            }
            else if (index == count - 1)
            {
                newItem.previous = this.lastNode;
                this.lastNode.next = newItem;
                newItem = this.lastNode;
            }
            else
            {
                newItem.next = prevItem.next;
                prevItem.next = newItem;
                newItem.previous = currentItem.previous;
                currentItem.previous = newItem;
            }
        }

        public MyLinkedListNode<T> MoveToNodeByIndex(int index)
        {
            MyLinkedListNode<T> currentNode = firstNode;
            for (int i = 1; i <= index; i++)
            {
                if (currentNode.next != null)
                    currentNode = currentNode.next;
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            return currentNode;
        }

        public int IndexOf(T item)
        {
            int itemIndex = -1;
            for (int i = 0; i < Count; i++)
            {
                if (MoveToNodeByIndex(i).filling.Equals(item))
                {
                    itemIndex = i;
                    break;
                }
            }
            return itemIndex;
        }
        
        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (lastNode == null)
            {
                lastNode = new MyLinkedListNode<T>(lastNode, item);
                firstNode = lastNode;
            }
            else
            {
                lastNode = new MyLinkedListNode<T>(lastNode, item);
            }

            count++;
        }

        public bool Contains(T item)
        {
            var current = firstNode;
            while (current!=null)
            {
                if (current.filling.Equals(item))
                {
                    return true;
                }
                else
                {
                    current = current.next;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            RemoveAt(IndexOf(item));
            return true;
        }
    

        public IEnumerator<T> GetEnumerator()
        {
            var current = firstNode;
            while (current != null)
            {
                yield return current.filling;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public int CompareTo(object other)
        {
            if (other is MyLinkedList<T>)
            {
                MyLinkedList<T> ls2 = (MyLinkedList<T>)other;
                return Count.CompareTo(ls2.Count);
            }
            else
                throw new ArgumentException("Object is not of type MyLinkedList.");
        }

        
        
        public object Clone()
        {
            MyLinkedList<T> temp = new MyLinkedList<T>();
            AddRange(temp);
            return temp;
        }
        public void AddRange(MyLinkedList<T> temp)
        {
            foreach(var variable in this)
            {
                temp.Add(variable);
            }
        }
    }
    /*public class MyLinkedListComparer : IComparer<MyLinkedList<string>>
    {
        public int Compare(MyLinkedList<string> x, MyLinkedList<string> y)
        {
            return this.CompareNumberOfElems(x, y);
        }

        public int CompareNumberOfElems(MyLinkedList<string> x, MyLinkedList<string> y)
        {
            if (x.Count > y.Count)
            {
                return -1;
            }
            else if (x.Count < y.Count)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }*/

}
