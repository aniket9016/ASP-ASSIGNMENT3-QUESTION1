using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    String str;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rd;
    String pass = "";
    static String path = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    public void loadData()
    {
        con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ASSIGNMENTQUESTION1;User ID=sa;Password=sa123");
        str = "SELECT * FROM USERS WHERE ID=" + Session["ID"];
        con.Open();
        cmd = new SqlCommand(str, con);
        rd = cmd.ExecuteReader();
        if (rd.HasRows)
        {
            rd.Read();
            Label1.Text = "Name:- " + rd["NAME"];
            Label2.Text = "Email:- " + rd["EMAIL"];
            Label3.Text = "Gender:- " + rd["GENDER"];
            Label4.Text = "City:- " + rd["CITY"];
            Label5.Text = "DOB:- " + rd["DOB"];
            TextBox1.Text = rd["PASSWORD"].ToString();
            pass = rd["PASSWORD"].ToString();
            path = rd["IMAGE"].ToString();
        }else
        {
            Response.Redirect("Login.aspx");
        }
        con.Close();
        con.Dispose();
        cmd.Dispose();
        rd.Close();
        if (path.Length != 0)
        {
            FileUpload1.Visible = false;
            Image1.ImageUrl = path;
        }else
        {
            Image1.Visible = false;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            HttpPostedFile hp = FileUpload1.PostedFile;
            path = "./Profile/" + hp.FileName;
            hp.SaveAs(Server.MapPath("./Profile/" + hp.FileName).ToString());
        }
        str = "UPDATE USERS SET PASSWORD='" + TextBox1.Text + "',IMAGE ='" + path + "' WHERE ID=" + Session["ID"];
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