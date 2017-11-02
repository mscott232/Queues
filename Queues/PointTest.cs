/**
* PointTest – Methods to test the Point class
*
* <pre>
*
* Assignment: #2
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
    class PointTest
    {
        #region Test Fixture Setup and Tear Down

        /**
         * Default constructor for test class PointTest
         */
        public PointTest() { }

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

        #endregion

        /**
         *  Method to test the row and column constructor of the point class
         */
        [Test]
        public void TestPointRowColumnConstructor()
        {
            Point point1 = new Point(1, 1);

            Assert.That(point1, Is.Not.Null);
            Assert.That(point1.GetRow(), Is.EqualTo(1));
            Assert.That(point1.GetColumn(), Is.EqualTo(1));
        }

        /**
         *  Method to test the all arg constructor of the point class
         */
        [Test]
        public void TestPointAllArgConstructor()
        {
            Point point1 = new Point(1, 1, 2, 2);

            Assert.That(point1, Is.Not.Null);
            Assert.That(point1.GetRow(), Is.EqualTo(1));
            Assert.That(point1.GetColumn(), Is.EqualTo(1));
            Assert.That(point1.GetParentRow(), Is.EqualTo(2));
            Assert.That(point1.GetParentColumn(), Is.EqualTo(2));
        }

        /**
         *  Method to test the GetRow method that it returns the proper data
         */
        [Test]
        public void TestGetRow()
        {
            Point point1 = new Point(1, 1);

            Assert.That(point1.GetRow(), Is.EqualTo(1));
        }

        /**
         *  Method to test the GetColumn method that it returns the proper data
         */
        [Test]
        public void TestGetColumn()
        {
            Point point1 = new Point(1, 1);

            Assert.That(point1.GetColumn(), Is.EqualTo(1));
        }

        /**
         *  Method to test the GetParentRow method that it returns the proper data
         */
        [Test]
        public void TestGetParentRow()
        {
            Point point1 = new Point(1, 1, 2, 2);

            Assert.That(point1.GetParentRow(), Is.EqualTo(2));
        }

        /**
         *  Method to test the SetParentRow method that it sets the proper data
         */
        [Test]
        public void TestSetParentRow()
        {
            Point point1 = new Point(1, 1, 2, 2);

            point1.SetParentRow(3);
            Assert.That(point1.GetParentRow(), Is.EqualTo(3));
        }

        /**
         *  Method to test the GetParentColumn method that it returns the proper data
         */
        [Test]
        public void TestGetParentColumn()
        {
            Point point1 = new Point(1, 1, 2, 2);

            Assert.That(point1.GetParentColumn(), Is.EqualTo(2));
        }

        /**
         *  Method to test the SetParentColumn method that it sets the proper data
         */
        [Test]
        public void TestSetParentColumn()
        {
            Point point1 = new Point(1, 1, 2, 2);

            point1.SetParentColumn(3);
            Assert.That(point1.GetParentColumn(), Is.EqualTo(3));
        }

        /**
         *  Method to test the ToString method that it returns the proper string
         */
        [Test]
        public void TestToString()
        {
            Point point1 = new Point(1, 1);

            Assert.That(point1.ToString(), Is.EqualTo("[1,1]"));
        }
    }
}
