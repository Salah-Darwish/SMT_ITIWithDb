using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMT_ITIWithDb.Models
{
    [PrimaryKey("emp_id","pro_id")]
    public class Emp_Pro
    {
        [ForeignKey("Employee")]
        public int emp_id { get; set; }
        [ForeignKey("Project")]
        public int pro_id { get; set; }
        public int working_hours { get; set; }

        // Navigation Property 
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
