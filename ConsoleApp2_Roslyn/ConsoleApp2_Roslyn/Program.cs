using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace ConsoleApp2_Roslyn
{
    public class Variable : MarshalByRefObject
    {
        public double x;
        public double y;
    }

    class Calculator : MarshalByRefObject
    {
        public double Calc(string expression, Variable variables)
        {
            return CSharpScript.EvaluateAsync<double>(expression, ScriptOptions.Default.WithImports("System.Math"),
               globals: variables).Result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*SyntaxTree tree = CSharpSyntaxTree.ParseText(@"
            using System;
            using Microsoft.CodeAnalysis.CSharp.Scripting;

            public class Calculator {
                public int Calc(string exp){
                    return CSharpScript.EvaluateAsync<double>(exp).Result;
                }
            }
            ");*/

            AppDomain domain = AppDomain.CreateDomain("DomainCalculator");
            domain.Load(Assembly.GetExecutingAssembly().GetName());

            Calculator calculator = (Calculator)domain.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName, "ConsoleApp2_Roslyn.Calculator");
            Variable variables = (Variable)domain.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName, "ConsoleApp2_Roslyn.Variable");

            double x = 0, y = 0;
            Console.WriteLine("Введите выражение: ");
            string exp = Console.ReadLine();
            Console.WriteLine("Введите значение х: ");
            Double.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Введите значение y: ");
            Double.TryParse(Console.ReadLine(), out y);
            variables.x = x;
            variables.y = y;
            Console.WriteLine(calculator.Calc(exp, variables));
            Console.ReadKey();

            /*var compilation = CSharpCompilation.Create("Calculator", new[] { tree },
               new[] {
                   MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
               },
               new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

           var stm = new MemoryStream();
           EmitResult result = compilation.Emit(stm);
           if (!result.Success)
           {
               foreach (Diagnostic item in result.Diagnostics)
                   Console.Error.WriteLine("{0}: {1}", item.Id, item.GetMessage());
               return;
           }

           stm.Seek(0, SeekOrigin.Begin);
           Assembly assembly = Assembly.Load(stm.ToArray());
           Type type = assembly.GetType("Calculator");
           ConstructorInfo ci = type.GetConstructors()[0];
           var instance = ci.Invoke(null);

           MethodInfo miCalc = type.GetMethod("Calc");
           ParameterInfo[] pim =  miCalc.GetParameters();
           miCalc.Invoke(instance, new Object[] {"14+20" });

           var d = (CalcDelegate)miCalc.CreateDelegate(typeof(CalcDelegate), instance);
           int res = d("14+20");
           Console.WriteLine(res);*/
        }

        //delegate int CalcDelegate(string exp);
    }
}
