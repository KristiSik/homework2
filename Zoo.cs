using ConsoleApplication1.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Zoo
    {
        TimerCallback timeProcess;

        public Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
        public Dictionary<string, Animal> _animaltypes = new Dictionary<string, Animal>();

        public List<Animal> aliveAnimals;
        public List<Animal> deadAnimals;
        public static Random randomAnimal = new Random();
        public UserInterface menu;
        public static int r;

        public Zoo()
        {
            deadAnimals = new List<Animal>();
            aliveAnimals = new List<Animal>();
            timeProcess = new TimerCallback(Process);
            Timer time = new Timer(timeProcess, null, 0, 5000);
        }
        void Process(object state)
        {
            if (deadAnimals.Count != 0 && aliveAnimals.Count == 0)
            {
                Console.Write("\nAll the animals are dead.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            if (aliveAnimals.Count == 0 && deadAnimals.Count == 0)
            {
                return;
            }

            r = randomAnimal.Next(0, aliveAnimals.Count);
            aliveAnimals[r].WorsenState();

            if (aliveAnimals[r].State == State.Dead)
            {
                deadAnimals.Add(aliveAnimals[r]);
                aliveAnimals.RemoveAt(r);
            }
        }
    }
}
