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
    
    public partial class CombDefinition
    {
        public int Id { get; set; }
        public string FatPerCent { get; set; }
        public string CarbPerCent { get; set; }
        public string ProteinPerCent { get; set; }
        public string TotalPer { get; set; }
        public int MealNameID { get; set; }
        public Nullable<int> MealCombinationID { get; set; }
    
        public virtual MealCombination MealCombination { get; set; }
        public virtual MealName MealName { get; set; }
    }
}