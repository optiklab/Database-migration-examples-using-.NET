using DbUp;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Phi.Database
{
    public static class Program
    {
        static int Main(string[] args)
        {
            var connectionString =
                args.FirstOrDefault()
                ?? "Server=ANTONPC; Database=Phi; Integrated Security=SSPI;"; 
                //"Server=NEMO17\\SQLEXPRESS2019; Database=Phi; Integrated Security=SSPI;"; 
                //"Server=(local)\\SqlExpress; Database=Phi; Trusted_connection=true";
                
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}