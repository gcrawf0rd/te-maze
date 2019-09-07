using System.Collections.Generic;

namespace Maze.Model
{
    public class Tree<T> where T : Room
    {
        public Tree(T item)
        {
            Item = item;
            Children = new List<Tree<T>>();
        }

        private Tree(T item, Tree<T> parent)
            : this(item)
        {
            Parent = parent;
        }

        public T Item { get; }
        public Tree<T> Parent { get; }
        public List<Tree<T>> Children { get; }

        private Tree<T> Add(T item, Tree<T> parent)
        {
            Tree<T> tree = new Tree<T>(item, parent);
            Children.Add(tree);

            return tree;
        }

        public static void Populate(Tree<Room> tree, Map map)
        {
            foreach (int roomId in tree.Item.UndiscoveredRooms(tree.Parent))
            {
                Tree<Room> childTree = tree.Add(map.GetById(roomId), tree);
                Populate(childTree, map);
            }
        }
    }
}
