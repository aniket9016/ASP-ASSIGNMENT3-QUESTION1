using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    SqlConnection con;
    String str;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        String gen = rbMale.Checked ? rbMale.Text : rbFemale.Text;
        str="INSERT INTO USERS VALUES('"+txtName.Text+ "','" +txtEmail.Text+ "','" +gen+ "','" +txtDOB.Text + "','" + ddlCity.SelectedValue+ "','" +txtPassword.Text +"',null)";
        con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ASSIGNMENTQUESTION1;User ID=sa;Password=sa123");
        con.Open();
        cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();
        con.Close();
        cmd.Dispose();
        con.Dispose();
        Response.Redirect("Login.aspx");
    }
}