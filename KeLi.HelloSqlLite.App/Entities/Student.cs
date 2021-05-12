using System.ComponentModel.DataAnnotations;

namespace KeLi.HelloSqlLite.App.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
