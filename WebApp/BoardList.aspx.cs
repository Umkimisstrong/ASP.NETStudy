using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public class BoardDTO
    {
        public int rowNum { get ; set ; }
        public string board_id { get; set; }
        public string board_title { get; set; }
        public string board_hitCount { get; set; }
        public string board_date { get; set; }
        public string u_name { get; set; }

    }
    public partial class BoardList : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            // 이전 페이지 : BoardLogin2.aspx 에서 id를 Session 으로 받기

            string id = Page.Session["userid"].ToString();

            //Response.Write(id); 성공



            // 테스트
            /*
            Response.Write(id);
            Response.Write(pwd);
            */
            // 값이 넘어옴

            // id / pwd 를 검증하는 액션처리



            // db연결

            // 연결 객체 생성
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());
                if (conn != null)
                    Response.Write("DB연결 성공~!");
                else
                    Response.Write("실패 ㅠㅜ");

                // db 오픈
                conn.Open();

                // SqlCommand 객체 생성
                SqlCommand sc = new SqlCommand();

                // SqlCommand 객체의 연결은 testData 의 Connection() 을 의미
                sc.Connection = conn;

                // 해당 id, pwd 조회 ▼

                // 쿼리문 작성
                string sql = "SELECT ROWNUM, BOARD_ID, BOARD_TITLE, BOARD_HITCOUNT, BOARD_DATE, U_NAME FROM BOARD_LIST_VIEW;";
                sc.CommandText = sql;

                // commandtype 정의
                sc.CommandType = System.Data.CommandType.Text;

                // sqlDataAdapter 선언
                SqlDataAdapter da = new SqlDataAdapter();

                // SqlDataAdapter 객체의 Command 정의
                da.SelectCommand = sc;

                // 결과 담기 ▼

                // DataSet 생성
                DataSet ds = new DataSet();

                // DataSet 에 테이블 담기
                da.Fill(ds, "[BOARD_LIST_VIEW]");

                // List 생성
                List<BoardDTO> boardList = new List<BoardDTO>();

                // ds 테이블에 담긴 행 추출
                // 조건문 : 값을 얻어 왔다면 -- DataSet 의 count 가 0보다 크다면
                if (ds.Tables.Count > 0)
                {
                    // 값을 추출하자
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        BoardDTO dto = new BoardDTO();


                        dto.rowNum = (int)row["ROWNUM"];
                        dto.board_id = (string)row["BOARD_ID"];
                        dto.board_title = (string)row["BOARD_TITLE"];
                        dto.board_hitCount = (string)row["BOARD_HITCOUNT"];
                        dto.board_date = (string)row["BOARD_DATE"];
                        dto.u_name = (string)row["U_NAME"];

                        boardList.Add(dto);
                    }
                }
                else
                {
                    // 값이 없다면 리턴..
                    conn.Close();
                }

                // 존재한다면 -> 1 
                // BoardList.aspx 로 이동
                // Response.Redirect("BoardList.aspx");            


                // 존재하지않는다면 -> 0 반환
                // BoardLogin2.aspx 로 이동
                // Response.Redirect("BoardLogin.aspx");            

                //Console.WriteLine(result);

                // db 클로즈
                conn.Close();


                



            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }
    }
}