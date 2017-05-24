using ConsoleApplication1.Commands;
using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class UserInterface
    {
        private Dictionary<string, ICommand> _commands;
        private Dictionary<string, Animal> _animaltypes;
        public UserInterface()
        {
            _commands = new Dictionary<string, ICommand>();
            _animaltypes = new Dictionary<string, Animal>();
        }
        public void showMenu()
        {
            foreach(var command in _commands)
            {
                Console.WriteLine(command.Key + " - " + command.Value);
            }
        }
        public void selectedItem(string key, ref List<Animal> aliveAnimals, ref List<Animal> deadAnimals)
        {
            if (_commands.ContainsKey(key))
            {
                _commands[key].Execute(_animaltypes, ref aliveAnimals, ref deadAnimals);
            }
        }
        public void setNewItem(string key, ICommand command)
        {
            _commands.Add(key, command);
        }
        public void setNewTypeOfAnimal(string key, Animal _animaltype)
        {
            _animaltypes.Add(key, _animaltype);
        }
    }
}
