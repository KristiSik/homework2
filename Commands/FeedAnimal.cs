using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Commands
{
    public class FeedAnimal : ICommand
    {
        public void Execute(ref Zoo logic)
        {
            Console.Write("Enter name of animal to feed: ");
            string name = Console.ReadLine();
            foreach (Animal animal in logic.aliveAnimals)
            {
                if (animal.Name == name)
                {
                    animal.Feed();
                    name = "";
                    break;
                }
            }
            if (name != "")
            {
                Console.WriteLine("Animal not found.");
            } else
            {
                Console.WriteLine("Animal successfully fed.");
            }
        }
        public override string ToString()
        {
            return "Feed animal";
        }
    }
}
