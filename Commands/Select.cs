using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Commands
{
    public class Select : ICommand
    {
        public void Execute(ref Zoo logic)
        {
            Console.Clear();
            Console.WriteLine("1 - All animals, grouped by type\n"+
                             "2 - By state\n" +
                             "3 - All sick tigers\n" +
                             "4 - Elephant by name\n" +
                             "5 - All hungry animals\n" +
                             "6 - The healthiest animals from each type\n" +
                             "7 - Count of dead animals from each type\n" +
                             "8 - All wolfs and bears, who have health above 3\n" +
                             "9 - Animals with max and min health\n" +
                             "10 - Avarage health of all animals\n");
            Console.Write("Type command: ");
            string command = Console.ReadLine();
            IEnumerable<Animal> allAnimals = logic.aliveAnimals.Concat(logic.deadAnimals);
            switch (command)
            {
                case "1":
                    GroupedByType(allAnimals);
                    break;
                case "2":
                    ByState(allAnimals);
                    break;
                case "3":
                    AllSickTigers(allAnimals);
                    break;
                case "4":
                    ElephantByName(allAnimals);
                    break;
                case "5":
                    AllHungryAnimals(allAnimals);
                    break;
                case "6":
                    MaxHealthFromEachType(allAnimals);
                    break;
                case "7":
                    CountOfDeadAnimalsFromEachType(allAnimals);
                    break;
                case "8":
                    WolfsAndBearsWithHealthAbove3(allAnimals);
                    break;
                case "9":
                    AnimalsWithMaxAndMinHealth(allAnimals);
                    break;
                case "10":
                    AverageHealth(allAnimals);
                    break;
            }
        }
        public override string ToString()
        {
            return "Select animals";
        }
        void GroupedByType(IEnumerable<Animal> allAnimals)
        {
            var select = allAnimals.GroupBy(t => t.ToString()).Select(a => new { Name = a.Key, Animals = a.Select(s => s) });
            foreach (var item in select)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(item.Name);
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (var animal in item.Animals)
                {
                    Console.WriteLine("\t{0}", animal.Name);
                }
                Console.WriteLine();
            }
        }
        void ByState(IEnumerable<Animal> allAnimals)
        {
            bool parse;
            int choose;
            do
            {
                Console.WriteLine("Enter state of animal:");
                foreach (var state in Enum.GetValues(typeof(State)))
                {
                    Console.WriteLine("{0} - {1}", (int)state, state);
                }
                parse = Int32.TryParse(Console.ReadLine(), out choose);
            } while (!parse);
            var select = allAnimals.Where(s => (s.State == (State)choose));
            Console.WriteLine("{0} animals:", (State) choose);
            foreach (var item in select)
            {
                Console.WriteLine(item.Name);
            }
        }
        void AllSickTigers(IEnumerable<Animal> allAnimals)
        {
            var select = allAnimals.Where(a => (a is Tiger) && a.State == State.Sick);
            foreach (var item in select)
            {
                Console.WriteLine(item.Name);
            }
        }
        void ElephantByName(IEnumerable<Animal> allAnimals)
        {
            Console.Write("Enter name of elephant: ");
            string name = Console.ReadLine();
            var select = allAnimals.Where(a => (a is Elephant) && a.Name == name);
            if (select.Count() == 0)
            {
                Console.WriteLine("Elephant not found");
            }
            else
            {
                Console.WriteLine("{0} has {1} health(s) and is {2}", select.ElementAt(0).Name, select.ElementAt(0).Health, select.ElementAt(0).State);
            }
        }
        void AllHungryAnimals(IEnumerable<Animal> allAnimals)
        {
            var select = allAnimals.Where(s => s.State == State.Hungry);
            Console.WriteLine("All hungry animals:");
            foreach (var animal in select)
            {
                Console.WriteLine(animal.Name);
            }
        }
        void MaxHealthFromEachType(IEnumerable<Animal> allAnimals)
        {
            var select = allAnimals.GroupBy(x => x.ToString());
            foreach(var group in select)
            {
                var animal = group.Where(y => y.Health > 0).OrderBy(x => x.Health).First();
                Console.WriteLine("{0} {1} has {2} health", animal, animal.Name, animal.Health);
            }
        }
        void CountOfDeadAnimalsFromEachType(IEnumerable<Animal> allAnimals)
        {
            var select = allAnimals.Where(a => a.State == State.Dead).GroupBy(t => t.ToString());
            if (select.Count() == 0)
            {
                Console.WriteLine("There is no dead animals");
            }
            else
            {
                foreach (var type in select)
                {
                    Console.WriteLine("{0} {1}(s) are dead", type.Count(), type.Key);
                }
                Console.WriteLine("Animals of other types are alive or not created");
            }
        }
        void WolfsAndBearsWithHealthAbove3(IEnumerable<Animal> allAnimals)
        {
            var select = allAnimals.Where(x => x is Wolf || x is Bear);
            foreach(var animal in select)
            {
                Console.WriteLine("{0} {1} has {2} health(s)", animal, animal.Name, animal.Health);
            }
        }
        void AnimalsWithMaxAndMinHealth(IEnumerable<Animal> allAnimals)
        {
            var select = new { Min = allAnimals.OrderBy(x => x.Health).First(), Max = allAnimals.OrderBy(y => y.Health).Last()};
            Console.WriteLine("{0} {1} has max health - {2}", select.Max, select.Max.Name, select.Max.Health);
            Console.WriteLine("{0} {1} has min health - {2}", select.Min, select.Min.Name, select.Min.Health);
            
            //Another way:

            //var select = allAnimals.Where(x => x.Health == allAnimals.OrderBy(y => y.Health).First().Health).Select(z => new { Animal = z, Pos = "min" }).Concat(allAnimals.Where(x => x.Health == allAnimals.OrderBy(y => y.Health).Last().Health).Select(z => new { Animal = z, Pos = "max" }));
            //foreach(var item in select)
            //{
            //    Console.WriteLine("{0} {1} has {2} health - {3}", item.Animal, item.Animal.Name, item.Pos, item.Animal.Health);
            //}
        }
        void AverageHealth(IEnumerable<Animal> allAnimals)
        {
            var select = allAnimals.Sum(x => x.Health);
            Console.WriteLine("Average health in Zoo = {0:0.0}", (double) select / allAnimals.Count());
        }
    }
}
