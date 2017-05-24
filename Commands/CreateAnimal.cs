using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Commands
{
    public class CreateAnimal : ICommand
    {
        public void Execute(Dictionary<string, Animal> animaltypes, ref List<Animal> aliveanimals, ref List<Animal> deadanimals)
        {
            Console.WriteLine("Enter type of new animal: ");
            foreach(var type in animaltypes)
            {
                Console.WriteLine(type.Key + " - " + type.Value);
            }
            string typeOfAnimal;
            do
            {
                typeOfAnimal = Console.ReadLine();
            } while (!(animaltypes.ContainsKey(typeOfAnimal)));
            string name;
            bool nameInUse;
            do
            {
                Console.Write("Enter name of new animal: ");
                name = Console.ReadLine();
                nameInUse = false;
                foreach (Animal animal in aliveanimals)
                {
                    if (animal.Name == name)
                    {
                        Console.WriteLine("Name is already in use.");
                        nameInUse = true;
                        break;
                    }
                }
                if (!nameInUse)
                {
                    foreach (Animal animal in deadanimals)
                    {
                        if (animal.Name == name)
                        {
                            Console.WriteLine("Name is already in use.");
                            nameInUse = true;
                            break;
                        }
                    }
                }
            } while (nameInUse);

            object newanimal = Activator.CreateInstance(animaltypes[typeOfAnimal].GetType(), name);
            aliveanimals.Add((Animal) newanimal);
        }
        public override string ToString()
        {
            return "Create new animal";
        }
    }
}
