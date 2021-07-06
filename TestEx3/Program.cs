using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEx3
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = typeof(TestBase).Assembly.GetTypes().Where(x => typeof(TestBase).IsAssignableFrom(x) && !x.IsAbstract);

            foreach (var elemType in list)
            {
                var element = (TestBase)Activator.CreateInstance(elemType);
                element.Execute();
            }

            Console.ReadLine();
        }
    }
}
