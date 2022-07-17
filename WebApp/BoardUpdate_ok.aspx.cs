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
    public partial class BoardUpdate_ok : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //string board_id = Request.Form["Board_Id"].ToString();
            if (string.IsNullOrWhiteSpace(Request.Form["Board_Id"].ToString()))
            {
                Response.Redirect("BoardList.aspx");
                return;
            }
            string board_id = Request.Form["Board_Id"].ToString();

            if (string.IsNullOrEmpty(Request.Form["Board_Title"].ToString()))
            {
                Response.Redirect("BoardList.aspx");
                return;
            }
            string board_title = Request.Form["Board_Title"].ToString();


            if (string.IsNullOrEmpty(Request.Form["Board_Content"].ToString()))
            {
                Response.Redirect("BoardList.aspx");
                return;
            }
            string board_content = Request.Form["Board_Content"].ToString();
            /*
            Response.Write(board_id);
            Response.Write(board_title);
            Response.Write(board_content);
            */
            string pageNum = Request.Form["PageNum"].ToString();
            
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());

                conn.Open();

                SqlCommand sc = new SqlCommand();

                string sql = string.Format("UPDATE TB_BOARD SET BOARD_TITLE = '{0}', BOARD_CONTENT = '{1}' WHERE BOARD_ID = {2}", board_title, board_content, board_id);

                sc.Connection = conn;
                sc.CommandText = sql;
                sc.CommandType = CommandType.Text;

                int result = sc.ExecuteNonQuery();

                conn.Close();

                // result 반환 
                if (result > 0)
                {
                    bool flag = true;
                    string url = "BoardDetail.aspx?board_id=" + board_id +"&pageNum="+pageNum;
                    Response.Redirect(url);
                    Response.Write(alertMsg(true));
                }
                else
                {
                    // 에러페이지
                    Response.Redirect("");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            
        }
        protected string alertMsg(bool flag)
        {
            string result = "";
            if (flag)
            {
                result += "<script language='javascript'>" +
                      "alert('수정이 완료되었습니다.')" +
                      "</script>";
            }
            else
            {
                result += "<script language='javascript'>" +
                "alert('내용을 입력하세요')" +
                "</script>";
            }


            return result;
        }
    }
}