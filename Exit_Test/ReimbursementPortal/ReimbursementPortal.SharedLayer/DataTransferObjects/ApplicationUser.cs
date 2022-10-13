using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.SharedLayer.DataTransferObjects
{ 
   public class ApplicationUser :IdentityUser
    {
        [Required(ErrorMessage = "Please enter your Full Name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your PAN Number")]
        [Display(Name = "PAN Number")]
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Please enter your Bank Name")]
        [Display(Name = "Bank")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "Please enter your Bank Number")]
        [Display(Name = "BankNumber")]
        public int BankNumber { get; set; }
    }
}
