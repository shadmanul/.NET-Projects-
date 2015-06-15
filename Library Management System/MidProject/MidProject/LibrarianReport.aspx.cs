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
    public partial class LibrarianReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_id"] == null || !Convert.ToString(Session["status"]).Equals("Librarian"))
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportQueries("select b.book_title,COUNT(b.book_id) as 'No of Books' from BooksOutOnLoan bl, Books b where b.book_id=bl.book_id and bl.date_issued = '" + Calendar1.SelectedDate + "' group by b.book_title");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ReportQueries("select b.book_title,COUNT(b.book_id) as 'No of Books' from BooksOutOnLoan bl, Books b where b.book_id=bl.book_id and bl.date_returned = '" + Calendar2.SelectedDate + "' group by b.book_title");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ReportQueries("select b.book_title,COUNT(b.book_id) as 'No of Books' from BooksOutOnLoan bl, Books b where b.book_id=bl.book_id and bl.date_issued between '" + DateTime.Now.Date.Subtract(TimeSpan.FromDays(7)) + "' and '" + DateTime.Now.Date + "' group by b.book_title");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ReportQueries("select b.category_name,COUNT(b.book_id) as 'No of Books' from BooksOutOnLoan bl, Books b where b.book_id=bl.book_id and bl.date_returned is null group by b.category_name");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ReportQueries("select b.book_title,COUNT(b.book_id) as 'No of Books Borrowed' from BooksOutOnLoan bl, Books b where b.book_id=bl.book_id group by b.book_title order by 'No of Books Borrowed' desc");
        }
        

        protected void Button6_Click(object sender, EventArgs e)
        {
            ReportQueries("select b.book_title,COUNT(b.book_id) as 'No of Books' from BooksOutOnLoan bl, Books b where b.book_id=bl.book_id and bl.member_id='" + MemberIDDDL.SelectedValue + "' and bl.date_issued between '" + FromDateTB.Text + "' and '" + ToDateTB.Text + "' group by b.book_title");
        }
        public void ReportQueries(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    ReportGridView.DataSource = reader;
                    ReportGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            ReportQueries("select SUM(total_fine) as 'Total Due Fine' from Members ");
        }
    }
}