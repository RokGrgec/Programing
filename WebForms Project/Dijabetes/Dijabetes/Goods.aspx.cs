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
    public partial class Goods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            
            string query = "SELECT * FROM Good";
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

        protected void Insert(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string energykcal = txtEnergyInKcal.Text;
            string energykj = txtEnergyInkJ.Text;
            int typeid = Convert.ToInt32(txtType.Text);
            int measuringunitid = Convert.ToInt32(txtMeasuringUnit.Text);
            txtName.Text = "";
            txtEnergyInKcal.Text = "";
            txtEnergyInkJ.Text = "";

            string query = "INSERT INTO Good VALUES(@Name, @Energy_kcal, @Energy_kJ, @IDType, @IDMeasuringUnit)";
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Energy_kcal", energykcal);
                    cmd.Parameters.AddWithValue("@Energy_kJ", energykj);
                    cmd.Parameters.AddWithValue("@IDType", typeid);
                    cmd.Parameters.AddWithValue("@IDMeasuringUnit", measuringunitid);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }


        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("test1");
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string name = (row.FindControl("txtName") as TextBox).Text;
            int energykcal = Convert.ToInt32((row.FindControl("txtEnergy_kcal") as TextBox).Text);
            int energykj = Convert.ToInt32((row.FindControl("txtEnergy_kJ") as TextBox).Text);
            int typeid = Convert.ToInt32((row.FindControl("txtIDType") as TextBox).Text);
            int measuringunitid = Convert.ToInt32((row.FindControl("txtIDMeasuringUnit") as TextBox).Text);

            string query = "UPDATE Good SET Name=@Name, Energy_kcal=@Energy_kcal, Energy_kJ = @Energy_kJ, IDType = @IDType, IDMeasuringUnit=@IDMeasuringUnit WHERE Id=@Id";
           
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Energy_kcal", energykcal);
                    cmd.Parameters.AddWithValue("@Energy_kJ", energykj);
                    cmd.Parameters.AddWithValue("@IDType", typeid);
                    cmd.Parameters.AddWithValue("@IDMeasuringUnit", measuringunitid);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
            System.Diagnostics.Debug.WriteLine("test1");
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int goodId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM Good WHERE Id=@Id";
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Id", goodId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}