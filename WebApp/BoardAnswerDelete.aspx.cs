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
    public partial class BoardAnswerDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int board_id = int.Parse(Request.QueryString["board_id"].ToString());
            string pageNum = Request.QueryString["pageNum"].ToString();
            string answer_id = Request.QueryString["answer_id"].ToString();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());
            conn.Open();
            SqlCommand sc = new SqlCommand();

            sc.Connection = conn;


            string sql = string.Format("DELETE FROM TB_ANSWER WHERE ANSWER_ID={0}", answer_id);

            sc.CommandText = sql;
            sc.CommandType = CommandType.Text;

            int result = sc.ExecuteNonQuery();

            conn.Close();
            string url = "BoardDetail.aspx?board_id=" + board_id + "&pageNum=" + pageNum;
            if (result == 1)
            {
                Response.Redirect(url);
            }
            else
            {
                // 에러 페이지
                Response.Redirect("");
            }
        }
    }
}