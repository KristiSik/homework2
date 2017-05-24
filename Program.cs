using ConsoleApplication1.Commands;
using System;
using System.Collections.Generic;
using System.Threading;


namespace ConsoleApplication1
{ 
    class Program
    {
        private static List<Animal> aliveAnimals;
        private static List<Animal> deadAnimals;
        private static Random randomAnimal = new Random();
        private static int r;
        static void Main(string[] args)
        {
            Thread myThread = new Thread(Process);
            myThread.Start();

            string command;
            deadAnimals = new List<Animal>();
            aliveAnimals = new List<Animal>();

            UserInterface menu = new UserInterface();

            menu.setNewItem("1", new CreateAnimal());
            menu.setNewItem("2", new FeedAnimal());
            menu.setNewItem("3", new HealAnimal());
            menu.setNewItem("4", new DeleteAnimal());
            menu.setNewItem("5", new MonitorZoo());

            menu.setNewTypeOfAnimal("1", new Bear());
            menu.setNewTypeOfAnimal("2", new Elephant());
            menu.setNewTypeOfAnimal("3", new Fox());
            menu.setNewTypeOfAnimal("4", new Tiger());
            menu.setNewTypeOfAnimal("5", new Wolf());

            do
            {
                menu.showMenu();
                Console.Write("Type command: ");
                command = Console.ReadLine();
                menu.selectedItem(command, ref aliveAnimals, ref deadAnimals);
                Console.ReadKey();
                Console.Clear();
            } while (true);

        }
        static void Process()
        {
            do
            {
                Thread.Sleep(5000);

                if (deadAnimals.Count != 0 && aliveAnimals.Count == 0)
                {
                    Console.Write("\nAll the animals are dead.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                if (aliveAnimals.Count == 0 && deadAnimals.Count == 0)
                {
                    continue;
                }

                r = randomAnimal.Next(0, aliveAnimals.Count);
                aliveAnimals[r].WorsenState();

                if (aliveAnimals[r].State == State.Dead)
                {
                    deadAnimals.Add(aliveAnimals[r]);
                    aliveAnimals.RemoveAt(r);
                }
            } while (true);
        }
    }
}