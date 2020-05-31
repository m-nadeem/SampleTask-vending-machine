using System;
using System.Collections.Generic;
using System.Text;
using SampleTask.Vending.Service.Contract;

namespace SampleTask.Vending.Service.Implementation
{
    public class ConsoleLogger :ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}
