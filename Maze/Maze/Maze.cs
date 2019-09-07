using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Model;

namespace Maze
{
    public class Maze
    {
        public Maze(Map map, Objective objective)
        {
            Map = map;
            Objective = objective;
        }

        private Map Map { get; }
        private Objective Objective { get; }

        public IEnumerable<Room> Solve()
        {
            Stack<Room> result = new Stack<Room>();

            Tree<Room> tree = new Tree<Room>(Map.GetById(Objective.Start));
            Tree<Room>.Populate(tree, Map);

            IterateChildren(tree, ref result, Objective.Objects);

            return result.Reverse();
        }

        private static void IterateChildren(Tree<Room> tree, ref Stack<Room> result, HashSet<string> objects)
        {
            result.Push(tree.Item);

            foreach (Tree<Room> child in tree.Children)
                IterateChildren(child, ref result, objects);

            bool roomTopOfStack = result.Peek().Id == tree.Item.Id;

            if (!tree.Item.HasObject(objects))
            {
                if (roomTopOfStack)
                {
                    result.Pop();
                    return;
                }
            }
            else
            {
                foreach (Model.Object @object in tree.Item.Objects)
                {
                    Console.WriteLine($"Found {@object.Name} at {tree.Item.Id}");
                    objects.Remove(@object.Name);
                }
            }

            if (roomTopOfStack)
                result.Push(tree.Parent.Item);
        }
    }
}
