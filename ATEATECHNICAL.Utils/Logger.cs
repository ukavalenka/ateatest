using ATEATECHNICAL.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATEATECHNICAL.Utils
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
