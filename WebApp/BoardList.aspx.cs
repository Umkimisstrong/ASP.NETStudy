using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApp
{
    public class BoardDTO
    {
        public int rowNum { get ; set ; }
        public int board_id { get; set; }
        public string board_title { get; set; }
        public string board_content { get; set; }
        public int board_hitCount { get; set; }
        public string board_date { get; set; }
        public string u_name { get; set; }

    }
    public partial class BoardList : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            // 이전 페이지 : BoardLogin2.aspx 에서 id를 Session 으로 받기

            string id = Page.Session["userid"].ToString();

            Response.Write(id);



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
                /*
                if (conn != null)
                    //Response.Write("DB연결 성공~!");
                else
                    Response.Write("실패 ㅠㅜ");
                */

                // db 오픈
                conn.Open();

                // SqlCommand 객체 생성
                SqlCommand sc = new SqlCommand();

                // SqlCommand 객체의 연결은 testData 의 Connection() 을 의미
                sc.Connection = conn;

                // 해당 id, pwd 조회 ▼

                // 쿼리문 작성
                string sql = "SELECT CONVERT(INT, ROWNUM) AS [ROWNUM], BOARD_ID, BOARD_TITLE, BOARD_HITCOUNT, CONVERT(VARCHAR(8), BOARD_DATE, 112) AS [BOARD_DATE], U_NAME FROM BOARD_LIST_VIEW";
                sc.CommandText = sql;

                // commandtype 정의
                sc.CommandType = CommandType.Text;

                // sqlDataAdapter 선언
                SqlDataAdapter da = new SqlDataAdapter();

                // SqlDataAdapter 객체의 Command 정의
                da.SelectCommand = sc;

                // 결과 담기 ▼

                // DataSet 생성
                DataSet ds = new DataSet();

                // DataSet 에 테이블 담기
                da.Fill(ds, "[BOARD_LIST_VIEW]");

                // DataTable로 가져오기
                //DataTable dt = new DataTable();

                // DataSet 에 담긴 table 을 dt에 set해줌 === 정의
                //dt.TableName = ds.DataSetName;

                // List 생성
                List<BoardDTO> boardList = new List<BoardDTO>();

                // ds 테이블에 담긴 행 추출
                // 조건문 : 값을 얻어 왔다면 -- DataSet 의 count 가 0보다 크다면
                if (ds.Tables.Count > 0)
                {
                    for (int j = 0; j< ds.Tables.Count; j++)
                    {
                        foreach (DataRow row in ds.Tables[j].Rows)
                        {
                            BoardDTO dto = new BoardDTO();


                            dto.rowNum = (int)row["ROWNUM"];

                            dto.board_id = (int)row["BOARD_ID"];
                            dto.board_title = (string)row["BOARD_TITLE"];
                            dto.board_hitCount = (int)row["BOARD_HITCOUNT"];
                            dto.board_date = (string)row["BOARD_DATE"];
                            dto.u_name = (string)row["U_NAME"];

                            boardList.Add(dto);


                        }
                    }
                    // 값을 추출하자
                    

                    // 테이블의 첫줄
                    // <%-- 번호 / 제목(댓글) / 작성자 / 작성일 / 조회수 --%>
                    TableRow tr;
                    TableCell td;
                    tr = new TableRow();
                    string [] title  = { "번호", "제목", "작성자", "작성일", "조회수"};
                    
                    for (int i = 0; i < 5; i++)
                    {
                        td = new TableCell();
                        td.Text = title[i];
                        tr.Cells.Add(td);
                    }

                    // 테이블 첫줄의 색깔 지정
                    tr.BackColor = Color.FromName("#ccccff");

                    // asp 컨트롤 Board_List 의 행에 만든 tr 을 추가한다.
                    Board_List.Rows.Add(tr);


                    // 추출한 boardList 의 데이터 만큼 테이블의 개체로 담아주기
                    foreach (BoardDTO dto in boardList)
                    {
                        tr = new TableRow();

                        td = new TableCell();
                        td.Text = dto.rowNum.ToString();
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = "<a href='BoardDetail.aspx?board_id=" +dto.board_id.ToString()+ "' style='text-decoration: none;'>" + dto.board_title +"</a> ";
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = dto.u_name;
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = dto.board_date;
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = dto.board_hitCount.ToString();
                        tr.Cells.Add(td);

                        Board_List.Rows.Add(tr);
                    }
                    
                }
                else
                {
                    // 값이 없다면 리턴..
                    conn.Close();
                }
                

                //Console.WriteLine(result);

                // db 클로즈
                conn.Close();

                
                



            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string id = Page.Session["userid"].ToString();

            Session["userId"] = id;
            Response.Redirect("BoardInsert.aspx");
        }
    }
}