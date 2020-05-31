using System;
using System.Collections.Generic;
using System.Text;

namespace SampleTask.Vending.Service.Contract
{
    public interface ILogger
    {
        void WriteLog(string message);
    }
}
