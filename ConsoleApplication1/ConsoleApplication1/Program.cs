using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using Ninject;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var c = new Container();
            c.Register<ILogger, Logger>(Reuse.Singleton);
            c.Register<IDatabase, Database>();
           
            IDatabase db = c.Resolve<Database>();*/

            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IDatabase>().To<Database>().InTransientScope();
            ninjectKernel.Bind<ILogger>().To<Logger>().InSingletonScope();
            IDatabase db = ninjectKernel.Get<IDatabase>();

            db.Execute("select * from users where id_user = 77");
            Console.ReadLine();

        }
    }
}
