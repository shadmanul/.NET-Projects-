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
    public partial class MemberHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_id"] == null || Convert.ToString(Session["status"]).Equals("Librarian"))
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BorrowedBooksQueries("select l.*, b.book_title from BooksOutOnLoan l, Books b where l.book_id=b.book_id and l.member_id='" + Session["member_id"] + "'");
                AllBooksQueries("select b.*, a.name from Books b, BooksByAuthor ba, Authors a where b.book_id=ba.book_id and a.author_id=ba.author_id");
            }
        }

        private void AllBooksQueries(string p)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(p, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BorrowedMsgLabel.Text = "Books Borrowed By " + Session["member_id"];
                        AllBooksGridView.DataSource = reader;
                        AllBooksGridView.DataBind();
                    }
                    else
                    {
                        BorrowedMsgLabel.Text = "You Don't Have Any Books From Library";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('" + ex.Message + "');</script>");
            }
        }
        private void BorrowedBooksQueries(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BorrowedMsgLabel.Text = "Books Borrowed By " + Session["member_id"];
                        BorrowedBooksGridView.DataSource = reader;
                        BorrowedBooksGridView.DataBind();
                    }
                    else
                    {
                        BorrowedMsgLabel.Text = "You Don't Have Any Books From Library";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('" + ex.Message + "');</script>");
            }
        }
    }
}