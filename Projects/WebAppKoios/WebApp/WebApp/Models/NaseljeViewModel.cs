using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class NaseljeViewModel
    {
        public int NaseljeID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Naziv naselja mora biti slovcan!")]
        public string Naziv { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Postanski broj mora biti brojcan!")]
        public string PostanskiBroj { get; set; }
        public int? IDDrzava { get; set; }

        public DrzavaViewModel Drzava { get; set; }
    }
}