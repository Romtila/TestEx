using System.Xml.Serialization;

namespace TestEx
{
    [XmlRoot(ElementName = "file")]
    public class MyFile
    {
        [XmlAttribute(AttributeName = "source_path")]
        public string SourcePath { get; set; }

        [XmlAttribute(AttributeName = "destination_path")]
        public string DestinationPath { get; set; }

        [XmlAttribute(AttributeName = "file_name")]
        public string FileName { get; set; }
    }
}