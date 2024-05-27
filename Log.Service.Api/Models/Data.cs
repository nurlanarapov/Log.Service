using System.Xml.Serialization;

namespace Log.Service.Api.Models
{
    [XmlRoot("Data")]
    public class Data
    {
        [XmlElement("Method")]
        public Method Method { get; set; }

        [XmlElement("Process")]
        public Process Process { get; set; }

        [XmlElement("Layer")]
        public string Layer { get; set; }

        [XmlElement("Creation")]
        public Creation Creation { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }
    }

    public class Method
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlElement("Assembly")]
        public string Assembly { get; set; }
    }

    public class Process
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Start")]
        public Start Start { get; set; }
    }

    public class Start
    {
        [XmlElement("Epoch")]
        public long Epoch { get; set; }

        [XmlElement("Date")]
        public DateTime Date { get; set; }
    }

    public class Creation
    {
        [XmlElement("Epoch")]
        public long Epoch { get; set; }

        [XmlElement("Date")]
        public DateTime Date { get; set; }
    }
}
