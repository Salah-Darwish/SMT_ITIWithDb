using Microsoft.Build.Framework;

namespace SMT_ITIWithDb.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
     
        public bool IsOffice { get; set; }
    }
}