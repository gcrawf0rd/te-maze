using System;
using System.IO;
using Maze.Model;

namespace Maze.Parse
{
    public static class Text
    {
        public static void Load(string path, out Objective objective)
        {
            try
            {
                objective = new Objective(File.ReadLines(path));
            }
            catch (Exception exception)
            {
                objective = default;
                Console.WriteLine($"Error: {exception}");
            }
        }
    }
}
