using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApp
{
    public partial class BoardDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int board_id = int.Parse(Request.QueryString["board_id"].ToString());

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());
            conn.Open();
            SqlCommand sc = new SqlCommand();

            sc.Connection = conn;

            
            string sql = string.Format("UPDATE TB_BOARD SET DEL_CHECK = 1 WHERE BOARD_ID = {0}", board_id);

            sc.CommandText = sql;
            sc.CommandType = CommandType.Text;

            int result = sc.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
            {
                Response.Redirect("BoardList.aspx");
            }
            else
            {
                // 에러 페이지
                Response.Redirect("");
            }                

            
        }
    }
}