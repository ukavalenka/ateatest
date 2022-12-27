using ATEATECHNICAL.Utils.Interfaces;
using System;

namespace ATEATECHNICAL.Utils
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
