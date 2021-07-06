using System;
using System.IO;
using System.Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEx3
{
    public class TestKeys2 : TestBase
    {
        public override void Prep()
        {
            var ramMonitor = new ManagementObjectSearcher("SELECT TotalPhysicalMemorySize FROM Win32_OperatingSystem");
            ulong ram = 0;

            foreach (var objram in ramMonitor.Get())
            {
                ram = Convert.ToUInt64(objram["TotalPhysicalMemorySize"]);
            }

            var ramGb = ram / 1048576;

            Assert.IsTrue(ram >= 1048576,"Объем оперативной памяти вашего компьютера меньше 1Гб");
        }
        public override void Run()
        {
            var buffer = new byte[1048576]; //1024кб
            new Random().NextBytes(buffer);
            var text = System.Text.Encoding.Default.GetString(buffer);
            File.WriteAllText("test.txt", text);
        }
        public override void Clean_Up()
        {
            File.Delete("test.txt");
        }
    }
}