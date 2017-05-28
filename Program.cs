using ConsoleApplication1.Commands;
using System;
using System.Collections.Generic;
using System.Threading;


namespace ConsoleApplication1
{ 
    class Program
    {
        
        static void Main(string[] args)
        {
            Zoo logic = new Zoo();
            UserInterface menu = new UserInterface(ref logic);

            menu.setNewItem("1", new CreateAnimal());
            menu.setNewItem("2", new Select());
            menu.setNewItem("3", new FeedAnimal());
            menu.setNewItem("4", new HealAnimal());
            menu.setNewItem("5", new DeleteAnimal());
            menu.setNewItem("6", new MonitorZoo());

            menu.setNewTypeOfAnimal("1", new Bear());
            menu.setNewTypeOfAnimal("2", new Elephant());
            menu.setNewTypeOfAnimal("3", new Fox());
            menu.setNewTypeOfAnimal("4", new Lion());
            menu.setNewTypeOfAnimal("5", new Tiger());
            menu.setNewTypeOfAnimal("6", new Wolf());

            string command;
            do
            {
                menu.showMenu();
                Console.Write("Type command: ");
                command = Console.ReadLine();
                if (logic._commands.ContainsKey(command))
                {
                    menu.selectedItem(command);
                };
                if (!logic._commands.ContainsKey(command))
                {
                    Console.ReadKey();
                } 
                else
                if (!(logic._commands[command] is MonitorZoo))
                {
                    Console.ReadKey();
                }
                Console.Clear();
            } while (true);
        }
        
    }
}