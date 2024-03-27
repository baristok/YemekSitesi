using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace barizmir
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string userName = Session["UserName"].ToString();
                Label2.Text = "Hoşgeldiniz, " + userName + "!";
            }
            else
            {
                // Kullanıcı girişi yapılmamışsa yapılacak işlemler
                Response.Redirect("Login.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("");
            string cmd = "insert into tblrandevu(NameSurname,phoneNumber,Emaill,kisi,date) values (@namee,@phone,@emaill,@kisi,@date)";
            SqlCommand com = new SqlCommand(cmd, con);
            com.Parameters.AddWithValue("@namee", TextBox1.Text);
            com.Parameters.AddWithValue("@phone", TextBox2.Text);
            com.Parameters.AddWithValue("@emaill", TextBox3.Text);
            com.Parameters.AddWithValue("@kisi", ddlKacKisi.SelectedValue);
            com.Parameters.AddWithValue("@date", TextBox4.Text);
            con.Open();
            com.ExecuteNonQuery();
            Label1.Text = ("Randevunuz Başarıyla Oluşturulmuştur. Bizi Tercih Ettiğiniz için Teşekkürler");
            con.Close();
        }
    }
}