using System;
using System.Collections.Generic;
using System.Text;
using SampleTask.Vending.Service.Contract;

namespace SampleTask.Vending.Service.Implementation
{
    public class MachineConsoleInputService : IMachineInputService
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
