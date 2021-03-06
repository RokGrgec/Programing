﻿using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PPPK_Project.Models
{
    public static class DBHelper
    {
        public static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["PPPK_DB"].ConnectionString;
        public static List<string> TABLE_NAMES = new List<string> { "CostOfGasRefill", "Driver", "OccupyedVehicle", "OccupyingDriver", "Service", "Status", "TravelRoute", "TravelWarrant", "Vehicle" };

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
                    c.Parameters.AddWithValue("@fname", name);
                    c.Parameters.AddWithValue("@lastname", surname);
                    c.Parameters.AddWithValue("@phonenum", phone_num);
                    c.Parameters.AddWithValue("@driverlicensenum", driver_licence_num);
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
                using (SqlCommand c = new SqlCommand("update Driver set " + "Name = @name, Surname = @surname, PhoneNumber = @phone_num, DriverLicenceNumber = @driver_licence_num " +
                    "where DriverID = @id", con))
                {

                    c.Parameters.AddWithValue("@name", name);
                    c.Parameters.AddWithValue("@surname", surname);
                    c.Parameters.AddWithValue("@phone_num", phone_num);
                    c.Parameters.AddWithValue("@driver_licence_num", driver_licence_num);
                    c.Parameters.AddWithValue("@DriverID", id);

                    return (c.ExecuteNonQuery() == 0) ? true : false;
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
                    c.Parameters.AddWithValue("@id", id);

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
                    c.Parameters.AddWithValue("@type", vehicle_type);
                    c.Parameters.AddWithValue("@model", vehicle_brand);
                    c.Parameters.AddWithValue("@prodyear", production_year);
                    c.Parameters.AddWithValue("@startingkilometers", starting_kilometers);
                    c.Parameters.AddWithValue("@currentkilometers", current_kilometers);
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
                    c.Parameters.AddWithValue("@id", id);

                    return (c.ExecuteNonQuery() == 0) ? false : true;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static int insertTravelWarrant(DateTime? starting_date, DateTime? ending_date, int id_status, int driver_id, int vehicle_id)
        {
            DateTime date_created = DateTime.Now;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand c = new SqlCommand("insert_travelwarrant", con))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.AddWithValue("@datecreated", date_created);
                    c.Parameters.AddWithValue("@dateofstart", starting_date);
                    c.Parameters.AddWithValue("@dateofending", ending_date);
                    c.Parameters.AddWithValue("IDStatus", id_status = 1);
                    c.Parameters.AddWithValue("@IDDriver", driver_id = 1);
                    c.Parameters.AddWithValue("@IDVehicle", vehicle_id = 1);
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

        public static void ExportDb()
        {
            var xmlFileData = "";
            DataSet ds = new DataSet();

            foreach (var table in TABLE_NAMES)
            {
                var query = "SELECT * FROM " + table;

                using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(query, c);

                    c.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable(table);
                    da.Fill(dt);

                    c.Close();
                    c.Dispose();

                    ds.Tables.Add(dt);
                }

               
            }

            // xmlFileData = ds.GetXml();
            var xmlstream = new StringWriter();
            ds.WriteXml(xmlstream, XmlWriteMode.WriteSchema);
            string xmlWithSchema = xmlstream.ToString();
            File.WriteAllText(@"D:\LearningCSharp\MVC Projects\PPPK_Project\PPPK_Project\SelectiveDatabaseBackup.xml", xmlWithSchema);
        }

        public static void RestoreDb()
        {
            //EnableIDInsert();
            //foreach (string tblname in TABLE_NAMES)
            //{
            //    using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            //    {
            //        DataSet ds = new DataSet(tblname);
            //        //ds.ReadXml(Path.Combine(DATA_DIR, tblname + ".xml")); TO DO
            //        c.Open();
            //        using (SqlBulkCopy cop = new SqlBulkCopy(c, SqlBulkCopyOptions.KeepIdentity, null))
            //        {
            //            cop.DestinationTableName = $"[dbo].[{tblname}]";
            //            cop.WriteToServer(ds.Tables[0]);
            //        }
            //        c.Close();
            //    }
            //}
            //DisableIDInsert();
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlCommand a = new SqlCommand("insert_dummy_data", c))
                {
                    a.CommandType = CommandType.StoredProcedure;
                    a.ExecuteNonQuery();
                }
                c.Close();
                c.Close();
            }
        }

        //-----------------------------------------------------------------------------
        public static Driver getDriver(int id)
        {
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter("select * from Driver where DriverID=@id", c))
                {
                    a.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = id,
                        SqlDbType = SqlDbType.Int
                    });
                    DataTable t = new DataTable();
                    a.Fill(t);
                    if (t.Rows.Count > 0)
                    {
                        Driver d = new Driver
                        {
                            DriverID = Convert.ToInt16(t.Rows[0]["DriverID"]),
                            Name = Convert.ToString(t.Rows[0]["Name"]),
                            Surname = Convert.ToString(t.Rows[0]["Surname"]),
                            PhoneNumber = Convert.ToString(t.Rows[0]["PhoneNumber"]),
                            DriverLicenceNumber = Convert.ToString(t.Rows[0]["DriverLicenceNumber"])
                        };
                        return d;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public static List<Driver> getAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter("select * from Driver", c))
                {

                    DataTable t = new DataTable();
                    a.Fill(t);
                    if (t.Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow dataRow in t.Rows)
                        {
                            Driver d = new Driver
                            {
                                DriverID = Convert.ToInt16(t.Rows[i]["DriverID"]),
                                Name = Convert.ToString(t.Rows[i]["Name"]),
                                Surname = Convert.ToString(t.Rows[i]["Surname"]),
                                PhoneNumber = Convert.ToString(t.Rows[i]["PhoneNumber"]),
                                DriverLicenceNumber = Convert.ToString(t.Rows[i]["DriverLicenceNumber"])
                            };
                            drivers.Add(d);
                            if (i < t.Rows.Count)
                            {
                                i++;
                            }
                        }
                        return drivers;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }



        public static List<Status> getAllStatuses()
        {
            List<Status> statuses = new List<Status>();
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter("select * from [Status]", c))
                {

                    DataTable t = new DataTable();
                    a.Fill(t);
                    if (t.Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow dataRow in t.Rows)
                        {
                            Status s = new Status
                            {
                                StatusID = Convert.ToInt16(t.Rows[i]["StatusID"]),
                                StatusType = Convert.ToString(t.Rows[i]["StatusType"])
                            };
                            statuses.Add(s);
                            if (i < t.Rows.Count)
                            {
                                i++;
                            }
                        }
                        return statuses;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }



        //------------------------------------------------------------------------------------------
        public static Vehicle getVehicle(int id)
        {

            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter("select * from Vehicle where VehicleID=@id", c))
                {
                    a.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = id,
                        SqlDbType = SqlDbType.Int
                    });
                    DataTable t = new DataTable();
                    a.Fill(t);
                    if (t.Rows.Count > 0)
                    {
                        Vehicle v = new Vehicle
                        {
                            VehicleID = Convert.ToInt16(t.Rows[0]["VehicleID"]),
                            VehicleType = Convert.ToString(t.Rows[0]["VehicleType"]),
                            VehicleBrand = Convert.ToString(t.Rows[0]["VehicleBrand"]),
                            StartingKilometers = Convert.ToInt32(t.Rows[0]["StartingKilometers"]),
                            CurrentKilometers = Convert.ToInt32(t.Rows[0]["CurrentKilometers"]),
                            ProductionYear = Convert.ToDateTime(t.Rows[0]["ProductionYear"])
                        };
                        return v;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static List<Vehicle> getAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter("select * from Vehicle", c))
                {
                    DataTable t = new DataTable();
                    a.Fill(t);
                    if (t.Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow dr in t.Rows)
                        {
                            Vehicle v = new Vehicle
                            {
                                VehicleID = Convert.ToInt16(t.Rows[i]["VehicleID"]),
                                VehicleType = Convert.ToString(t.Rows[i]["VehicleType"]),
                                VehicleBrand = Convert.ToString(t.Rows[i]["VehicleBrand"]),
                                StartingKilometers = Convert.ToInt32(t.Rows[i]["StartingKilometers"]),
                                CurrentKilometers = Convert.ToInt32(t.Rows[i]["CurrentKilometers"]),
                                ProductionYear = Convert.ToDateTime(t.Rows[i]["ProductionYear"])
                            };
                            vehicles.Add(v);
                            if (i < t.Rows.Count)
                            {
                                i++;
                            }
                        }
                        return vehicles;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------
        public static List<Service> getServices(int id)
        {
            
            List<Service> services = new List<Service>();
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter("select * from Service where IDVehicle=@id", c))
                {
                    a.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = id,
                        SqlDbType = SqlDbType.Int
                    });
                    DataTable t = new DataTable();
                    a.Fill(t);
                    if (t.Rows.Count > 0)
                    {
                        foreach (DataRow row in t.Rows)
                        {
                            services.Add(new Service
                            {
                                ServiceID = Convert.ToInt16(row["ServiceID"]),
                                PlaceOfService = Convert.ToString(row["PlaceOfService"]),
                                NameOfService = Convert.ToString(row["NameOfService"]),
                                CostOfService = Convert.ToInt32(row["CostOfService"]),
                                ServiceInfo = Convert.ToString(row["ServiceInfo"]),
                                IDVehicle = Convert.ToInt16(row["IDVehicle"])
                            });
                        }
                        return services;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        //---------------------------------------------------------------------------------------------
        public static TravelWarrantCS getTravelWarrant(int id)
        {
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter("exec [dbo].[select_travelwarrant] @id", c))
                {
                    a.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = id,
                        SqlDbType = SqlDbType.Int
                    });
                    DataTable t = new DataTable();
                    a.Fill(t);
                    if (t.Rows.Count > 0)
                    {
                        TravelWarrantCS twcs = new TravelWarrantCS
                        {
                            travelWarrant = new TravelWarrant
                            {
                                DateCreated = Convert.ToDateTime(t.Rows[0]["DateCreated"]),
                                StartingDate = Convert.ToDateTime(t.Rows[0]["StartingDate"]),
                                EndingDate = Convert.ToDateTime(t.Rows[0]["EndingDate"]),
                                IDVehicle = Convert.ToInt16(t.Rows[0]["IDVehicle"]),
                                IDDriver = Convert.ToInt16(t.Rows[0]["IDDriver"]),
                                IDStatus = Convert.ToInt16(t.Rows[0]["IDStatus"])
                            },
                            vehicle = new Vehicle
                            {
                                VehicleBrand = Convert.ToString(t.Rows[0]["VehicleBrand"]),
                                ProductionYear = Convert.ToDateTime(t.Rows[0]["ProductionYear"])
                            },
                            driver = new Driver
                            {
                                Name = Convert.ToString(t.Rows[0]["Name"]),
                                Surname = Convert.ToString(t.Rows[0]["Surname"])
                            },
                            status = new Status
                            {
                                StatusType = Convert.ToString(t.Rows[0]["StatusType"])
                            }
                        };
                        return twcs;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static List<TravelWarrantCS> getAllTravelWarrants()
        {
            using (SqlConnection c = new SqlConnection(CONNECTION_STRING))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter("exec [dbo].[select_all_travelwarrants]", c))
                {
                    DataTable t = new DataTable();
                    a.Fill(t);
                    List<TravelWarrantCS> travelWarrants = new List<TravelWarrantCS>();
                    if (t.Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow dr in t.Rows)
                        {
                            TravelWarrantCS tw = new TravelWarrantCS
                            {
                                travelWarrant = new TravelWarrant
                                {
                                    DateCreated = Convert.ToDateTime(t.Rows[i]["DateCreated"]),
                                    StartingDate = Convert.ToDateTime(t.Rows[i]["StartingDate"]),
                                    EndingDate = Convert.ToDateTime(t.Rows[i]["EndingDate"]),
                                    IDVehicle = Convert.ToInt16(t.Rows[i]["IDVehicle"]),
                                    IDDriver = Convert.ToInt16(t.Rows[i]["IDDriver"]),
                                    IDStatus = Convert.ToInt16(t.Rows[i]["IDStatus"])
                                },
                                vehicle = new Vehicle
                                {
                                    VehicleBrand = Convert.ToString(t.Rows[i]["VehicleBrand"]),
                                    ProductionYear = Convert.ToDateTime(t.Rows[i]["ProductionYear"])
                                },
                                driver = new Driver
                                {
                                    Name = Convert.ToString(t.Rows[i]["Name"]),
                                    Surname = Convert.ToString(t.Rows[i]["Surname"])
                                },
                                status = new Status
                                {
                                    StatusType = Convert.ToString(t.Rows[i]["StatusType"])
                                }
                            };
                            travelWarrants.Add(tw);
                            if (i < t.Rows.Count)
                            {
                                i++;
                            }
                        }
                        return travelWarrants;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

    }
}