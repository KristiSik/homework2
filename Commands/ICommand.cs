using System.Collections.Generic;

namespace ConsoleApplication1.Commands
{
    public interface ICommand
    {
        void Execute(ref Zoo logic);
    }
}
