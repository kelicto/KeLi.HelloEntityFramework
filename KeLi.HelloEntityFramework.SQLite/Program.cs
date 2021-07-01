using System;

using KeLi.HelloEntityFramework.SQLite.Models;
using KeLi.HelloEntityFramework.SQLite.Properties;
using KeLi.HelloEntityFramework.SQLite.Utils;

namespace KeLi.HelloEntityFramework.SQLite
{
    internal class Program
    {
        private static void Main()
        {
            var helper = new ContextHelper(Resources.ConnectionString);

            // Add data.
            {
                helper.Insert(new Student { Name = "Tom" });
                helper.Insert(new Student { Name = "Jack" });
                helper.Insert(new Student { Name = "Tony" });

                Console.WriteLine("After Added data:");

                foreach (var item in helper.QueryList<Student>())
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            // Delete data.
            {
                helper.Delete<Student>(d => d.Name.Contains("Tom"));

                Console.WriteLine("After Deleted data:");

                foreach (var item in helper.QueryList<Student>())
                    Console.WriteLine(item.Name);
            }

            // Update data.
            {
                helper.Update<Student>(s => s.Name = "Alice", u => u.Name.Contains("Jack"));

                Console.WriteLine("After Updated data:");

                foreach (var item in helper.QueryList<Student>())
                    Console.WriteLine(item.Name);
            }

            // Query data.
            {
                var students = helper.QueryList<Student>(q => q.Name.Contains("T"));

                Console.WriteLine("Query data:");

                foreach (var item in students)
                    Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}