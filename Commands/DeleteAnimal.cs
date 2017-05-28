using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Commands
{
    public class DeleteAnimal : ICommand
    {
        public void Execute(ref Zoo logic)
        {
            Console.Write("Enter name of animal to delete: ");
            string name = Console.ReadLine();
            foreach (Animal animal in logic.deadAnimals)
            {
                if (animal.Name == name)
                {
                    logic.deadAnimals.Remove(animal);
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
