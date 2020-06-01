using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace PPPK_Project.Models
{
    public class TravelWarrantCS
    {
        public TravelWarrant travelWarrant{ get; set; }

        public Driver driver { get; set; }

        public Vehicle vehicle { get; set; }

        public string statusType { get; set; }

    }
}