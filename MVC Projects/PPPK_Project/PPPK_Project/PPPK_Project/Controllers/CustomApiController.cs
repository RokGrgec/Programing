using PPPK_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PPPK_Project.Controllers
{
    public class CustomApiController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Driver(int? id, string name, string surname, string phonenum, string licencenum)
        {

            DBHelper.updateDriver((int)id, name, surname, phonenum, licencenum);
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority) + $"/Drivers/Driver/{id}";
            response.Headers.Location = new Uri(fullyQualifiedUrl);
            return response;

        }

        [HttpPost]
        public HttpResponseMessage Driver(int? id)
        {

            DBHelper.deleteDriver((int)id);
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/Driver";
            response.Headers.Location = new Uri(fullyQualifiedUrl);
            return response;

        }

        [HttpGet]
        public HttpResponseMessage Vehicle(int? id, string type, string brand, int starting_km, int current_km, DateTime prod_year)
        {

            DBHelper.updateVehicle((int)id, type, brand, prod_year, starting_km, current_km);
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority) + $"/Vehicles/Vehicle/{id}";
            response.Headers.Location = new Uri(fullyQualifiedUrl);
            return response;

        }

        [HttpPost]
        public HttpResponseMessage Vecihle(int? id)
        {

            DBHelper.deleteVehicle((int)id);
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/Vehicles";
            response.Headers.Location = new Uri(fullyQualifiedUrl);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Service(string place, string name, int cost, string info)
        {
            DBHelper.insertService(place, name, cost, info);
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/Vecihles/";
            response.Headers.Location = new Uri(fullyQualifiedUrl);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Service(int id, string place, string name, int cost, string info, int vecihle_id)
        {

            DBHelper.updateService(id, place, name, cost, info);
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority) + $"/Vecihles/Vecihle/{vecihle_id}";
            response.Headers.Location = new Uri(fullyQualifiedUrl);
            return response;

        }

        [HttpPost]
        public HttpResponseMessage Service(int id, int vecihle_id)
        {
            DBHelper.deleteService(id);
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority) + $"/Vecihles/Vecihle/{vecihle_id}";
            response.Headers.Location = new Uri(fullyQualifiedUrl);
            return response;

        }

        [HttpPost]
        public HttpResponseMessage TravelWarrant(int? id)
        {
           
            DBHelper.deleteTravelWarrant((int)id);
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/TravelWarrants";
            response.Headers.Location = new Uri(fullyQualifiedUrl);
            return response;

        }

        [HttpPost]
        public HttpResponseMessage DeleteRoute(int? id)
        {
            DBHelper.deleteTravelRoute((int)id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost]
        public HttpResponseMessage DeleteRoutes(int? id)
        {
            DBHelper.deleteTravelRoute((int)id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}