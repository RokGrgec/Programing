//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiabetesHelperUser
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class User
    {
        public User()
        {
            this.Menus = new HashSet<Menu>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Activity { get; set; }
        public Nullable<int> DiaType { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
