using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dijabetes
{
    public partial class CombinationDefinition : System.Web.UI.Page
    {
        int NumOfMeals;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            string query = string.Format("select m.Id as ID, m.[Name] as MealName, c.CarbPerCent as Carb, c.FatPerCent as Fat, c.ProteinPerCent as Protein, c.TotalPer from CombDefinition as c join MealName as m on c.MealNameID = m.Id where MealCombinationID = {0}", NumOfMeals);
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string query = "select Id from MealCombination where NumOfMeals = @NumOfMeals";
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NumOfMeals", int.Parse(TextBox1.Text));
                    con.Open();
                    NumOfMeals = (int)cmd.ExecuteScalar();
                    //num of meals is id of MealsCombination in this case
                    con.Close();
                }
            }
            string query2 = "Select DateCreated from MealCombination where NumOfMeals = @NumOfMeals";
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query2, con))
                {
                    cmd.Parameters.AddWithValue("@NumOfMeals", int.Parse(TextBox1.Text));

                    TextBox2.Text = cmd.ExecuteScalar().ToString();
                }
                con.Close();
            }

            string query3 = "Select ValidUntil from MealCombination where NumOfMeals = @NumOfMeals";
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query3, con))
                {
                    cmd.Parameters.AddWithValue("@NumOfMeals", int.Parse(TextBox1.Text));

                    TextBox3.Text = cmd.ExecuteScalar().ToString();
                }
                con.Close();
            }
            this.BindGrid();
        }
        
        

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int name = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            int perfat = Convert.ToInt32((row.FindControl("txtFat") as TextBox).Text);
            int percarb = Convert.ToInt32((row.FindControl("txtPerCarb") as TextBox).Text);
            int perprotein = Convert.ToInt32((row.FindControl("txtPerProtein") as TextBox).Text);
            int totalper = Convert.ToInt32((row.FindControl("txtTotalPer") as TextBox).Text);

            //int IdMealName;
            //string queryForMealNameId = string.Format("select MealName.Id from MealName where Name ={0}", name);

            //using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            //{
            //    using (SqlCommand cmd = new SqlCommand(queryForMealNameId,con))
            //    {
            //        IdMealName = (int)cmd.ExecuteScalar();
            //    }
            //}


            string query = string.Format("UPDATE CombDefinition SET FatPerCent=@FatPerCent, CarbPerCent=@CarbPerCent,ProteinPerCent=@ProteinPerCent,TotalPer=@TotalPer WHERE MealNameID=", name);
            
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@FatPerCent", perfat);
                    cmd.Parameters.AddWithValue("@CarbPerCent", percarb);
                    cmd.Parameters.AddWithValue("@ProteinPerCent", perprotein);
                    cmd.Parameters.AddWithValue("@TotalPer", totalper);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
           
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

       

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

       
    }
}