﻿using System;

namespace ConsoleApplication1
{
    public class Lion : Animal
    {
        public Lion(string name)
        {
            StartHealth = _health = 5;
            _name = name;
            Console.WriteLine("Created new Lion " + name);
        }

        public Lion()
        {
            // TODO: Complete member initialization
        }
        public override string ToString()
        {
            return "lion";
        }
    }
}
