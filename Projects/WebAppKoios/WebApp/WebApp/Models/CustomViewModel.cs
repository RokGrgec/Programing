using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CustomViewModel
    {
        public NaseljeViewModel Naselje { get; set; }
        public List<DrzavaViewModel> Drzave { get; set; }
    }
}