namespace SMT_ITIWithDb.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        // Navigation Property 
        public List<Employee> Employees { get; set; }

    }
}
