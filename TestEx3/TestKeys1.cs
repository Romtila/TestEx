using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEx3
{
    public class TestKeys1 : TestBase
    {
        public override void Prep()
        {
            var actual = (int) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds % 2;
            Assert.AreEqual(0, actual);
        }

        public override void Run()
        {
            Console.WriteLine("В домашней директории содержатся файлы:");

            foreach (var file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)))
            {
                Console.WriteLine(file);
            }
        }
    }
}