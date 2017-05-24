using System;

namespace ConsoleApplication1
{
    public class Bear : Animal
    {
        public Bear()
        {

        }
        public Bear(string name)
        {
            StartHealth = _health = 6;
            _name = name;
            Console.WriteLine("Created new Bear " + _name);
        }
        public override string ToString()
        {
            return "bear";
        }
    }
}
