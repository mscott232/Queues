using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    using NUnit.Framework;

    [TestFixture]
    class QueueTest
    {
        /**
         * Default constructor for test class NodeTest
         */
        public QueueTest() { }

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
         * Method to test no arg queue contructor
         */
        [Test]
        public void TestQueueConstructor()
        {
            Queue<Point> queue = new Queue<Point>();

            Assert.That(queue, Is.Not.Null);
        }

        /**
         * Method to test Front() throws exception when size is 0
         */
        [Test]
        public void TestFront_Exception()
        {
            Queue<Point> queue = new Queue<Point>();

            Assert.That(() => queue.Front(), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test Front() returns correct head data
         */
        [Test]
        public void TestFront_Successful()
        {
            Queue<Point> queue = new Queue<Point>();
            Point point1 = new Point(1, 1);

            queue.Enqueue(point1);
            Assert.That(queue.Front(), Is.EqualTo(point1));
        }

        /**
         * Method to test Enqueue() when queue is empty
         */
        [Test]
        public void TestEnqueue_Queue_Is_Empty()
        {
            Queue<Point> queue = new Queue<Point>();
            Point point1 = new Point(1, 1);

            queue.Enqueue(point1);
            Assert.That(queue.Front(), Is.EqualTo(point1));
        }

        /**
         * Method to test Enqueue() when queue is not empty
         */
        [Test]
        public void TestEnqueue_Queue_Is_Not_Empty()
        {
            Queue<Point> queue = new Queue<Point>();
            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, 2);
            Point point3 = new Point(3, 3);

            queue.Enqueue(point1);
            queue.Enqueue(point2);
            queue.Enqueue(point3);

            queue.Dequeue();
            Assert.That(queue.Front(), Is.EqualTo(point2));
        }

        /**
         * Method to test Dequeue() throws exception when size is 0
         */
        [Test]
        public void TestDequeue_Exception()
        {
            Queue<Point> queue = new Queue<Point>();

            Assert.That(() => queue.Front(), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test Dequeue() when size is 1
         */
        [Test]
        public void TestDequeue_Size_1()
        {
            Queue<Point> queue = new Queue<Point>();
            Point point1 = new Point(1, 1);

            queue.Enqueue(point1);

            Assert.That(queue.Dequeue(), Is.EqualTo(point1));
            Assert.That(queue.GetSize(), Is.EqualTo(0));
        }

        /**
         * Method to test Dequeue() when size is greater than 1
         */
        [Test]
        public void TestDequeue_Size_Greater_Than_1()
        {
            Queue<Point> queue = new Queue<Point>();
            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, 2);

            queue.Enqueue(point1);
            queue.Enqueue(point2);

            Assert.That(queue.Dequeue(), Is.EqualTo(point1));
            Assert.That(queue.Front(), Is.EqualTo(point2));
        }

        /**
         * Method to test GetSize() returns the correct value
         */
        [Test]
        public void TestGetSize()
        {
            Queue<Point> queue = new Queue<Point>();
            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, 2);

            queue.Enqueue(point1);
            queue.Enqueue(point2);

            Assert.That(queue.GetSize(), Is.EqualTo(2));
        }

        /**
         * Method to test IsEmpty() returns true when empty
         */
         [Test]
         public void TestIsEmpty_True()
        {
            Queue<Point> queue = new Queue<Point>();

            Assert.That(queue.IsEmpty(), Is.True);
        }

        /**
         * Method to test IsEmpty() returns false when not empty
         */
        [Test]
        public void TestIsEmpty_False()
        {
            Queue<Point> queue = new Queue<Point>();
            Point point1 = new Point(1, 1);

            queue.Enqueue(point1);

            Assert.That(queue.IsEmpty(), Is.False);
        }
    }
}
