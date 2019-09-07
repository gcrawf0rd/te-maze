using System.Xml.Serialization;

namespace Maze.Model
{
    public class Object
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
