using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPPK_Project.Models
{
    public class DropdownHelper
    {
        public static List<SelectListItem> VehiclesDropDonw()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Vehicle> vehicles = DBHelper.getAllVehicles();
            foreach (Vehicle v in vehicles)
            {
                items.Add(new SelectListItem
                {
                    Text = string.Format("{0}({1})", v.VehicleBrand, v.ProductionYear),
                    Value = v.VehicleID.ToString()
                });
            }
            return items;


        }

        public static List<SelectListItem> DriversDropDown()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Driver> drivers = DBHelper.getAllDrivers();
            foreach (Driver v in drivers)
            {
                items.Add(new SelectListItem
                {
                    Text = (v.Name + " " + v.Surname),
                    Value = v.DriverID.ToString()
                });
            }
            return items;
        }

        public static List<SelectListItem> ServicesDropDown()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Status> statuses = DBHelper.getAllStatuses();
            foreach (Status s in statuses)
            {
                items.Add(new SelectListItem
                {
                    Text = (s.StatusType),
                    Value = s.StatusID.ToString()
                });
            }
            return items;
        }
    }
}