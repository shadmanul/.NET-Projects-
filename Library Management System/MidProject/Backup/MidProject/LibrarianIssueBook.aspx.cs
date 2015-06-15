using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MidProject
{
    public partial class LibrarianIssueBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_id"] == null || !Convert.ToString(Session["status"]).Equals("Librarian"))
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Cache["dataset"] == null)
                {
                    LoadDataFromDatabase();
                }
                else
                {
                    LoadDataFromCache();
                }
            }
        }

        protected void BooksOutOnLoanGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Cache["dataset"] != null)
            {
                DataSet ds = (DataSet)Cache["dataset"];
                DataRow dr = ds.Tables["BooksOutOnLoan"].Rows.Find(e.Keys["book_borrowing_id"]);
                dr.Delete();
                LoadDataFromCache();
            }
        }

        protected void BooksOutOnLoanGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            BooksOutOnLoanGridView.EditIndex = e.NewEditIndex;
            LoadDataFromCache();
        }

        protected void BooksOutOnLoanGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["dataset"] != null)
            {
                DataSet ds = (DataSet)Cache["dataset"];
                DataRow dr = ds.Tables["BooksOutOnLoan"].Rows.Find(e.Keys["book_borrowing_id"]);
                DropDownList ddl = (DropDownList)BooksOutOnLoanGridView.Rows[e.RowIndex].FindControl("DropDownList1");
                Calendar cal = (Calendar)BooksOutOnLoanGridView.Rows[e.RowIndex].FindControl("Calendar1");
                string status = GetStatus("select status from LoginInfo where member_id ='"+dr["member_id"]+"'");
                if (cal.SelectedDate != null)
                {
                    dr["date_returned"] = cal.SelectedDate;
                    if (cal.SelectedDate < DateTime.Now.Date)
                    {
                        dr["date_returned"] = DBNull.Value;
                    }
                }
                if (dr["date_returned"] != DBNull.Value)
                {
                    AddReturnedBook("select no_of_copies from books where book_id = " + BookIDDDL.SelectedValue, Convert.ToInt32(dr["book_id"]));
                    dr["paid"] = ddl.SelectedValue;
                    if (status == "Student")
                    {
                        if (dr["paid"].ToString().Equals("No"))
                        {
                            DateTime dre = (DateTime)dr["date_returned"];
                            DateTime dis = (DateTime)dr["date_issued"];
                            TimeSpan ts = dre.Subtract(dis);
                            if (ts.Days > 7)
                            {
                                dr["total_fine"] = (ts.Days - 7) * 10;
                            }
                        }
                        else
                        {
                            dr["total_fine"] = 0;
                        }
                    }
                    else
                    {
                        dr["total_fine"] = 0;
                    }
                }
                int sumFine = Convert.ToInt32(ds.Tables["BooksOutOnLoan"].Compute("Sum(total_fine)", "member_id = '"+ dr["member_id"]+"'"));
                InsertIssue("update Members set total_fine = " + sumFine + " where member_id ='" + dr["member_id"] + "'");
                Cache["dataset"] = ds;
                BooksOutOnLoanGridView.EditIndex = -1;
                LoadDataFromCache();
            }
        }

        protected void BooksOutOnLoanGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BooksOutOnLoanGridView.EditIndex = -1;
            LoadDataFromCache();
        }
        public void LoadDataFromDatabase()
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from BooksOutOnLoan", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "BooksOutOnLoan");
            ds.Tables["BooksOutOnLoan"].PrimaryKey = new DataColumn[] { ds.Tables["BooksOutOnLoan"].Columns["book_borrowing_id"] };

            Cache.Insert("adapter", adapter, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            Cache.Insert("dataset", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

            BooksOutOnLoanGridView.DataSource = ds.Tables["BooksOutOnLoan"];
            BooksOutOnLoanGridView.DataBind();
        }
        public void LoadDataFromCache()
        {
            DataSet ds = (DataSet)Cache["dataset"];
            BooksOutOnLoanGridView.DataSource = ds.Tables["BooksOutOnLoan"];
            BooksOutOnLoanGridView.DataBind();
        }

        protected void SaveDatabaseButton_Click(object sender, EventArgs e)
        {
            if (Cache["dataset"] != null)
            {
                DataSet ds = (DataSet)Cache["dataset"];
                SqlDataAdapter adapter = (SqlDataAdapter)Cache["adapter"];
                adapter.Update(ds, "BooksOutOnLoan");
            }
        }
        public string GetStatus(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    string status = cmd.ExecuteScalar().ToString();
                    return status;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('" + ex.Message + "');</script>");
                return null;
            }
        }
        public void InsertIssue(string query)
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

        protected void ClearCacheButton_Click(object sender, EventArgs e)
        {
            if (Cache["dataset"] != null)
            {
                Cache.Remove("dataset");
                Cache.Remove("adapter");
            }
        }

        protected void AddIssueButton_Click(object sender, EventArgs e)
        {


            if (MemberIDTB.Text == "")
            {
                string status = GetStatus("select status from LoginInfo where member_id ='" + MemberIDDDL.SelectedValue + "'");
                int NoOfBookBorrowed = CountBookForPerUser("select count(book_borrowing_id) from BooksOutOnLoan where member_id='"
                    + MemberIDDDL.SelectedValue + "'");
                if (NoOfBookBorrowed < 3 || !status.Equals("Student"))
                {
                    int i = RemoveIssuedBook("select no_of_copies from books where book_id = " + BookIDDDL.SelectedValue, BookIDDDL.SelectedValue);
                    if (i > 1)
                    {
                        InsertIssue("insert into BooksOutOnLoan (book_id,member_id,date_issued) values ("
                            + BookIDDDL.SelectedValue + ",'" + MemberIDDDL.SelectedValue + "','" + IssueCalendar.SelectedDate + "')");
                    }
                    else
                    {
                        Msglabel.Text = "Stock Finished";
                    }
                }
                else
                {
                    Msglabel.Text = "User Already Borrowed 3 Books";
                }
            }
            else
            {
                int NoOfBookBorrowed = CountBookForPerUser("select count(book_borrowing_id) from BooksOutOnLoan where member_id='"
                    + MemberIDDDL.SelectedValue + "'");
                if (NoOfBookBorrowed < 3)
                {
                    int i = RemoveIssuedBook("select no_of_copies from books where book_id = " + BookIDDDL.SelectedValue, BookIDDDL.SelectedValue);
                    if (i > 1)
                    {
                        InsertIssue("insert into BooksOutOnLoan (book_id,member_id,date_issued) values ('"
                            + BookIDDDL.SelectedValue + "','" + MemberIDTB.Text + "','" + IssueCalendar.SelectedDate + "')");
                    }
                    else
                    {
                        Msglabel.Text = "Stock Finished";
                    }
                }
                else
                {
                    Msglabel.Text = "User Already Borrowed 3 Books";
                }
            }
            if (Cache["dataset"] != null)
            {
                DataSet ds = (DataSet)Cache["dataset"];
                SqlDataAdapter adapter = (SqlDataAdapter)Cache["adapter"];
                adapter.Update(ds, "BooksOutOnLoan");
            }
            this.LoadDataFromDatabase();
        }

        private int RemoveIssuedBook(string sql, string book_id)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    InsertIssue("update books set no_of_copies = "+(i-1)+" where book_id="+book_id);
                    return i;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('" + ex.Message + "');</script>");
                return 1;
            }
        }
        private void AddReturnedBook(string sql, int book_id)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    InsertIssue("update books set no_of_copies = " + (i + 1) + " where book_id=" + book_id);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('" + ex.Message + "');</script>");
            }
        }

        private int CountBookForPerUser(string p)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(p, con);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    return i;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('" + ex.Message + "');</script>");
                return 0;
            }
        }
        
    }
}