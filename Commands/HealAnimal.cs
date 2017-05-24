using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Commands
{
    public class HealAnimal : ICommand
    {
        public void Execute(Dictionary<string, Animal> animaltypes, ref List<Animal> aliveanimals, ref List<Animal> deadanimals)
        {
            Console.Write("Enter name of animal to heal: ");
            string name = Console.ReadLine();
            foreach (Animal animal in aliveanimals)
            {
                if (animal.Name == name)
                {
                    animal.Heal();
                    name = "";
                    break;
                }
            }
            if (name != "")
            {
                Console.WriteLine("Animal not found.");
            } else
            {
                Console.WriteLine("Animal successfully healed.");
            }
        }
        public override string ToString()
        {
            return "Heal animal";
        }
    }
}
