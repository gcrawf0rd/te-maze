using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Maze.Model
{
    [XmlRoot("Map")]
    public class Map
    {
        [XmlElement("Room")]
        public List<Room> Rooms { get; set; }

        public HashSet<string> AllObjects()
        {
            HashSet<string> objects = new HashSet<string>();

            foreach (Room room in Rooms)
            {
                foreach (Object @object in room.Objects)
                    objects.Add(@object.Name);
            }

            return objects;
        }

        public Room GetById(int id) => Rooms.First(room => room.Id == id);
    }
}
