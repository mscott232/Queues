﻿/**
* Node – Node constructor plus getters
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
    class Node<T> where T : IComparable<T>
    {
        const string STUDENT = "Matt Scott 0286401";

        private T element;
        private Node<T> previous;
        public Node<T> next;

        /// <summary>
        /// No arg contructor for a node
        /// </summary>
        public Node() { }

        /// <summary>
        /// A element constructor for a node
        /// </summary>
        /// <param name="element">The element to be stored in the node</param>
        public Node(T element)
        {
            this.element = element;
        }

        /// <summary>
        /// An all arg constructor for a node
        /// </summary>
        /// <param name="element">The element to be stored in the node</param>
        /// <param name="previous">The node that was created before this one</param>
        /// <param name="next">The node that was created after this one</param>
        public Node(T element, Node<T> previous, Node<T> next)
        {
            this.element = element;
            this.previous = previous;
            this.next = next;
        }

        /// <summary>
        /// Returns the element stored in the node
        /// </summary>
        /// <returns>The element from the node</returns>
        public T GetElement()
        {
            return element;
        }

        /// <summary>
        /// Adds element to a node
        /// </summary>
        /// <param name="element">The element to be added</param>
        public void SetElement(T element)
        {
            this.element = element;
        }

        /// <summary>
        /// Returns the previous node propertry
        /// </summary>
        /// <returns>The previous node</returns>
        public Node<T> GetPrevious()
        {
            return previous;
        }

        /// <summary>
        /// Sets the previous node property
        /// </summary>
        /// <param name="previous">The previous node</param>
        public void SetPrevious(Node<T> previous)
        {
            this.previous = previous;
        }

        /// <summary>
        /// Returns the next node property
        /// </summary>
        /// <returns>The next node</returns>
        public Node<T> GetNext()
        {
            return next;
        }

        /// <summary>
        /// Sets the next node property
        /// </summary>
        /// <param name="next">The next node</param>
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
    }
}
