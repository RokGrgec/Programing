using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class NaseljeViewModel
    {
        public int NaseljeID { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
        public int? IDDrzava { get; set; }
        public Drzava Drzava { get; set; }
    }
}