using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace MidProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from LoginInfo where member_id='"
                        + UsernameTB.Text + "' and password='" + PasswordTB.Text + "'", con);
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Session["status"] = Reader.GetString(2);
                        Session["member_id"] = Reader.GetString(0);
                        if (!Session["status"].Equals("Librarian"))
                            Response.Redirect("MemberHome.aspx");
                        else
                            Response.Redirect("LibrarianAddBook.aspx");
                    }
                    else
                    {
                        MsgLabel.Text = "Incorrect Username/Password";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('"+ex.Message+"');</script>");
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx?value="+SearchTB.Text);
        }
    }
}