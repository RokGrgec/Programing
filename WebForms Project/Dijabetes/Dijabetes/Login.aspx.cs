using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dijabetes__
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string check = "select count(*) from Admin where Username= '" + nametxt.Text + "'and Password = '" + passtxt.Text + "' ";
            SqlCommand com = new SqlCommand(check, con);
            con.Open();

            Session["Name"] = nametxt.Text; //Session stores values globaly - this one is used on redirect page when rendering Hello + username message
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if (temp == 1)
            {
                Response.Redirect("LoginRedirect.aspx");
            }
            else
            {
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Your username or password is invalid";
            }
        }
    }
}