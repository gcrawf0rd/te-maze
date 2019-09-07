using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Maze.Model
{
    public class Room
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("North")]
        public int North { get; set; }
        [XmlAttribute("East")]
        public int East { get; set; }
        [XmlAttribute("South")]
        public int South { get; set; }
        [XmlAttribute("West")]
        public int West { get; set; }
        [XmlElement("Object")]
        public List<Object> Objects { get; set; }

        public IEnumerable<int> UndiscoveredRooms(Tree<Room> parent) => new[] { North, East, South, West }.Where(direction => direction != default && direction != parent?.Item?.Id);
        public bool HasObject(HashSet<string> objects) => Objects.Any(obj => objects.Contains(obj.Name));
    }
}
