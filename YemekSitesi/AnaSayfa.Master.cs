using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace barizmir
{
    public partial class AnaSayfa : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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