﻿/**
* Stack – Methods to invoke on the constructed stack
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
    public class Stack<T> where T : IComparable<T>
    {
        const string STUDENT = "Matt Scott 0286401";

        private Node<T> head;
        private int size;

        /// <summary>
        /// No arg Stack constructor
        /// </summary>
        public Stack() { }

        /// <summary>
        /// Add a new node containing the element to the Stack at the head
        /// </summary>
        /// <param name="element">Object to add</param>
        public void Push(T element)
        {
            Node<T> toAdd = new Node<T>(element, head, null);
            head = toAdd;
            size++;
        }

        /// <summary>
        /// Return the first element item on the stack. Throw an exception if empty.
        /// </summary>
        /// <returns>The element stored in the node</returns>
        public T Top()
        {
            // Determine if the size of the stack is 0, if it is throw exception if not return the head element
            if (size == 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                return head.GetElement();
            }
        }

        /// <summary>
        /// Remove the node at the head of the stack and return the element it contains
        /// </summary>
        /// <returns>Element stored in the node</returns>
        public T Pop()
        {
            // Determine if the size of the stack is 0, if it is throw exception if not replace the head element but return it's data
            if (size == 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                Node<T> current = head;
                head = head.GetPrevious();
                size--;
                return current.GetElement();
            }
        }

        /// <summary>
        /// Return the size of the current stack
        /// </summary>
        /// <returns>The size of the stack</returns>
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
