using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace barizmir
{
    public partial class User : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name from tblUsers where Email= @email and Password = @password ",con);
            cmd.Parameters.AddWithValue("@email", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblUsers");
            SqlDataReader oku = cmd.ExecuteReader();
            if (oku.Read())
            {
                string userName = oku["Name"].ToString();
                Session["UserName"] = userName;
                Label1.Text = "Doğrulama başarılı, lütfen bekleyiniz...";
                Thread.Sleep(5000);
                Response.Redirect("main.aspx");
            }
            else
            {
                Label1.Text = "Hatalı Kullanıcı, Lütfen Kayıt Olunuz ya da Bilgilerinizi Kontrol Ediniz!!";
            }


            oku.Close();
            con.Close();
            


        }
        
    }
}