using System;

namespace ConsoleApplication1
{
    public class Elephant : Animal
    {
        public Elephant()
        {
        }

        public Elephant(string name)
        {
            StartHealth = _health = 7;
            _name = name;
            Console.WriteLine("Created new Elephant " + _name);
        }
        public override string ToString()
        {
            return "elephant";
        }
    }
}
