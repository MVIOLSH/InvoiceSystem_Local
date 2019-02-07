using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceSystem.BLL;

namespace InvoiceSystem.DAL
{
    class loginDAL
    {
        // Static string to connect BD
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool loginCheck(loginBLL l)
        {
            //creaate bool var and set its value to false and return it
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL query to check login

                string sql = "SELECT * FROM tbl_users WHERE username=@username AND password=@password AND user_type=@user_type";

                //SQL command to pass value

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                cmd.Parameters.AddWithValue("@user_type", l.user_type);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Login Succesfull");
                    isSuccess = true;
                }
                else
                {
                    //MessageBox.Show("Login failed");
                    isSuccess = false;
                }

            }

            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            finally
            {
                conn.Close();
            }


            return isSuccess;
        }

    }
}
