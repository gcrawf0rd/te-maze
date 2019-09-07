using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Model;
using Maze.Parse;

namespace Maze
{
    public static class Program
    {
        public static void Main()
        {
            string fileMaze = "..\\..\\External\\Map.xml";
            string fileObjective = "..\\..\\External\\Objective.txt";

            try
            {
                ParseInput(fileMaze, fileObjective, out Map map, out Objective objective);

                Maze maze = new Maze(map, objective);
                IEnumerable<Room> solution = maze.Solve();

                Console.WriteLine($"Final route is {string.Join(" > ", solution.Select(room => room.Id))}");
                Console.Read();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception}");
            }
        }

        private static void ParseInput(string fileMaze, string fileObjective, out Map map, out Objective objective)
        {
            Xml.Load(fileMaze, out map);
            Text.Load(fileObjective, out objective);
        }
    }
}
