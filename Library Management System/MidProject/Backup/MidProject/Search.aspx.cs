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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Request.QueryString["value"];
            if (s == string.Empty)
            {
                SearchQueries("select * from books");
            }
            else
            {
                SearchQueries("select * from Books where book_title like '%" + s + "%'");
            }
        }

        protected void CategoryButton_Click(object sender, EventArgs e)
        {
            SearchQueries("select b.* from Books b where b.category_name='" + CategoryDDL.SelectedValue + "'");
        }

        

        protected void NameButton_Click(object sender, EventArgs e)
        {
            SearchQueries("select * from Books where book_title like '%" + NameTB.Text + "%'");
        }

        protected void AuthorButton_Click(object sender, EventArgs e)
        {
            SearchQueries("select b.book_title as Title,b.no_of_copies as 'Total Copies', a.* from Books b, BooksByAuthor ba, Authors a where b.book_id=ba.book_id and a.author_id=ba.author_id and a.name like '%"
                + AuthorTB.Text + "%'");
        }
        private void SearchQueries(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/JavaScript'>alert('"+ex.Message+"');</script>");
            }
        }

        protected void MemberButton_Click(object sender, EventArgs e)
        {
            SearchQueries("select * from Members where member_id = '" + MemberIDDDL.SelectedValue + "'");
        }
    }
}