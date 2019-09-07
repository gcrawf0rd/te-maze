using System.Collections.Generic;

namespace Maze.Model
{
    public class Objective
    {
        public Objective(IEnumerable<string> lines)
        {
            Objects = new HashSet<string>();
            Resolve(lines);
        }

        public int Start { get; private set; }
        public HashSet<string> Objects { get; }

        private void Resolve(IEnumerable<string> lines)
        {
            foreach (string line in lines)
            {
                if (int.TryParse(line, out int start))
                {
                    Start = start;
                    continue;
                }

                Objects.Add(line);
            }
        }
    }
}
