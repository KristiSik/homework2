using System.Collections.Generic;

namespace ConsoleApplication1.Commands
{
    public interface ICommand
    {
        void Execute(Dictionary<string, Animal> animaltypes, ref List<Animal> aliveanimals, ref List<Animal> deadanimals);
    }
}
