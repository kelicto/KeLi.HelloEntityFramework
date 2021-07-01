using System.ComponentModel.DataAnnotations;

namespace KeLi.HelloEntityFramework.SQLite.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
