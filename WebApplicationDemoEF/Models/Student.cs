using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationDemoEF.Models
{
    [Table(name: "tblStudent")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Batch { get; set; }
        public int Marks { get; set; }

    }
}
