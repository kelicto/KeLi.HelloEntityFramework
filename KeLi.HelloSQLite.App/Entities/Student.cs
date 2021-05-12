using System.ComponentModel.DataAnnotations;

namespace KeLi.HelloSQLite.App.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
