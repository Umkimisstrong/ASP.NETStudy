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
    public partial class BoardAnswerInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void insertBtn_Click(object sender, EventArgs e)
        {

            string board_id = "";
            string user_id = "";
            string pageNum = "";
            string answer_content = "";
            string reply_id = "";
            try
            {
                // 이전 페이지 : BoardDetail.aspx 로 부터 넘어온 데이터 수신
                board_id = Request.QueryString["board_id"].ToString();
                pageNum = Request.QueryString["pageNum"].ToString();
                reply_id = Request.QueryString["reply_id"].ToString();

                if (Page.Session["userid"] == null)
                    Response.Redirect("BoardLogin2.aspx");

                user_id = Page.Session["userid"].ToString();

                
                answer_content = Answer_Content.Text;

                if (answer_content.Equals("") || answer_content.Substring(0, 1).Equals(" "))
                {
                    Response.Write(alertMsg());
                    return;
                }

                //Response.Write("바보");

                
                //SqlConnection
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());

                // 오픈
                conn.Open();

                // 쿼리문 준비
                string sql = string.Format("INSERT INTO TB_ANSWER(ANSWER_ID, ANSWER_CONTENT, BOARD_ID, REPLY_ID, U_ID) VALUES( (NEXT VALUE FOR ANSWER_SEQ), '{0}', {1}, {2}, '{3}' )"
                                          , answer_content
                                          , board_id
                                          , reply_id
                                          , user_id);

                // SqlCommand 생성
                SqlCommand sc = new SqlCommand();
                // 연결정의
                sc.Connection = conn;
                // 쿼리문 실행
                sc.CommandText = sql;
                // 타입 정의
                sc.CommandType = CommandType.Text;

                // 결과 행 반환
                int result = sc.ExecuteNonQuery();

                // 닫기
                conn.Close();

                string url = "";
                Session["userid"] = user_id;
                if (result == 1)
                {
                    url = "BoardDetail.aspx?board_id=" + board_id + "&pageNum=" + pageNum;
                    Response.Redirect(url);
                }
                else
                {
                    Response.Redirect("");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }
        protected string alertMsg()
        {
            string result = "";
            result += "<script language='javascript'>" +
                      "alert('내용을 입력하세요')" +
                      "</script>";


            return result;
        }
    }
}