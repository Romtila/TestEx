using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestEx
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Укажите путь к конфигурационному файлу:");

            var config = Console.ReadLine();

            var listFiles = new List<MyFile>();

            var serializer = new XmlSerializer(typeof(List<MyFile>));

            using (var stream = File.OpenRead(config))
            {
                listFiles = (List<MyFile>)serializer.Deserialize(stream);
            }

            foreach (var fileElement in listFiles)
            {
                CopingFileInfo(
                    fileElement.SourcePath,
                    fileElement.DestinationPath,
                    fileElement.FileName
                );
            }

            Console.WriteLine("Ваши файлы скопированы.");
            Console.Read();
        }

        private static void CopingFileInfo(String sp, String dp, String fn)
        {
            var fi = new FileInfo(Path.Combine(sp, fn));

            if (fi.Exists)
            {
                fi.CopyTo(dp, true);
            }
        }
    }
}

