using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DiabetesHelperUser.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        
    }
    public class UserMetadata
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        public string Surname { get; set; }

        [Display(Name = "Age")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        public Nullable<int> Height { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        public Nullable<int> Weight { get; set; }

        [Display(Name = "Activity (Mild, Occasional, Regular)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        public string Activity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        [Display(Name = "Diabetes Type (1 or 2)")]
        public Nullable<int> DiaType { get; set; }


        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        public string Gender { get; set; }

        [Display(Name = "User Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Required")]
        public string Password { get; set; }
    }
}