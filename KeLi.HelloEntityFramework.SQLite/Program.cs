using System;

using KeLi.HelloEntityFramework.SQLite.DataModels;
using KeLi.HelloEntityFramework.SQLite.Utils;

namespace KeLi.HelloEntityFramework.SQLite
{
    internal class Program
    {
        private static void Main()
        {
            // Add data.
            {
                DbUtil.Insert(new Student { Name = "Tom" });
                DbUtil.Insert(new Student { Name = "Jack" });
                DbUtil.Insert(new Student { Name = "Tony" });

                Console.WriteLine("After Added data:");

                foreach (var item in DbUtil.QueryList<Student>())
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            // Delete data.
            {
                DbUtil.Delete<Student>(d => d.Name.Contains("Tom"));

                Console.WriteLine("After Deleted data:");

                foreach (var item in DbUtil.QueryList<Student>())
                    Console.WriteLine(item.Name);
            }

            // Update data.
            {
                DbUtil.Update<Student>(s => s.Name = "Alice", u => u.Name.Contains("Jack"));

                Console.WriteLine("After Updated data:");

                foreach (var item in DbUtil.QueryList<Student>())
                    Console.WriteLine(item.Name);
            }

            // Query data.
            {
                var students = DbUtil.QueryList<Student>(q => q.Name.Contains("T"));

                Console.WriteLine("Query data:");

                foreach (var item in students)
                    Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}