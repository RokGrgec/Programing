using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Dijabetes__
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string Gender;
        string Activity;
        string DiabType;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Register.mdf;Integrated Security=True;"); //connection to database
   
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string check = "select count(*) from RegisterInfo where Email = '" + emailtxt.Text + "' "; // sql querry for checking uniquenes of email/user
            
            try
            {
                con.Open(); // opening connection to database
                SqlCommand com2 = new SqlCommand(check, con); // initializing the select querry to database
                com2.ExecuteNonQuery(); // executing select the querry

                int IsNotUnique = Convert.ToInt32(com2.ExecuteScalar().ToString()); // converting the result of select querry to int (if the email exists in the database the value will be 1/true)
                if (IsNotUnique == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "EmptyFields", "alert('" + "User already exists whit that email." + "');", true);
                }
                else if (nametxt.Text == "" || passtxt.Text == "" || emailtxt.Text == "" || (RbtnType1.Selected || RbtnType2.Selected) == false
                    || (RbtnActivity1.Selected || RbtnActivity2.Selected || RbtnActivity3.Selected) == false || (RbtnGender1.Selected || RbtnGender2.Selected) == false) // checking that all fields are filled/checked
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "EmptyFields", "alert('" + "All Fields Are Compulsory" + "');", true);
                }
                else
                {
                    // checking for radiobuttons checked and generating data based on user's choice
                    if (RbtnActivity1.Selected) Activity = "Rarely";
                    else if (RbtnActivity2.Selected) Activity = "Occasionally";
                    else if (RbtnActivity3.Selected) Activity = "Frequently";
                    
                    if (RbtnGender1.Selected) Gender = "Male";
                    else if (RbtnGender2.Selected) Gender = "Female";
                    
                    if (RbtnType1.Selected) DiabType = "Type 1";
                    else if (RbtnType2.Selected) DiabType = "Type 2";

                    string ins = "Insert into RegisterInfo(Name, Email, Password, Age, Height, Weight, DiabetesType, Gender, Activity) values ('" + nametxt.Text + "', '" + emailtxt.Text + "' ,'"
                + passtxt.Text + "' ,'" + agetxt.Text + "' ,'" + heighttxt.Text + "' ,'" + weighttxt.Text + "' ,'" + DiabType + "' ,'" + Gender + "' ,'" + Activity + "')"; // sql querry for inserting new user into database

                    SqlCommand com1 = new SqlCommand(ins, con); // initializing the insert querry to database
                    com1.ExecuteNonQuery(); // executing the insert querry
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "DataInserted", "alert('Account Created Succesfully! You Can Now Login To Your Account');window.location='Login.aspx';", true); // pop-out message upon completed insert, returns to Login.aspx site
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "EmptyFields", "alert('" + ex.Message + "');", true);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close(); // closing connection to database
                }
            }

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}