using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Composition;
using WebApplication2;

namespace ConsoleApplication1
{
    [Export(typeof(ILogger))]
    public class Logger: ILogger
    {
        public void Write(string message)
        {
            try
            {
                string path = @"%TEMP%\test.log";
                if (!File.Exists(path)) { 
                    File.Create(path); 
                }
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm ") + message);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
