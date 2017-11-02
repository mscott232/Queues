/**
* Queue - creates a queue of objects that can be added to and removed
*
* <pre>
*
* Assignment: #3
* Course: ADEV-3001
* Date Created: November 2, 2017
* 
* Revision Log
* Who        When       Reason
* --------- ---------- ----------------------------------
*
* </pre>
*
* @author Matt Scott
* @version 1.0
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class Queue<T> where T : IComparable<T>
    {
        const string STUDENT = "Matt Scott 0286401";

        private Node<T> head;
        private Node<T> tail;
        private int size;

        /// <summary>
        /// No arg Queue constructor
        /// </summary>
        public Queue() { }

        /// <summary>
        /// Add a new node to the Queue at the tail
        /// </summary>
        /// <param name="element">Generic data type to add to Queue</param>
        public void Enqueue(T element)
        {
            Node<T> node = new Node<T>(element);

            // Determine if queue is empty
            if(size == 0)
            {
                head = node;
            }
            else
            {
                tail.SetNext(node);
            }

            tail = node;
            size++;
        }

        /// <summary>
        /// Return the first data item on the Queue. Throw exception if empty.
        /// </summary>
        /// <returns>The heads element</returns>
        public T Front()
        {
            // Determine if the queue is empty
            if(size == 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                return head.GetElement();
            }
        }

        /// <summary>
        /// Remove the node at the head of the Queue and return the data it contains
        /// </summary>
        /// <returns>The old heads data</returns>
        public T Dequeue()
        {
            // Determine if the queue is empty
            if(size == 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                T oldData = head.GetElement();

                // Determine if size is equal to 1 if it is head and tail are set to null
                if(size == 1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    // Set new head
                    head = head.GetNext();
                }

                size--;
                return oldData;
            }
        }

        /// <summary>
        /// Returns the size of the queue
        /// </summary>
        /// <returns>Int value of the size</returns>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// Returns true if stack is less than or equal to 0, false if greater
        /// </summary>
        /// <returns>True if less than or equal to 0, false when greater</returns>
        public bool IsEmpty()
        {
            return size <= 0;
        }
    }
}
