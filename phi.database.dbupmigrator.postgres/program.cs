using DbUp;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Phi.Database.DbUpMigrator.Postgres
{
    public static class Program
    {
        static int Main(string[] args)
        {
            var connectionString =
                args.FirstOrDefault()
                ?? "Host=localhost;User Id=postgres;Password=Secret!Passw0rd;Database=PhiDatabase;Port=5432";
            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
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