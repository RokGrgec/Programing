//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPPK_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TravelRoute
    {
        public int TravelRouteID { get; set; }
        public Nullable<decimal> x_cordinate_ofDeparture { get; set; }
        public Nullable<decimal> y_cordinate_ofDeparture { get; set; }
        public Nullable<decimal> x_cordinate_ofArrival { get; set; }
        public Nullable<decimal> y_cordinate_ofArrival { get; set; }
        public Nullable<decimal> TotalTravelDistance { get; set; }
        public Nullable<decimal> AverageSpeed { get; set; }
        public Nullable<int> IDTravelWarrant { get; set; }
    
        public virtual TravelWarrant TravelWarrant { get; set; }
    }
}
