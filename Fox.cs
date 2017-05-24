using System;

namespace ConsoleApplication1
{
    public class Fox : Animal
    {
        public Fox()
        {
        }

        public Fox(string name)
        {
            StartHealth = _health = 3;
            _name = name;
            Console.WriteLine("Created new Fox " + name);
        }
        public override string ToString()
        {
            return "fox";
        }
    }
}
