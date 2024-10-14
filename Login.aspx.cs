using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    String str;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ASSIGNMENTQUESTION1;User ID=sa;Password=sa123");
        str = "SELECT * FROM USERS WHERE EMAIL='" + txtEmail.Text + "' AND PASSWORD='" + txtPwd.Text + "'";
        con.Open();
        cmd = new SqlCommand(str, con);
        rd = cmd.ExecuteReader();
        if (rd.HasRows)
        {
            rd.Read();
            Session["id"] = rd["ID"];
            Response.Redirect("Home.aspx");
        }else
        {
            Response.Write("invalid user credentials");
        }
        con.Close();
        rd.Close();
        cmd.Dispose();
        con.Dispose();

    }
}