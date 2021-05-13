using System.ComponentModel.DataAnnotations;

namespace KeLi.HelloEntityFramework.SQLite.DataModels
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
