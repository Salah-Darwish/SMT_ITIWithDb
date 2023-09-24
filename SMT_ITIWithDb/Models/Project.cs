namespace SMT_ITIWithDb.Models
{
    public class Project

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Property 
        public List<Emp_Pro>emp_Pros { get; set; }
       
    }
}