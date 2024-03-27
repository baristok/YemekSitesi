using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace barizmir
{
    public partial class register : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("");
            string cmd = "insert into tblUsers(Name,Email,Password) values (@name,@email,@password)";
            SqlCommand com = new SqlCommand(cmd, con);
            com.Parameters.AddWithValue("@name", TextBox3.Text);
            com.Parameters.AddWithValue("@email", TextBox4.Text);
            com.Parameters.AddWithValue("@password", TextBox5.Text);
            con.Open();
            com.ExecuteNonQuery();
            Label1.Text = ("Kaydınız Başarıyla Oluşturulmuştur Giriş Yapınız.");
            con.Close();




        }
    }
}