using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApplication1.Commands
{
    public class MonitorZoo : ICommand
    {
        private bool stopmonitoring;
        public void Execute(ref Zoo logic)
        {
            stopmonitoring = false;
            Thread keyRead = new Thread(keyPressListener);
            keyRead.Start();
            do
            {
                Console.Clear();
                if (stopmonitoring)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0, -20}{1, -20}{2, -20}{3}", "Name", "Type", "State", "Health");
                foreach (Animal animal in logic.aliveAnimals)
                {
                    if (animal.State == State.Sick)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    if(animal.State == State.Satisfied)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    if (animal.State == State.Hungry)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.WriteLine("{0, -20}{1, -20}{2, -20}{3}", animal.Name, animal.ToString(), animal.State, animal.Health);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (Animal animal in logic.deadAnimals)
                {
                    Console.WriteLine("{0, -20}{1, -20}{2, -20}{3}", animal.Name, animal.ToString(), animal.State, animal.Health);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0, 67}", DateTimeOffset.Now.ToString("T"));
                Console.WriteLine("(press any key to back)");
                System.Threading.Thread.Sleep(1000);
            } while (logic.aliveAnimals.Count > 0);
        }
        private void keyPressListener()
        {
            Console.ReadKey();
            stopmonitoring = true;
        }
        public override string ToString()
        {
            return "Monitor of Zoo";
        }
    }
}
