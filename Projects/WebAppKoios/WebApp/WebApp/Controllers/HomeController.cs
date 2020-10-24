using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            NaseljeViewModel naselje = new NaseljeViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44315/api/naselja/");
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<NaseljeViewModel>();
                    readTask.Wait();

                    naselje = readTask.Result;
                }
                return View(naselje);
            }
        }

        [HttpPost]
        public ActionResult Save(NaseljeViewModel n)
        {
            NaseljeViewModel naselje = new NaseljeViewModel();
            bool status = false;
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    if (n.NaseljeID > 0)
                    {
                        //Edit 
                        client.BaseAddress = new Uri("https://localhost:44315/api/naselje/update");
                        naselje.NaseljeID = n.NaseljeID;
                        naselje.Naziv = n.Naziv;
                        naselje.PostanskiBroj = n.PostanskiBroj;
                        naselje.IDDrzava = n.IDDrzava;

                        var putTask = client.PutAsJsonAsync<NaseljeViewModel>("update", naselje);

                        var result = putTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            status = true;
                        }
                    }
                    else
                    {
                        //Save
                        
                        client.BaseAddress = new Uri("https://localhost:44315/api/naselje/create");
                        
                        naselje.Naziv = n.Naziv;
                        naselje.PostanskiBroj = n.PostanskiBroj;
                        naselje.IDDrzava = n.IDDrzava;

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<NaseljeViewModel>("create", naselje);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            status = true;
                        }
                        
                    }
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            NaseljeViewModel naselje = new NaseljeViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44315/api/naselja/");
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<NaseljeViewModel>();
                    readTask.Wait();

                    naselje = readTask.Result;
                    return View(naselje);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteNaselje(int id)
        {
            bool status = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44315/api/naselje/delete");
                
                //HTTP POST
                var deleteTask = client.DeleteAsync(id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}