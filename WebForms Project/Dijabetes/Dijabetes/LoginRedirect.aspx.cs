using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;
using System.IO;

namespace Dijabetes
{

    public partial class LoginRedirect : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
 
        protected void Page_Load(object sender, EventArgs e)
        {
            usernametxt.ForeColor = System.Drawing.Color.Green;
            usernametxt.Text = Session["Name"].ToString(); //calling stored username
        }

        protected void LogOutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        private void ExportToCSV()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string filename = "Users_" + DateTime.Today + ".xls";
            StringWriter sr = new StringWriter();
            HtmlTextWriter htmltextwriter = new HtmlTextWriter(sr);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwriter);
            Response.Write(sr.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
        protected void MeasuringUnitsbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeasuringUnit.aspx");
        }

        protected void Goodbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Goods.aspx");
        }

        protected void Mealsbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Meals.aspx");
        }

        protected void MealCombbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CombinationDefinition.aspx");
        }


        protected void Exportbtn_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }
    }
}