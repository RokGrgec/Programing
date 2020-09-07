using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DiabetesHelperUser.Models;


namespace DiabetesHelperUser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerateMenu(int NumberOfMeals = 0)
        {
            #region Working Items
            List<Good> goods = new List<Good>();
            List<MealName> mealNames = new List<MealName>();
            List<MeasuringUnit> measuringUnits = new List<MeasuringUnit>();
            List<FoodType> foodTypes = new List<FoodType>();
            List<CombDefinition> combDefinitions = new List<CombDefinition>();
            List<User> userinfo = new List<User>();

            string username = Session["Name"].ToString();
            string password = Session["Password"].ToString();

            int id;
            double user_energy_need;

            int fatpercent = 0;
            int carbpercent = 0;
            int proteinpercent = 0;
            int totalpercent = 0;

            Random r = new Random();
            #endregion

            #region Final Menu Items
            List<Good> carbs = new List<Good>();
            List<Good> fats = new List<Good>();
            List<Good> proteins = new List<Good>();
            List<MeasuringUnit> unitcarb = new List<MeasuringUnit>();
            List<MeasuringUnit> unitprotein = new List<MeasuringUnit>();
            List<MeasuringUnit> unitfat = new List<MeasuringUnit>();
            var validateviewmodel = new ViewModels();
            #endregion

            #region // Total Number of meals in table for user input validation
            string GetNumOfMealsInTable = "select count(NumOfMeals) from MealCombination";
            int num_of_meals_in_table;
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(GetNumOfMealsInTable, con))
                {
                    num_of_meals_in_table = (int)cmd.ExecuteScalar();
                }
                con.Close();
            }
            #endregion

            #region //Retrieving user Id for formula
            string user_id = string.Format("select Id from [User] where Username = {0} and Password = {1}", username, password);
            using (SqlConnection con1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                con1.Open();
                using (SqlCommand cmd = new SqlCommand(user_id, con1))
                {
                    id = (int)cmd.ExecuteScalar(); 
                }
                con1.Close();
            }
            #endregion 

            #region //Retrieving user energy need
            string user_info = string.Format("select u.Id, u.Gender as Gender, u.[Weight] as [Weight], u.Height as Height, u.DiaType as DiabetesType, u.Activity as Activity, u.Age as Age from [User] as u where Id = {0}", id);
            using (SqlConnection con2 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                con2.Open();
                using (SqlCommand cmd = new SqlCommand(user_info, con2))
                {
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var info = new User();
                            info.Height = rd.GetInt32(rd.GetOrdinal("Height"));
                            info.Weight = rd.GetInt32(rd.GetOrdinal("Weight"));
                            info.Age = rd.GetInt32(rd.GetOrdinal("Age"));
                            info.Activity = rd.GetString(rd.GetOrdinal("Activity"));
                            info.DiaType = rd.GetInt32(rd.GetOrdinal("DiabetesType"));
                            info.Gender = rd.GetString(rd.GetOrdinal("Gender"));

                            userinfo.Add(info);
                        }
                    }
                }
                con2.Close();
                #region User Formula
                double Activity = 1;
                double diabtype = 1;
                double gender;
                if (userinfo[0].Activity == "1")
                {
                    Activity = 1.2;
                }
                else if (userinfo[0].Activity == "2")
                {
                    Activity = 1.375;
                }
                else if (userinfo[0].Activity == "3")
                {
                    Activity = 1.5;
                }

                if (userinfo[0].DiaType == 1)
                {
                    diabtype = 0.99;
                }
                else if (userinfo[0].DiaType == 2)
                {
                    diabtype = 0.98;
                }
                if (userinfo[0].Gender == "Male" || userinfo[0].Gender == "male")
                {
                    gender = 5;
                }
                else
                {
                    gender = -161;
                }

                user_energy_need = (((10 * (double)userinfo[0].Weight) + (6.25 * (double)userinfo[0].Height) - (5 * (double)userinfo[0].Age) + gender) * Activity * diabtype);
            }
            #endregion

            #endregion


            if (NumberOfMeals != 0) // not displaying table without user input
            {
                if (NumberOfMeals > num_of_meals_in_table)
                {
                    #region // Validating user input
                    validateviewmodel.NumberOfMeals = 0;
                    validateviewmodel.ErrorMessage = "Menu with that number of meal is not difined, please reenter!";
                    return View(validateviewmodel);
                    #endregion
                }
                else
                {
                    #region //Generating menu items
                    for (int i = 0; i < NumberOfMeals; i++)
                    {
                        #region // getting menu definition values
                        string menu_definition_query = string.Format("select m.[Name] as MealName ,c.FatPerCent, c.ProteinPerCent, c.CarbPerCent, c.TotalPer from CombDefinition as c join MealName as m  on c.MealNameID = m.Id where MealCombinationID = (select Id from MealCombination where NumOfMeals = {0})", NumberOfMeals);
                        using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
                        {
                            conn.Open();
                            using (var cmd = new SqlCommand(menu_definition_query, conn))
                            {
                                using (var rd = cmd.ExecuteReader())
                                {
                                    while (rd.Read())
                                    {
                                        var definitions = new CombDefinition();
                                        definitions.FatPerCent = rd.GetInt32(rd.GetOrdinal("FatPerCent"));
                                        definitions.ProteinPerCent = rd.GetInt32(rd.GetOrdinal("ProteinPerCent"));
                                        definitions.CarbPerCent = rd.GetInt32(rd.GetOrdinal("CarbPerCent"));
                                        definitions.TotalPer = rd.GetInt32(rd.GetOrdinal("TotalPer"));

                                        combDefinitions.Add(definitions);
                                    }
                                }
                            }
                            conn.Close();

                            fatpercent = (int)combDefinitions[0].FatPerCent;
                            proteinpercent = (int)combDefinitions[0].ProteinPerCent;
                            carbpercent = (int)combDefinitions[0].CarbPerCent;
                            totalpercent = (int)combDefinitions[0].TotalPer;
                        }
            
                        #endregion

                        #region //getting all goods
                        string get_all_goods = "select g.*, m.[Name] as MeasuringUnit, t.[Type] as FoodType from Good as g inner join MeasuringUnit as m on g.IDMeasuringUnit = m.Id inner join FoodType as t on g.IDType = t.Id";
                        using (SqlConnection connn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
                        {
                            connn.Open();
                            using (var cmd = new SqlCommand(get_all_goods, connn))
                            {
                                using (var rd = cmd.ExecuteReader())
                                {
                                    while (rd.Read())
                                    {
                                        var good = new Good();
                                        good.Id = rd.GetInt32(rd.GetOrdinal("Id"));
                                        good.Name = rd.GetString(rd.GetOrdinal("Name"));
                                        good.Energy_kcal = rd.GetInt32(rd.GetOrdinal("Energy_kcal"));
                                        good.IDType = rd.GetInt32(rd.GetOrdinal("IDType"));
                                        goods.Add(good);
                            
                                        var units = new MeasuringUnit();
                                        units.Name = rd.GetString(rd.GetOrdinal("MeasuringUnit"));
                                        measuringUnits.Add(units);

                                        var type = new FoodType();
                                        type.Type = rd.GetString(rd.GetOrdinal("FoodType"));
                                        foodTypes.Add(type);
                                    }
                                }
                            }
                            connn.Close();

                            int index1 = r.Next(1,20);
                            bool itemAdded = false;
                            //var units = new MeasuringUnit();
                            //var type = new FoodType();
                            // Randomly chosing item from list and checking for its type and kcal value
                            #region //Algorithm for random good
                            do
                            {
                                double percantage = (double)((double)carbpercent / (double)100);
                                double result = (double)user_energy_need * (double)percantage;
                                if (goods[index1].IDType == 1 && (goods[index1].Energy_kcal) < result )
                                {
                                    carbs.Add(goods[index1]);
                                    unitcarb.Add(measuringUnits[index1]);
                                    itemAdded = true;
                                    continue;
                                }
                                else
                                {
                                    index1++;
                                }
                            } while (itemAdded == false);

                            // Randomly chosing item from list and checking for its type and kcal value
                            itemAdded = false;
                            do
                            {
                                double percantage = (double)((double)fatpercent / (double)100);
                                double result = (double)user_energy_need * (double)percantage;
                                if (goods[index1].IDType == 2 && (goods[index1].Energy_kcal) < result )
                                {
                                    fats.Add(goods[index1]);
                                    unitfat.Add(measuringUnits[index1]);
                                    itemAdded = true;
                                    continue;
                                }
                                else
                                {
                                    index1++;
                                }
                            } while (itemAdded == false);

                            // Randomly chosing item from list and checking for its type and kcal value
                            itemAdded = false;
                            do
                            {
                                double percantage = (double)((double)carbpercent / (double)100);
                                double result = (double)user_energy_need * (double)percantage;
                                if (goods[index1].IDType == 3 && (goods[index1].Energy_kcal) < result )
                                {
                                    proteins.Add(goods[index1]);
                                    unitprotein.Add(measuringUnits[index1]);
                                    itemAdded = true;
                                    continue;
                                }
                                else
                                {
                                    index1++;
                                }
                            } while (itemAdded == false);
                                #endregion
                        }
                    #endregion
                    }
                    #endregion
                }
            }
            
            #region //getting meal names
            //var query = string.Format("select mn.[Name] as MealName, g.[Name], g.Energy_kcal,g.Energy_kJ, mu.[Name] as MeasuringUnit, t.[Type] as FoodType from Meal as m inner join MealName as mn on m.IDMealName = mn.Id inner join Good as g on m.IDGood = g.Id inner join MeasuringUnit as mu on g.IDMeasuringUnit = mu.Id inner join FoodType as t on g.IDType = t.Id where IDMenu = (select Id from Menu where NumberOfMeals = {0})", NumberOfMeals);
            var query = string.Format("select mn.[Name] as MealName from Meal as m  inner join MealName as mn on m.IDMealName = mn.Id where IDMenu = (select Id from Menu where NumberOfMeals = {0})", NumberOfMeals);
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                using (var cmd = new SqlCommand(query, con))
                {
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var names = new MealName();
                            names.Name = rd.GetString(rd.GetOrdinal("MealName"));
                            mealNames.Add(names);   
                        }
                    }
                }
                con.Close();
            }
            #endregion

            #region //returning info for generatign menu    
            var viewmodels = new ViewModels
            {
                NumberOfMealsInTale = num_of_meals_in_table,
                NumberOfMeals = NumberOfMeals,
                Carbs = carbs,
                Fats = fats,
                Proteins = proteins,
                MealNames = mealNames,
                FoodTypes = foodTypes,
                MeasuringUnitCarb = unitcarb,
                MeasuringUnitFat = unitfat,
                MeasuringUnitProtein = unitprotein
            };
            TempData["MenuItems"] = viewmodels;
            return View(viewmodels);
            
            #endregion
        }        

        public ActionResult SaveMenu(string DateCreated = "")
        {
            //string username = Session["Name"].ToString();
            //string password = Session["Password"].ToString();

            //ViewModels viewmodel = (ViewModels)TempData["MenuItems"];

            //int id;
            //int NumberOfMeals = viewmodel.NumberOfMeals;
            
            //int numberofmealnames = viewmodel.MealNames.Count;


            //string user_id = string.Format("select Id from [User] where Username = {0} and Password = {1}", username, password);
            //using (SqlConnection con1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            //{
            //    con1.Open();
            //    using (SqlCommand cmd = new SqlCommand(user_id, con1))
            //    {
            //        id = (int)cmd.ExecuteScalar();
            //    }
            //    con1.Close();
            //}
            
            //string query = string.Format("insert into Menu (DateCreated, NumberOfMeals, IDUser) values ('{0}',{1},{2})", DateCreated, NumberOfMeals, id);
            //using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            //{
            //    con.Open();
            //    using (SqlCommand cmd = new SqlCommand(query,con))
            //    {
            //        cmd.ExecuteNonQuery();
            //    }
            //    con.Close();
            //}


            //string menu_id = string.Format("select Id from Menu where IDUser = {0} ", id);
            //int MenuId;
            //using (SqlConnection con2 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            //{
            //    con2.Open();
            //    using (SqlCommand cmd = new SqlCommand(menu_id,con2))
            //    {
            //        MenuId = (int)cmd.ExecuteScalar();
            //    }
            //    con2.Close();
            //}

            //List<int> ids = new List<int>();
            //foreach (MealName item in viewmodel.MealNames)
            //{
            //    ids.Add(item.Id);
            //}
            //List<int> carb = new List<int>();
            //foreach (Good item in viewmodel.Carbs)
            //{
            //    carb.Add(item.Id);
            //}
            //List<int> fat = new List<int>();
            //foreach (Good item in viewmodel.Fats)
            //{
            //    fat.Add(item.Id);
            //}

            //List<int> protein = new List<int>();
            //foreach (Good item in viewmodel.Proteins)
            //{
            //    fat.Add(item.Id);
            //}


            //for (int i = 0; i < numberofmealnames; i++)
            //{
            //    string insertCarbInMeal = string.Format("insert into Meal(IDMenu, IDMealName, IDGood) values({0},{1},{2}),({0},{1},{3}),({0},{1},{4})", MenuId, ids[i], carb[0], carb[1], carb[2]);
            //    using (SqlConnection con4 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            //    {
            //        con4.Open();
            //        using (SqlCommand cmd = new SqlCommand(insertCarbInMeal,con4))
            //        {
            //            cmd.ExecuteNonQuery();
            //        }
            //        con4.Close();
            //    }

            //    string insertFatInMeal = string.Format("insert into Meal(IDMenu, IDMealName, IDGood) values({0},{1},{2}),({0},{1},{3}),({0},{1},{4})", MenuId, ids[i], fat[0], fat[1], fat[2]);
            //    using (SqlConnection con5 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            //    {
            //        con5.Open();
            //        using (SqlCommand cmd = new SqlCommand(insertCarbInMeal,con5))
            //        {
            //            cmd.ExecuteNonQuery();
            //        }
            //        con5.Close();
            //    }

            //    string insertProteinInMeal = string.Format("insert into Meal(IDMenu, IDMealName, IDGood) values({0},{1},{2}),({0},{1},{3}),({0},{1},{4})", MenuId, ids[i], protein[0], protein[1], protein[2]);
            //    using (SqlConnection con6 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            //    {
            //        con6.Open();
            //        using (SqlCommand cmd = new SqlCommand(insertCarbInMeal,con6))
            //        {
            //            cmd.ExecuteNonQuery();
            //        }
            //        con6.Close();
            //    }

            //}
            var validateviewmodel = new ViewModels();
            string ErrorMessage = "Menu Saved!";
            validateviewmodel.ErrorMessage = ErrorMessage;
                
            return View(validateviewmodel);
        }
    }
}