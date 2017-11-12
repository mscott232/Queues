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

        public BreadthFirst(char[,] maze)
        {
            this.maze = maze;
            queue = new Queue<Point>();
        }

        public bool BreadthFirstSearch (int startingRow, int startingColumn)
        {
            char visitedMarker = 'V';

            Point startingPoint = new Point(startingRow, startingColumn);
            queue.Enqueue(startingPoint);

            while(queue.GetSize() > 0 || result)
            {
                Point p = queue.Dequeue();
                int row = p.GetRow();
                int column = p.GetColumn();

                maze[row, column] = visitedMarker;

                if (maze[row + 1, column] == 'E' || maze[row + 1, column] == ' ')
                {
                    if (maze[row + 1, column] == 'E')
                    {
                        result = true;
                        break;
                    }

                    queue.Enqueue(new Point(row + 1, column, row, column));
                }

                if (maze[row, column + 1] == 'E' || maze[row, column + 1] == ' ')
                {
                    if (maze[row, column + 1] == 'E')
                    {
                        result = true;
                        break;
                    }

                    queue.Enqueue(new Point(row, column + 1, row, column));
                }

                if (maze[row, column - 1] == 'E' || maze[row, column - 1] == ' ')
                {
                    if (maze[row, column - 1] == 'E')
                    {
                        result = true;
                        break;
                    }

                    queue.Enqueue(new Point(row, column - 1, row, column));
                }

                if (maze[row - 1, column] == 'E' || maze[row - 1, column] == ' ')
                {
                    if (maze[row - 1, column] == 'E')
                    {
                        result = true;
                        break;
                    }

                    queue.Enqueue(new Point(row - 1, column, row, column));
                }
            }

            return result;
        }
    }
}
