using ConsoleApplication1.Commands;
using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class UserInterface
    {
        private Zoo logic = new Zoo();
        public UserInterface(ref Zoo logic)
        {
            this.logic = logic;
        }
        public void showMenu()
        {
            foreach(var command in logic._commands)
            {
                Console.WriteLine(command.Key + " - " + command.Value);
            }
        }
        public void selectedItem(string key)
        {
            if (logic._commands.ContainsKey(key))
            {
                logic._commands[key].Execute(ref logic);
            }
        }
        public void setNewItem(string key, ICommand command)
        {
            logic._commands.Add(key, command);
        }
        public void setNewTypeOfAnimal(string key, Animal _animaltype)
        {
            logic._animaltypes.Add(key, _animaltype);
        }
    }
}
