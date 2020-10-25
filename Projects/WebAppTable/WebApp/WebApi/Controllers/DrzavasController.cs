using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Routing;
using WebApi.Models;

namespace NaseljaWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "Content-Type", methods: "GET, POST, PUT, DELETE")]
    public class DrzavasController : ApiController
    {
        private NaseljaDBEntities db = new NaseljaDBEntities();


        [ResponseType(typeof(Drzava))]
        [Route("api/drzava/all")]
        public IHttpActionResult GetDrzava()
        {
            IList<DrzavaViewModel> drzave = null;
            using (db)
            {
                drzave = db.Drzava
                    .Select(d => new DrzavaViewModel()
                    {
                        DrzavaID = d.DrzavaID,
                        Naziv = d.Naziv
                    }).ToList<DrzavaViewModel>();
            }
            if (drzave == null)
            {
                return NotFound();
            }

            return Ok(drzave);
        }


    }
}