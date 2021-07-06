using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestEx
{
    [XmlRoot(ElementName = "config")]
    public class Config
    {

        [XmlElement(ElementName = "file")]
        public List<MyFile> File { get; set; }
    }
}