using System;
using System.Runtime.Serialization;

namespace TestEx3
{
    public abstract class TestBase
    {
        public ObjectIDGenerator TcId { get; }

        public string Name { get; set; }

        public virtual void Prep()
        {
        }

        public abstract void Run();

        public virtual void Clean_Up()
        {
        }

        public void Execute()
        {
            Console.WriteLine("Выполняется метод Prep");
            Prep();
            Console.WriteLine("Выполняется метод Run");
            Run();
            Console.WriteLine("Выполняется метод Clean_up");
            Clean_Up();
        }
    }
}