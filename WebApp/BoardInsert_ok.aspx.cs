using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class BoardInsert_ok : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 주요 변수 선언
            string user_id = "";
            string board_title = "";
            string board_content = "";
            SqlConnection conn = null;

            try
            {
                // 1. 이전 페이지(BoardInsert.aspx) 로부터 넘어온 데이터 받기 -- board_title, board_content
                board_title = Request.Form["board_title"].ToString();
                board_content = Request.Form["board_content"].ToString();
                if (Page.Session["userId"] != null)
                {
                    // 2. session 을 통한 id 받기
                    user_id = Page.Session["userId"].ToString();
                }
                else
                {
                    Response.Redirect("BoardLogin2.aspx");
                }
                // 값이 잘 넘어오는지 테스트
                // 잘넘어온다.

                //Response.Write(user_id);
                //Response.Write(board_title);
                
                //board_content = board_content.Replace("\r\n", "<br>");
                //Response.Write(board_content);
                // --> textarea 에서 엔터 \r\n 이 포함되어 있으면 <br> 태그로 바꿔줘야함.

                // BoardDTO 에 담기
                BoardDTO dto = new BoardDTO();

                dto.board_title = board_title;
                dto.board_content = board_content;
                dto.u_id = user_id;


                // 3. SqlConnection 객체 생성 및 연결 오픈 -- 커넥션 명 : testData
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());

                conn.Open();
                // 4. 쿼리문 준비
                string sql = string.Format("INSERT INTO TB_BOARD(BOARD_ID, BOARD_TITLE, BOARD_CONTENT, U_ID) VALUES( (SELECT COUNT(*) + 1 AS [COUNT] FROM TB_BOARD), '{0}', '{1}', '{2}')", dto.board_title, dto.board_content, dto.u_id);

                // 5. 쿼리 실행

                // SqlCommand 객체생성
                SqlCommand sc = new SqlCommand();

                // sc 의 Connection 정의
                sc.Connection = conn;

                // sql 실행
                sc.CommandText = sql;
                // sc 의 CommandType 정의
                sc.CommandType = CommandType.Text;

                // 쿼리를 실행하고 나서 영향을 받은 행 반환
                int result = sc.ExecuteNonQuery();

                // 6. 실행 여부에 따라 요청할 페이지 분기
                if (result == 1)
                {
                    // 입력 성공
                    conn.Close();
                    Session["userid"] = user_id;
                    Response.Redirect("BoardList.aspx");
                }
                else 
                {
                    conn.Close();
                    Response.Redirect("BoardInsertRejected.aspx");
                    // 입력 실패
                }






                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            
            
            


            











        }
    }
}