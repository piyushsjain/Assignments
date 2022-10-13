using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.DataAccessLayer.Entities
{
    public class SignupEntity
    {
        [Required(ErrorMessage = "Please enter your Full Name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your Email Address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please provide a valid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your PAN Number")]
        [Display(Name = "PAN Number")]
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Please Select Bank Name")]
        [Display(Name = "BankName")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "Please Enter Bank Number")]
        [Display(Name = "BankNumber")]
        public int BankNumber { get; set; }


        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage = "Please Provide a valid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password, ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
