using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class SignInModel
    {
        public Int64 UserID { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(50)]
        public String Username { get; set; }
        public Int32 UserTypeID { get; set; }
        public string UserType { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(50)]
        public String Password { get; set; }
        public String Fullname { get; set; }
        public String LoginErrorMsg { get; set; }

        public String UsernameErrorMsg { get; set; }

        public String PasswordErrorMsg { get; set; }
    }
    public class ChangePasswordModel
    {
        public Int64 UserID { get; set; }
        [Required]
        [Display(Name = "CurrentPassword")]
        [StringLength(80)]
        public String CurrentPassword { get; set; }
        [Required]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The New password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }
        public String ErrorMsg { get; set; }


    }
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid E-Mail.")]
        [StringLength(50)]
        public String EmailId { get; set; }
    }  
}
