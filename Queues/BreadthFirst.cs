/**
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
    class BreadthFirst
    {
        private char[,] maze;
        private Queue<Point> queue;
        private bool result = false;
        private Queue<Point> pathQueue;
        private Point startingPoint;
        private List<Point> path;
        private bool breadthFirstSearchFinished = false;
        private Point endPoint;        

        public BreadthFirst(char[,] maze)
        {
            this.maze = maze;
            queue = new Queue<Point>();
        }

        public bool BreadthFirstSearch (int startingRow, int startingColumn)
        {
            char visitedMarker = 'V';
            path = new List<Point>();

            startingPoint = new Point(startingRow, startingColumn);
            queue.Enqueue(startingPoint);
            path.Add(startingPoint);
            

            while(queue.GetSize() > 0 || result)
            {
                Point p = queue.Dequeue();
                int row = p.GetRow();
                int column = p.GetColumn();
                path.Add(p);

                maze[row, column] = visitedMarker;

                if (maze[row + 1, column] == 'E' || maze[row + 1, column] == ' ')
                {
                    if (maze[row + 1, column] == 'E')
                    {
                        result = true;
                        breadthFirstSearchFinished = true;
                        endPoint = new Point(row + 1, column, row, column);
                        break;
                    }

                    queue.Enqueue(new Point(row + 1, column, row, column));
                }

                if (maze[row, column + 1] == 'E' || maze[row, column + 1] == ' ')
                {
                    if (maze[row, column + 1] == 'E')
                    {
                        result = true;
                        breadthFirstSearchFinished = true;
                        endPoint = new Point(row, column + 1, row, column);
                        break;
                    }

                    queue.Enqueue(new Point(row, column + 1, row, column));
                }

                if (maze[row, column - 1] == 'E' || maze[row, column - 1] == ' ')
                {
                    if (maze[row, column - 1] == 'E')
                    {
                        result = true;
                        breadthFirstSearchFinished = true;
                        endPoint = new Point(row, column - 1, row, column);
                        break;
                    }

                    queue.Enqueue(new Point(row, column - 1, row, column));
                }

                if (maze[row - 1, column] == 'E' || maze[row - 1, column] == ' ')
                {
                    if (maze[row - 1, column] == 'E')
                    {
                        result = true;
                        breadthFirstSearchFinished = true;
                        endPoint = new Point(row - 1, column, row, column);
                        break;
                    }

                    queue.Enqueue(new Point(row - 1, column, row, column));
                }
            }

            // Determine if queue size is 0 to update search settings when no exit is found
            if(queue.GetSize() == 0)
            {
                breadthFirstSearchFinished = true;
            }

            return result;
        }

        /// <summary>
        /// Returns a string stating there is no exit from the maze
        /// </summary>
        /// <returns>String stating there is no exit</returns>
        public string NoExit()
        {
            if (!breadthFirstSearchFinished)
            {
                throw new InvalidOperationException("Depth First Search did not finish");
            }

            return "There is no exit out of the maze.";
        }

        /// <summary>
        /// Returns a string showing the start exit and number of steps to the exit
        /// </summary>
        /// <returns>String stating an exit was found</returns>
        public string ExitFound()
        {
            if (!breadthFirstSearchFinished)
            {
                throw new InvalidOperationException("Depth First Search did not finish");
            }
            
            Point tracker = endPoint;
            pathQueue = new Queue<Point>();
            pathQueue.Enqueue(tracker);

            foreach (Point pathPoint in path.Reverse<Point>())
            {
                if(pathPoint.GetRow() == tracker.GetParentRow() && pathPoint.GetColumn() == tracker.GetParentColumn())
                {
                    tracker = pathPoint;
                    pathQueue.Enqueue(tracker);
                }
            }

            return String.Format("Path to follow from Start {0} to Exit {1} - {2} steps:", startingPoint.ToString(), endPoint.ToString(), pathQueue.GetSize());
        }

        /// <summary>
        /// Returns the stack
        /// </summary>
        /// <returns>The stack</returns>
        public Stack<Point> PathToFollow()
        {
            if (!breadthFirstSearchFinished)
            {
                throw new InvalidOperationException("Depth First Search did not finish");
            }

            Stack<Point> exitStack = new Stack<Point>();

            while (!pathQueue.IsEmpty())
            {
                Point point = pathQueue.Dequeue();
                exitStack.Push(point);

                if (point != endPoint)
                {
                    maze[point.GetRow(), point.GetColumn()] = '.';
                }
            }

            return exitStack;
        }

        /// <summary>
        /// Returns a string of the maze with visited marks and the steps shown to the exit if it was found 
        /// </summary>
        /// <returns>String of the maze</returns>
        public string DumpMaze()
        {
            if (!breadthFirstSearchFinished)
            {
                throw new InvalidOperationException("Depth First Search did not finish");
            }

            StringBuilder stringBuilder = new StringBuilder();

            // Iterate through the maze and build the string based on that
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                stringBuilder.Append("\n");

                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    stringBuilder.Append(maze[i, j]);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
