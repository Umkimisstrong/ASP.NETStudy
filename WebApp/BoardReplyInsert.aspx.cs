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
    public partial class BoardReplyInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 주요 변수 선언
            //string board_id = "";
            //string user_id = "";
            
            //Response.Write(alertMsg());
            try
            {
                // 이전 페이지 : BoardDetail.aspx 로 부터 넘어온 데이터 수신
                //board_id = Request.QueryString["board_id"].ToString();
                //user_id = Page.Session["userid"].ToString();

                //Response.Write(board_id);
                //Response.Write(user_id);

                // 숨긴 TextBox 로 board id 전송
                //Board_Id.Text = board_id;

                // Session 넘기기
                //Session["user_id"] = user_id;
                

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
        protected void insertBtn_Click(object sender, EventArgs e)
        {
            
            string board_id = "";
            string user_id = "";
            string pageNum = "";
            string reply_content = "";
            try
            {
                // 이전 페이지 : BoardDetail.aspx 로 부터 넘어온 데이터 수신
                board_id = Request.QueryString["board_id"].ToString();
                
                if (Page.Session["userid"] == null)
                    Response.Redirect("BoardLogin2.aspx");

                user_id = Page.Session["userid"].ToString();

                pageNum = Request.QueryString["pageNum"].ToString();
                reply_content = Reply_Content.Text;

                if (reply_content.Equals("") || reply_content.Substring(0, 1).Equals(" "))
                {
                    Response.Write(alertMsg());
                    return;
                }

                //Response.Write("바보");

                // dto setting
                BoardDetailDTO dto = new BoardDetailDTO();
                dto.reply_content = reply_content;
                dto.u_id = user_id;
                dto.board_id = int.Parse(board_id);

                //SqlConnection
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());

                // 오픈
                conn.Open();

                // 쿼리문 준비
                string sql = string.Format("INSERT INTO TB_REPLY(REPLY_ID, REPLY_CONTENT, U_ID, BOARD_ID)" +
                                          " VALUES ( (SELECT COUNT(*) + 1 AS [COUNT] FROM TB_REPLY)" +
                                          ", '{0}'" +
                                          ", '{1}'" +
                                          ", {2})"
                                          , dto.reply_content
                                          , dto.u_id
                                          , dto.board_id);

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

                    url = "BoardDetail.aspx?board_id=" + board_id+"&pageNum="+pageNum;
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
    }
}