using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monaco.Algorithms.Structures
{
    /// <summary>
    /// A generic doubly-linked list implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoublyLinkedList<T> : IEnumerable<T>, IEnumerable
    {
        public DoublyLinkedNode<T> Head { get; private set; }
        public DoublyLinkedNode<T> Tail { get; private set; }

        public int Count { get; set; }

        public DoublyLinkedList()
        {
        }

        public DoublyLinkedList(IEnumerable<T> items)
        {
            foreach (var item in items)
                Add(item);
        }

        /// <summary>
        /// Adds the specified value to the end of the list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Add(T value)
        {
            var node = new DoublyLinkedNode<T>(value);

            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Previous = Tail;
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        /// <summary>
        /// Inserts the specified value before the specified 0-based index of the list
        /// </summary>
        public void Insert(T value, int index)
        {
            if (index < Count && index != 0)
                throw new IndexOutOfRangeException();

            var node = new DoublyLinkedNode<T>(value);

            if(index == 0)
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
                Count++;
                return;
            }

            var nodeVisitor = Head;

            for(int i = 0; i < index; i++)
                nodeVisitor = nodeVisitor.Next;

            node.Next = nodeVisitor;
            node.Previous = nodeVisitor.Previous;
            nodeVisitor.Previous = node;
            Count++;
        }

        /// <summary>
        /// Removes a node from the list
        /// </summary>
        /// <param name="node"></param>
        public void Remove(DoublyLinkedNode<T> node)
        {
            if (node == null)
                throw new NullReferenceException();

            if(Head == node)
            {
                Head = node.Next;
            }
            else if(Tail == node)
            {
                node.Previous.Next = null;
                Tail = node.Previous;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }

            Count--;
        }

        public DoublyLinkedNode<T> this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                    throw new IndexOutOfRangeException();

                var nodeVisitor = Head;
                for (int i = 0; i < index; i++)
                    nodeVisitor = nodeVisitor.Next;

                return nodeVisitor;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public class DoublyLinkedNode<U>
        {
            public DoublyLinkedNode(U value)
            {
                Value = value;
            }

            public DoublyLinkedNode<U> Previous { get; set; }
            public DoublyLinkedNode<U> Next { get; set; }
            public U Value { get; set; }
        }

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private DoublyLinkedList<T> list;
            private DoublyLinkedNode<T> currentNode;
            private bool isEnumerating;

            internal Enumerator(DoublyLinkedList<T> linkedList)
            {
                list = linkedList;
                currentNode = default;
                isEnumerating = false;
            }

            public T Current
            {
                get
                {
                    if (currentNode is null)
                        return default(T);
                    else
                        return currentNode.Value;
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (currentNode is null)
                {
                    if (isEnumerating || list.Count == 0) // Past end of list
                        return false;
                    currentNode = list.Head;
                    isEnumerating = true;
                }
                else if (currentNode.Next is null)
                {
                    currentNode = null;
                    return false;
                }
                else
                    currentNode = currentNode.Next;

                return true;
            }

            public void Reset()
            {
                currentNode = default;
                isEnumerating = false;
            }

            public void Dispose()
            {
            }
        }
    }
}
