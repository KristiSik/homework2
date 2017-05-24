using System;

namespace ConsoleApplication1
{
    public class Tiger : Animal
    {
        public Tiger()
        {
        }

        public Tiger(string name)
        {
            StartHealth = _health = 4;
            _name = name;
            Console.WriteLine("Created new Tiger " + name);
        }
        public override string ToString()
        {
            return "tiger";
        }
    }
}
