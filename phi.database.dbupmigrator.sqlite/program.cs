using DbUp;
using DbUp.SQLite;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Phi.Database.DbUpMigrator.Sqlite
{
    public static class Program
    {
        static int Main(string[] args)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            string dbPath = System.IO.Path.Join(path, "phi.db");
            var connectionString =
                args.FirstOrDefault()
                ?? string.Format("Data Source={0};", dbPath); 

            var upgrader =
                DeployChanges.To
                    .SQLiteDatabase(connectionString)
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