using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Properties;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class DBConnTest002 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBConn.GetConnection();
            SqlCommand sc;
            SqlDataAdapter sa;
            string sql = "";

            try
            {
                sql = "SELECT BOARD_TITLE, BOARD_CONTENT FROM TB_BOARD WHERE BOARD_TITLE LIKE '%효%'";
                conn.Open();
                sc = new SqlCommand();
                sc.Connection = conn;
                sc.CommandText = sql;
                sc.CommandType = CommandType.Text;

                sa = new SqlDataAdapter();
                sa.SelectCommand = sc;

                DataSet ds = new DataSet();
                sa.Fill(ds, "TB_BOARD");


                foreach (DataRow row in ds.Tables["TB_BOARD"].Rows)
                {
                    // selectBox 에 넣는 데이터
                    ListItem item = new ListItem();
                    item.Text = row["BOARD_TITLE"].ToString();
                    item.Value = row["BOARD_CONTENT"].ToString();
                    
                    Lists.Items.Add(item);
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally 
            {
                conn.Close();
            }

        }
    }
}