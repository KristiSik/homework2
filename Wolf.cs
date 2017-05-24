using System;

namespace ConsoleApplication1
{
    public class Wolf : Animal
    {
        public Wolf()
        {
        }

        public Wolf(string name)
        {
            StartHealth = _health = 4;
            _name = name;
            Console.WriteLine("Created new Wolf " + name);
        }
        public override string ToString()
        {
            return "wolf";
        }
    }
}
