using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;


namespace PPPK_Project.Models
{
    public static class DBHelper
    {
        public static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["pppkDBEntities"].ConnectionString;
        public static List<string> TABLE_NAMES = new List<string> { "CostOfGasRefil", "Driver", "OccupyedVehicle", "OccupyingDriver", "Service", "Status", "TravelRoute", "TravelWarrant", "Vehicle" };

        //insert_driver, insert_vehicle, insert_service, insert_costofgasrefill, insert_travelwarrant, insert_trevelroute, delete_service, delete_vehicle, delete_travelwarrant
        //delete_travelroute, delete_driver, select_travelwarrant, select_all_travelwarrants
        //enable_id_insert, disable_id_insert, insert_dummy_data, clean_database

        public static int insertDriver(string name, string surname, string phone_num, string driver_licence_num)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("insert_driver", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@Name", name);
                    c.Parameters.AddWithValue("@Surname", surname);
                    c.Parameters.AddWithValue("@PhoneNumber", phone_num);
                    c.Parameters.AddWithValue("@DriverLicenceNumber", driver_licence_num);
                    object result = c.ExecuteScalar();
                    result = (result == DBNull.Value) ? 0 : result;
                    int ret = Convert.ToInt32(result);
                    
                    return ret;
                }
            }
        }

        public static bool updateDriver(int id, string name, string surname, string phone_num, string driver_licence_num)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("update Driver set " + "Name = @name, Surnmae = @surname, PhoneNumber = @phone_num, DriverLicenceNumber = @driver_licence_num" + 
                    "where DriverID=@id", con))
                {
                   
                    c.Parameters.AddWithValue("@Name", name);
                    c.Parameters.AddWithValue("@Surname", surname);
                    c.Parameters.AddWithValue("@PhoneNumber", phone_num);
                    c.Parameters.AddWithValue("@DriverLicenceNumber", driver_licence_num);
                    c.Parameters.AddWithValue("@DriverID", id);

                    return (c.ExecuteNonQuery() == 0) ? true : false ;
                }
            }
        }
        public static bool deleteDriver(int id)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("delete_driver", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@DriverID", id);

                    return (c.ExecuteNonQuery() == 0) ? false : true;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------//
        public static int insertService(string place_of_serv, string name_of_serv, int cost_of_serv, string serv_info)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("insert_service", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@PlaceOfService", place_of_serv);
                    c.Parameters.AddWithValue("@NameOfService", name_of_serv);
                    c.Parameters.AddWithValue("@CostOfService", cost_of_serv);
                    c.Parameters.AddWithValue("@ServiceInfo", serv_info);
                    object result = c.ExecuteScalar();
                    result = (result == DBNull.Value) ? 0 : result;
                    int ret = Convert.ToInt32(result);

                    return ret;
                }
            }
        }

        public static bool updateService(int id, string place_of_serv, string name_of_serv, int cost_of_serv, string serv_info)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("update Service set " + "PlaceOfService = @place_of_serv, NameOfService = @name_of_serv," +
                    "CostOfService = @cost_of_serv, ServiceInfo = @serv_info" +
                    "where ServiceID=@id", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@PlaceOfService", place_of_serv);
                    c.Parameters.AddWithValue("@NameOfService", name_of_serv);
                    c.Parameters.AddWithValue("@CostOfService", cost_of_serv);
                    c.Parameters.AddWithValue("@ServiceInfo", serv_info);
                    c.Parameters.AddWithValue("@ServiceID", id);

                    return (c.ExecuteNonQuery() == 0) ? true : false;
                }
            }
        }
        public static bool deleteService(int id)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("delete_service", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@ServiceID", id);

                    return (c.ExecuteNonQuery() == 0) ? false : true;
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------
        public static bool deleteTravelRoute(int id)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("delete_travelroute", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@TravelRouteID", id);

                    return (c.ExecuteNonQuery() == 0) ? false : true;
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------
        public static int insertVehicle(string vehicle_type, string vehicle_brand, DateTime production_year, int? starting_kilometers, int? current_kilometers)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("insert_vehicle", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@VehicleType", vehicle_type);
                    c.Parameters.AddWithValue("@VehicleBrand", vehicle_brand);
                    c.Parameters.AddWithValue("@ProductionYear", production_year);
                    c.Parameters.AddWithValue("@StartingKilometers", starting_kilometers);
                    c.Parameters.AddWithValue("@CurrentKilometers", current_kilometers);
                    object result = c.ExecuteScalar();
                    result = (result == DBNull.Value) ? 0 : result;
                    int ret = Convert.ToInt32(result);

                    return ret;
                }
            }
        }

        public static bool updateVehicle(int id, string vehicle_type, string vehicle_brand, DateTime production_year, int? starting_kilometers, int? current_kilometers)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("update Vehicle set " + "VehicleType = @vehicle_type, VehicleBrand = @vehicle_brand," +
                    "ProductionYear = @production_year, StartingKilometers = @starting_kilometers, CurrentKilometers = @current_kilometers " +
                    "where VehicleID=@id", con))
                {
                    c.Parameters.AddWithValue("@VehicleType", vehicle_type);
                    c.Parameters.AddWithValue("@VehicleBrand", vehicle_brand);
                    c.Parameters.AddWithValue("@ProductionYear", production_year);
                    c.Parameters.AddWithValue("@StartingKilometers", starting_kilometers);
                    c.Parameters.AddWithValue("@CurrentKilometers", current_kilometers);
                    c.Parameters.AddWithValue("@VehicleID", id);

                    return (c.ExecuteNonQuery() == 0) ? true : false;
                }
            }
        }
        public static bool deleteVehicle(int id)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("delete_vehicle", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@VehicleID", id);

                    return (c.ExecuteNonQuery() == 0) ? false : true;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static int insertTravelWarrant(DateTime? starting_date, DateTime? ending_date, int driver_id, int vehicle_id)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("insert_travelwarrant", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@IDDriver", driver_id);
                    c.Parameters.AddWithValue("@IDVehicle", vehicle_id);
                    c.Parameters.AddWithValue("IDStatus", 1);  
                    c.Parameters.AddWithValue("@StartingDate", starting_date);
                    c.Parameters.AddWithValue("@EndingDate", ending_date);
                    object result = c.ExecuteScalar();
                    result = (result == DBNull.Value) ? 0 : result;
                    int ret = Convert.ToInt32(result);

                    return ret;
                }
            }
        }
        //############# TO DO #####################
        //public static bool updateTravelWarrant(int id, DateTime? starting_date, DateTime? ending_date, int driver_id, int vehicle_id)
        //{

        //    using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
        //    {
        //        con.Open();
        //        using (SqlCommand c = new SqlCommand("update TravelWarrant set " + "VehicleType = @vehicle_type, VehicleBrand = @vehicle_brand," +
        //            "ProductionYear = @production_year, StartingKilometers = @starting_kilometers, CurrentKilometers = @current_kilometers " +
        //            "where VehicleID=@id", con))
        //        {
        //            c.Parameters.AddWithValue("@VehicleType", vehicle_type);
        //            c.Parameters.AddWithValue("@VehicleBrand", vehicle_brand);
        //            c.Parameters.AddWithValue("@ProductionYear", production_year);
        //            c.Parameters.AddWithValue("@StartingKilometers", starting_kilometers);
        //            c.Parameters.AddWithValue("@CurrentKilometers", current_kilometers);
        //            c.Parameters.AddWithValue("@VehicleID", id);

        //            return (c.ExecuteNonQuery() == 0) ? true : false;
        //        }
        //    }
        //}
        public static bool deleteTravelWarrant(int id)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("delete_travelwarrant", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@TravelWarrantID", id);
                    
                    return (c.ExecuteNonQuery() == 0) ? false : true;
                }
            }
        }

        public static void CleanDb()
        {
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlCommand a = new SqlCommand("clean_database", c))
                {
                    a.CommandType = CommandType.StoredProcedure;
                    a.ExecuteNonQuery();
                }
                c.Close();
                c.Close();
            }
        }

        private static void EnableIDInsert()
        {
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlCommand a = new SqlCommand("enable_id_insert", c))
                {
                    a.CommandType = CommandType.StoredProcedure;
                    a.ExecuteNonQuery();
                }
                c.Close();
            }
        }

        private static void DisableIDInsert()
        {
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlCommand a = new SqlCommand("disable_id_insert", c))
                {
                    a.CommandType = CommandType.StoredProcedure;
                    a.ExecuteNonQuery();
                }
                c.Close();
            }
        }

        public static void RestoreDb()
        {
            EnableIDInsert();
            foreach (string tblname in TABLE_NAMES)
            {
                using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
                {
                    DataSet ds = new DataSet(tblname);
                    //ds.ReadXml(Path.Combine(DATA_DIR, tblname + ".xml")); TO DO
                    c.Open();
                    using (SqlBulkCopy cop = new SqlBulkCopy(c, SqlBulkCopyOptions.KeepIdentity, null))
                    {
                        cop.DestinationTableName = $"[dbo].[{tblname}]";
                        cop.WriteToServer(ds.Tables[0]);
                    }
                    c.Close();
                }
            }
            DisableIDInsert();
        }
    }
}