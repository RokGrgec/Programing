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
    
    public partial class FoodType
    {
        public FoodType()
        {
            this.Goods = new HashSet<Good>();
        }
    
        public int Id { get; set; }
        public string Type { get; set; }
    
        public virtual ICollection<Good> Goods { get; set; }
    }
}
