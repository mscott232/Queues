/**
* NodeTest – Methods to test the node class
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
    using NUnit.Framework;

    [TestFixture]
    class NodeTest
    {
        /**
         * Default constructor for test class NodeTest
         */
        public NodeTest() { }

        /**
         * Sets up the test fixture.
         *
         * Called before every test case method.
         */
        [SetUp]
        public void SetUp() { }

        /**
         * Tears down the test fixture.
         *
         * Called after every test case method.
         */
        [TearDown]
        public void TearDown() { }

        /**
        * Test the NoArg constructor, first to make sure it is there and that is sets properties properly.
        */
        [Test]
        public void TestNoArgConstructor()
        {
            Node<Point> node1 = new Node<Point>();

            Assert.That(node1, Is.Not.Null);
            Assert.That(node1.GetData, Is.Null);
            Assert.That(node1.GetNext, Is.Null);
            Assert.That(node1.GetPrevious, Is.Null);
        }

        /**
         * Test the data arg constructor, make sure the data is there and other properties are null
         */
        [Test]
        public void TestDataArgContructor()
        {
            Point point1 = new Point(1, 1);
            Node<Point> node1 = new Node<Point>(point1);

            Assert.That(node1, Is.Not.Null);
            Assert.That(node1.GetData(), Is.EqualTo(point1));
            Assert.That(node1.GetNext(), Is.Null);
            Assert.That(node1.GetPrevious(), Is.Null);
        }

        /**
         * Test the all arg constructor, make sure the data is there and other properties are set
         */
        [Test]
        public void TestAllArgContructor()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Point point3 = new Point(3, 3);
            Node<Point> node1 = new Node<Point>(point1);
            Node<Point> node2 = new Node<Point>(point2);
            Node<Point> testNode = new Node<Point>(point3, node1, node2);

            Assert.That(testNode, Is.Not.Null);
            Assert.That(testNode.GetData(), Is.EqualTo(point3));
            Assert.That(testNode.GetNext(), Is.EqualTo(node2));
            Assert.That(testNode.GetPrevious(), Is.EqualTo(node1));
        }

        /**
         * Test the GetData method to determine if the proper data is returned
         */
        [Test]
        public void TestGetData()
        {
            Point point1 = new Point(1, 1);
            Node<Point> node1 = new Node<Point>(point1);

            Assert.That(node1.GetData(), Is.EqualTo(point1));
        }

        /**
         * Test the SetData method to determine if the proper data is added to the node
         */
        [Test]
        public void TestSetData()
        {
            Point point1 = new Point(1, 1);
            Node<Point> node1 = new Node<Point>();

            node1.SetData(point1);
            Assert.That(node1.GetData(), Is.EqualTo(point1));
        }

        /**
         * Test the GetPrevious method to determine if the proper data is returned
         */
        [Test]
        public void TestGetPrevious()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Node<Point> node1 = new Node<Point>(point1);
            Node<Point> node2 = new Node<Point>(point2, node1, null);

            Assert.That(node2.GetPrevious(), Is.EqualTo(node1));
        }

        /**
         * Test the SetPrevious method to determine if the proper data is added to the node
         */
        [Test]
        public void TestSetPrevious()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Node<Point> node1 = new Node<Point>(point1);
            Node<Point> node2 = new Node<Point>(point2);

            node2.SetPrevious(node1);
            Assert.That(node2.GetPrevious(), Is.EqualTo(node1));
        }

        /**
         * Test the GetNext method to determine if the proper data is returned
         */
        [Test]
        public void TestGetNext()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Point point3 = new Point(3, 3);
            Node<Point> node1 = new Node<Point>(point1);
            Node<Point> node2 = new Node<Point>(point2);
            Node<Point> testNode = new Node<Point>(point3, node1, node2);

            Assert.That(testNode.GetNext(), Is.EqualTo(node2));
        }

        /**
         * Test the SetNext method to determine if the proper data is returned
         */
        [Test]
        public void TestSetNext()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Point point3 = new Point(3, 3);
            Node<Point> node1 = new Node<Point>(point1);
            Node<Point> node2 = new Node<Point>(point2);
            Node<Point> testNode = new Node<Point>(point3, node1, null);

            testNode.SetNext(node2);
            Assert.That(testNode.GetNext(), Is.EqualTo(node2));
        }
    }
}
