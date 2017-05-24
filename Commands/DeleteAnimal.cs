using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Commands
{
    public class DeleteAnimal : ICommand
    {
        public void Execute(Dictionary<string, Animal> animaltypes, ref List<Animal> aliveanimals, ref List<Animal> deadanimals)
        {
            Console.Write("Enter name of animal to delete: ");
            string name = Console.ReadLine();
            foreach (Animal animal in deadanimals)
            {
                if (animal.Name == name)
                {
                    deadanimals.Remove(animal);
                    name = "";
                    break;
                }
            }
            if (name != "")
            {
                Console.WriteLine("Animal not found.");
            } else
            {
                Console.WriteLine("Animal successfully deleted.");
            }
        }
        public override string ToString()
        {
            return "Delete animal";
        }
    }
}
