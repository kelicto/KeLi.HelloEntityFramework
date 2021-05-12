using System;
using System.Linq;

using KeLi.HelloSqlLite.App.Entities;

namespace KeLi.HelloSqlLite.App
{
    internal class Program
    {
        private static void Main()
        {
            using (var context = new AppDBContext())
            {
                // Add data.
                {
                    context.StudentSet.Add(new Student { Name = "Tom" });
                    context.StudentSet.Add(new Student { Name = "Jack" });
                    context.StudentSet.Add(new Student { Name = "Tony" });
                    context.SaveChanges();

                    Console.WriteLine("After Added data:");

                    foreach (var item in context.StudentSet.ToList())
                        Console.WriteLine(item.Name);
                }

                Console.WriteLine();

                // Delete data.
                {
                    var student = context.StudentSet.FirstOrDefault(f => f.Name.Contains("Tom"));

                    context.StudentSet.Remove(student);
                    context.SaveChanges();

                    Console.WriteLine("After Deleted data:");

                    foreach (var item in context.StudentSet.ToList())
                        Console.WriteLine(item.Name);
                }

                Console.WriteLine();

                // Update data.
                {
                    var student = context.StudentSet.FirstOrDefault(w => w.Name.Contains("Jack"));

                    if (student != null)
                        student.Name = "Alice";

                    context.SaveChanges();

                    Console.WriteLine("After Updated data:");

                    foreach (var item in context.StudentSet.ToList())
                        Console.WriteLine(item.Name);
                }

                Console.WriteLine();

                // Query data.
                {
                    var students = context.StudentSet.Where(w => w.Name.Contains("T"));

                    Console.WriteLine("Query data:");

                    foreach (var item in students)
                        Console.WriteLine(item.Name);
                }
            }

            Console.ReadKey();
        }
    }
}