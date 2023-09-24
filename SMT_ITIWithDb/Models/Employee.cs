using System.ComponentModel.DataAnnotations.Schema;

namespace SMT_ITIWithDb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age{ get; set; }
        public string? Salary { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //Frogien Key
        public string? Img { get; set;  }
        [ForeignKey("Office")]
        public int? Office_Id { get; set; }


        // Navigation Property 
        public Office?Office { get; set; }
        public List<Emp_Pro>emp_Pros { get; set; }


    }
}
