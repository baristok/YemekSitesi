using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace barizmir
{
    public partial class membership : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string userName = TextBox1.Text;
            string email = TextBox2.Text;
            string oldPassword = TextBox3.Text;
            string newPassword = TextBox4.Text;

            using (SqlConnection connection = new SqlConnection(""))
            {
                connection.Open();

                
                string updateQuery = "UPDATE tblUsers SET Password = @NewPassword WHERE Name = @UserName AND Email = @Email AND Password = @OldPassword";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@OldPassword", oldPassword);

                    
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        Label1.Text= ("Şifre Başarıyla Değiştirildi.");
                        
                        Response.Redirect("User.aspx");
                    }
                    else
                    {

                        Label1.Text = ("Bilgileriniz Eşleşmiyor. Lütfen Tekrar Deneyiniz!!");
                        
                    }
                }
            }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("main.aspx");
        }
    }
}