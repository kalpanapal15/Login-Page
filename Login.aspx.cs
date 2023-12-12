using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=Login database; Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("Select * from Users where Username=@Username and Password=@Password", conn);
            cmd.Parameters.AddWithValue("@Username", TxtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", TxtPassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Users");
            if(ds.Tables["Users"].Rows.Count==0)
            {
                Response.Write("Invalid user");
            }
            else
            {
                Response.Redirect("Dashboard.aspx");
            }
        }
    }
}