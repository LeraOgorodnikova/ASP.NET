using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Logger: ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm ") + message);
        }
    }
}
