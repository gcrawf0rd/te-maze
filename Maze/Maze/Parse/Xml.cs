using System;
using System.IO;
using System.Xml.Serialization;

namespace Maze.Parse
{
    public static class Xml
    {
        public static void Load<T>(string path, out T obj)
        {
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    obj = (T)new XmlSerializer(typeof(T)).Deserialize(stream);
                }
            }
            catch (Exception exception)
            {
                obj = default;
                Console.WriteLine($"Error: {exception}");
                Console.Read();
            }
        }
    }
}
