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
    public partial class LibrarianHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_id"] == null || !Convert.ToString(Session["status"]).Equals("Librarian"))
            {
                Response.Redirect("Login.aspx");
            }
            ViewTable("Select * from Books", BookGridView);
            ViewTable("Select * from Authors", AuthorGridView);
            ViewTable("Select ba.book_id, b.book_title, ba.author_id,a.name from Authors a, BooksByAuthor ba, Books b where b.book_id=ba.book_id and a.author_id=ba.author_id order by b.book_title", BookAuthorGridView);
        }

        public void ViewTable(string query, GridView AllGridView)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    AllGridView.DataSource = reader;
                    AllGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('" + ex.Message + "');</script>");
            }
        }

        protected void AddBookButton_Click(object sender, EventArgs e)
        {
            InsertValue("insert into books values ('"+CategoryTB.Text+"','"
                + Convert.ToInt32(NoOfCopiesTB.Text) + "','" + BookTitleTB.Text + "','" 
                + BookEditionTB.Text + "')");
            ViewTable("Select * from Books", BookGridView);
        }
        
        protected void AddAuthorButton_Click(object sender, EventArgs e)
        {
            InsertValue("insert into Authors (name) values ('" + AuthorTB.Text + "')");
            ViewTable("Select * from Authors", AuthorGridView);
        }

        protected void RelateButton_Click(object sender, EventArgs e)
        {
            InsertValue("insert into BooksByAuthor values ('" + Convert.ToInt32(AuthorIdDDl.SelectedValue) + "','" 
                + Convert.ToInt32(BookIdDDl.SelectedValue) + "')");
            ViewTable("Select ba.book_id, b.book_title, ba.author_id,a.name from Authors a, BooksByAuthor ba, Books b where b.book_id=ba.book_id and a.author_id=ba.author_id order by b.book_title", BookAuthorGridView);
        }

        private void InsertValue(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('" + ex.Message + "');</script>");
            }
        }
    }
}