using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMT_ITIWithDb.ViewModel
{
    public class EmployeeVMcs
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(18,100)]
        public int? Age { get; set; }
        [Range(3000,20000)]
        public string? Salary { get; set; }
        public string? Email { get; set; }
        //Minimum eight characters, at least one letter and one number:
        [RegularExpression("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z[0-9]{8,}$")]
        public string? Password { get; set; }
        [Compare("Password")]
        public  string? ConfirmPassword { get; set; }
        public string? Img { get; set; }
        [Display(Name ="Office")]
        public int? Office_Id { get; set; }
        [ValidateNever]
   public SelectList Offices { get; set; }  

    }
}
