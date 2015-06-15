using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace MidProject
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegButton_Click(object sender, EventArgs e)
        {
            InsertForRegistration("insert into LoginInfo values ('"+MemberidTB.Text+"','"
                +PasswordTB.Text+"','"+StatusDDL.SelectedValue+"')");
            InsertForRegistration("insert into Members values ('"
                +MemberidTB.Text+"','"+FirstnameTB.Text+"','"+MiddlenameTB.Text+"','"
                +LastnameTB.Text+"','"+GenderDDL.SelectedValue.ToString()+"','"
                +AddressTB.Text+"','"+PhoneTB.Text+"','"+EmailTB.Text+"',default)");
        }

        private void InsertForRegistration(string query)
        {
            string ConString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    int no = cmd.ExecuteNonQuery();
                    if (no > 0)
                        labelMsg.Text = "Registration Successful";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('"+ex.Message+"');</script>");
            }
        }
    }
}