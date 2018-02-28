using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    /*IDatabase (transient в терминологии Dryioc - который создается на каждый запрос) 
    и методом например Execute(string query) который будет писать этот запрос в полученный от Resolver
    реализацию ILogger.
     
     3) Через resolver получить экземпляр класса IDatabase и вызвать у него метод Execute 
     * с передачей в него какого-нибудь запроса*/
    interface IDatabase
    {
        void Execute(string query);
        ILogger getLogger();
    }
}
