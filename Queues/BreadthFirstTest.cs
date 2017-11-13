/**
* BreadthFirstTest – Methods to test the BreadthFirst class
*
* <pre>
*
* Assignment: #3
* Course: ADEV-3001
* Date Created: November 12, 2017
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
using System.IO;

namespace Queues
{
    using NUnit.Framework;

    [TestFixture]
    class BreadthFirstTest
    {
        private string exitMaze = @"C:\Users\Matt\Documents\School\Term 5\Programming 4\Assignments\Assignment 3\TestMazeExit.maze";
        private string noExitMaze = @"C:\Users\Matt\Documents\School\Term 5\Programming 4\Assignments\Assignment 3\TestMazeNoExit.maze";

        /**
         * Default constructor for test class StackTest
         */
        public BreadthFirstTest() { }

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
         * Method to test that BreadthFirstSearch() returns true when maze has exit
         */
        [Test]
        public void TestBreadthFirstSearch_Successful_Exit()
        {
            Maze maze = new Maze(exitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);

            Assert.That(breadthFirst.BreadthFirstSearch(maze.GetStartingPoint()[0], maze.GetStartingPoint()[1]), Is.True);
        }

        /**
         * Method to test that BreadthFirstSearch() returns false when maze has no exit
         */
        [Test]
        public void TestBreadthFirstSearch_Successful_No_Exit()
        {
            Maze maze = new Maze(noExitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);

            Assert.That(breadthFirst.BreadthFirstSearch(maze.GetStartingPoint()[0], maze.GetStartingPoint()[1]), Is.False);
        }

        /**
         * Method to test that NoExit() throws an exception when BreadthFirstSearch() is not completed
         */
        [Test]
        public void TestNoExit_Exception()
        {
            Maze maze = new Maze(noExitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);

            Assert.That(() => breadthFirst.NoExit(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        /**
         * Method to test that NoExit() returns correct string
         */
        [Test]
        public void TestNoExit_Successful()
        {
            Maze maze = new Maze(noExitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);
            breadthFirst.BreadthFirstSearch(maze.GetStartingPoint()[0], maze.GetStartingPoint()[1]);

            Assert.That(breadthFirst.NoExit(), Is.EqualTo("There is no exit out of the maze."));
        }

        /**
         * Method to test that DumpMaze() throws an exception when BreadthFirstSearch() is not completed
         */
        [Test]
        public void TestDumpMaze_Exception()
        {
            Maze maze = new Maze(noExitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);

            Assert.That(() => breadthFirst.DumpMaze(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        /**
         * Method to test that DumpMaze() returns the correct string when no exit is found
         */
        [Test]
        public void TestDumpMaze_No_Exit()
        {
            Maze maze = new Maze(noExitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);
            breadthFirst.BreadthFirstSearch(maze.GetStartingPoint()[0], maze.GetStartingPoint()[1]);
            string dumpMazeString = "\nWWWWWWWWW" +
                                    "\nWWWWVWWWW" +
                                    "\nWWWWVWWWW" +
                                    "\nWVVVVVVVW" +
                                    "\nWWWWVWWWW" +
                                    "\nWWWWVWWWW" +
                                    "\nWWWWWWWWW";

            Assert.That(breadthFirst.DumpMaze(), Is.EqualTo(dumpMazeString));
        }

        /**
         * Method to test that ExitFound() throws an exception when BreadthFirstSearch() is not completed
         */
        [Test]
        public void TestExitFound_Exception()
        {
            Maze maze = new Maze(exitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);

            Assert.That(() => breadthFirst.ExitFound(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        /**
         * Method to test that ExitFound() returns the correct string when an exit is found
         */
        [Test]
        public void TestExitFound_Successful()
        {
            Maze maze = new Maze(exitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);
            breadthFirst.BreadthFirstSearch(maze.GetStartingPoint()[0], maze.GetStartingPoint()[1]);

            Assert.That(breadthFirst.ExitFound(), Is.EqualTo("Path to follow from Start [1,4] to Exit [3,1] - 6 steps:"));
        }

        /**
         * Method to test that ExitFound() throws an exception when BreadthFirstSearch() is not completed
         */
        [Test]
        public void TestPathToFollow_Exception()
        {
            Maze maze = new Maze(exitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);

            Assert.That(() => breadthFirst.PathToFollow(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        /**
         * Method to test thhat PathToFollow() returns a stack with the head node point the same as the starting point
         */
        [Test]
        public void TestPathToFollow_Successful()
        {
            Maze maze = new Maze(exitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);
            breadthFirst.BreadthFirstSearch(maze.GetStartingPoint()[0], maze.GetStartingPoint()[1]);
            Point testPoint = new Point(maze.GetStartingPoint()[0], maze.GetStartingPoint()[1]);
            breadthFirst.ExitFound();
            Point returnedPoint = breadthFirst.PathToFollow().Top();

            Assert.That(returnedPoint.GetRow(), Is.EqualTo(testPoint.GetRow()));
            Assert.That(returnedPoint.GetColumn(), Is.EqualTo(testPoint.GetColumn()));
        }

        /**
         * Method to test that DumpMaze() returns the correct string when an exit is found
         */
        [Test]
        public void TestDumpMaze_Exit()
        {
            Maze maze = new Maze(exitMaze);
            char[,] mazeArray = maze.ConstructMaze();
            BreadthFirst breadthFirst = new BreadthFirst(mazeArray);
            breadthFirst.BreadthFirstSearch(maze.GetStartingPoint()[0], maze.GetStartingPoint()[1]);
            string dumpMazeString = "\nWWWWWWWWW" +
                                    "\nWWWW.WWWW" +
                                    "\nWWWW.WWWW" +
                                    "\nWE...VV W" +
                                    "\nWWWWVWWWW" +
                                    "\nWWWWVWWWW" +
                                    "\nWWWWWWWWW";

            breadthFirst.ExitFound();
            breadthFirst.PathToFollow();
            Assert.That(breadthFirst.DumpMaze(), Is.EqualTo(dumpMazeString));
        }

        // Class used to construct mazes for testing purposes
        private class Maze
        {
            private string mazeFile;
            private int[] dimensions;
            private int[] startingPoint;

            public Maze(string mazeFile)
            {
                this.mazeFile = mazeFile;
            }

            /// <summary>
            /// Constructs a maze and sets dimensions and starting point
            /// </summary>
            /// <returns>The 2d char array maze</returns>
            public char[,] ConstructMaze()
            {
                String[] lines = File.ReadAllLines(mazeFile);

                dimensions = lines[0].Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                startingPoint = lines[1].Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

                char[,] maze = new char[dimensions[0], dimensions[1]];

                for (int i = 2; i < lines.Length; i++)
                {
                    char[] items = lines[i].ToCharArray();

                    for (int j = 0; j < items.Length; j++)
                    {
                        maze[i - 2, j] = items[j];
                    }
                }

                return maze;
            }

            /// <summary>
            /// Returns the dimension
            /// </summary>
            /// <returns>The dimension</returns>
            public int[] GetDimensions()
            {
                return dimensions;
            }

            /// <summary>
            /// Returns the starting point
            /// </summary>
            /// <returns>The starting point</returns>
            public int[] GetStartingPoint()
            {
                return startingPoint;
            }
        }
    }
}
