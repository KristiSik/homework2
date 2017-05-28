using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Commands
{
    public class CreateAnimal : ICommand
    {
        public void Execute(ref Zoo logic)
        {
            Console.WriteLine("Enter type of new animal: ");
            foreach (var type in logic._animaltypes)
            {
                Console.WriteLine(type.Key + " - " + type.Value);
            }
            string typeOfAnimal;
            do
            {
                typeOfAnimal = Console.ReadLine();
            } while (!(logic._animaltypes.ContainsKey(typeOfAnimal)));
            string name;
            bool nameInUse;
            do
            {
                Console.Write("Enter name of new animal: ");
                name = Console.ReadLine();
                nameInUse = false;
                foreach (Animal animal in logic.aliveAnimals)
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
                    foreach (Animal animal in logic.deadAnimals)
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

            object newanimal = Activator.CreateInstance(logic._animaltypes[typeOfAnimal].GetType(), name);
            logic.aliveAnimals.Add((Animal)newanimal);
        }
        public override string ToString()
        {
            return "Create new animal";
        }
    }
}
