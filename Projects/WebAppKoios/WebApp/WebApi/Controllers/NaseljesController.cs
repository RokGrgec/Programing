using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApi.Models;

namespace NaseljaWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "Content-Type", methods: "GET, POST, PUT, DELETE")]
    public class NaseljesController : ApiController
    {
        private NaseljaDBEntities db = new NaseljaDBEntities();

        // GET: api/Naseljes
        public IQueryable<Naselje> GetNaselje()
        {
            return db.Naselje;
        }

        // GET: api/Naseljes/5
        [ResponseType(typeof(Naselje))]
        [Route("api/naselja/all")]
        public IHttpActionResult GetAllNaselje()
        {
            IList<NaseljeViewModel> naselja = null;
            using (db)
            {
                naselja = db.Naselje
                .Include("Drzava")
                .Select(n => new NaseljeViewModel()
                {
                    NaseljeID = n.NaseljeID,
                    Naziv = n.Naziv,
                    PostanskiBroj = n.PostanskiBroj,
                    IDDrzava = n.IDDrzava,
                    Drzava = n.Drzava

                }).ToList<NaseljeViewModel>();
            }
            if (naselja == null)
            {
                return NotFound();
            }

            return Ok(naselja);
        }


        [ResponseType(typeof(Naselje))]
        [Route("api/naselja/{id}")]
        public IHttpActionResult GetNaselje(int id)
        {
            NaseljeViewModel naselje = null;
            using (db)
            {
                if (id == 0)
                {
                    naselje = null;
                }
                else
                {
                    naselje = db.Naselje
                        .Include("Drzava")
                        .Where(s => s.NaseljeID == id)
                        .Select(s => new NaseljeViewModel()
                        {
                            NaseljeID = s.NaseljeID,
                            Naziv = s.Naziv,
                            PostanskiBroj = s.PostanskiBroj,
                            IDDrzava = s.IDDrzava,
                            Drzava = s.Drzava


                        }).FirstOrDefault<NaseljeViewModel>();
                }
            }

            return Ok(naselje);
        }

        // PUT: api/Naseljes/5
        [ResponseType(typeof(void))]
        [Route("api/naselje/update")]
        public IHttpActionResult PutNaselje(NaseljeViewModel naselje)
        {

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (db)
            {
                var existingNaselje = db.Naselje.Where(n => n.NaseljeID == naselje.NaseljeID)
                                                .FirstOrDefault<Naselje>();
                if (existingNaselje != null)
                {
                    existingNaselje.NaseljeID = naselje.NaseljeID;
                    existingNaselje.Naziv = naselje.Naziv;
                    existingNaselje.PostanskiBroj = naselje.PostanskiBroj;
                    existingNaselje.IDDrzava = naselje.IDDrzava;

                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }


        // POST: api/Naseljes
        [ResponseType(typeof(Naselje))]
        [Route("api/naselje/create")]
        public IHttpActionResult PostNaselje(NaseljeViewModel naselje)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (db)
            {
                db.Naselje.Add(new Naselje()
                {
                    Naziv = naselje.Naziv,
                    PostanskiBroj = naselje.PostanskiBroj,
                    IDDrzava = naselje.IDDrzava
                });

                db.SaveChanges();
            }

            return Ok();
        }

        // DELETE: api/Naseljes/5
        [ResponseType(typeof(Naselje))]
        [Route("api/naselje/{id}")]
        public IHttpActionResult DeleteNaselje(int id)
        {
            using (db)
            {
                db.Database.ExecuteSqlCommand(
                    "Exec delete_naselje @naselje_id",
                    new SqlParameter("@naselje_id", id
                    ));
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}