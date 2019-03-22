using System;

namespace homework0
{
    public class MyLinkedListNode<T>
    {
        public T filling;
        public MyLinkedListNode<T> previous = null;
        public MyLinkedListNode<T> next = null;

        public MyLinkedListNode(T fill)
        {
            if (fill == null)
            {
                throw new ArgumentNullException(nameof(fill));
            }

            filling = fill;
        }

        public MyLinkedListNode(T fill, MyLinkedListNode<T> myNext)
        {
            if (myNext == null)
            {
                filling = fill;
            }
            else
            {
                filling = fill;
                next = myNext;
                next.previous = this;
            }
        }

        public MyLinkedListNode(MyLinkedListNode<T> myPrevious, T fill)
        {
            if (myPrevious == null)
            {
                filling = fill;
            }
            else
            {
                filling = fill;
                previous = myPrevious;
                previous.next = this;
            }
        }

        public MyLinkedListNode(MyLinkedListNode<T> myPrevious, T fill, MyLinkedListNode<T> myNext)
        {
            filling = fill;
            previous = myPrevious;
            next = myNext;
            previous.next = this;
            next.previous = this;
        }
        public override string ToString()
        {
            return filling.ToString();
        }

    }
}