using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read all the lines in the text file and load them into a string array
            String[] lines = File.ReadAllLines(@"C:\Users\Matt\Documents\School\Term 5\Programming 4\Assignments\Assignment 3\maze.maze");
            //String[] lines = File.ReadAllLines(@"C:\Users\Matt\Documents\School\Term 5\Programming 4\Assignments\Assignment 3\TestMazeNoExit.maze");
            //String[] lines = File.ReadAllLines(@"C:\Users\Matt\Documents\School\Term 5\Programming 4\Assignments\Assignment 3\TestMazeExit.maze");


            int[] dimensions = lines[0].Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int[] startingPoint = lines[1].Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            char[,] maze = new char[dimensions[0], dimensions[1]];

            // Load the array from the lines in the text file
            for (int i = 2; i < lines.Length; i++)
            {
                char[] items = lines[i].ToCharArray();

                for (int j = 0; j < items.Length; j++)
                {
                    maze[i - 2, j] = items[j];
                }
            }

            BreadthFirst breadthFirst = new BreadthFirst(maze);

            if(breadthFirst.BreadthFirstSearch(startingPoint[0], startingPoint[1]))
            {
                Console.WriteLine(breadthFirst.ExitFound());
                Stack<Point> stack = breadthFirst.PathToFollow();
                while (!stack.IsEmpty())
                {
                    Console.WriteLine(String.Format("{0}", stack.Pop().ToString()));
                }
                Console.WriteLine(breadthFirst.DumpMaze());
            }
            else
            {
                Console.WriteLine(breadthFirst.NoExit());
                Console.WriteLine(breadthFirst.DumpMaze());
            }

            Console.ReadKey();
        }
    }
}
