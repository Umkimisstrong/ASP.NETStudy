using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApp
{

    public class BoardDetailDTO
    {
        // 게시물 id
        public int board_id { get; set; }
        // 게시물 제목
        public string board_title { get; set; }
        // 게시물 내용
        public string board_content { get; set; }
        // 게시물 조회수
        public int board_hitCount { get; set; }
        // 게시 날짜
        public string board_date { get; set; }
        // 작성자 id
        public string u_id { get; set; }
        // 작성자 명
        public string u_name { get; set; }
        // 댓글 id
        public int reply_id { get; set; }
        // 댓글 내용
        public string reply_content { get; set; }
        // 댓글 작성일
        public string reply_date { get; set; }
        public int reply_number { get; set; }
        public string reply_user { get; set; }

    }

    public partial class BoardDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Session["userid"].ToString() != null)
            {
                string id = Page.Session["userid"].ToString();
            }
            
            //Response.Write(id);
            string board_id = Request.QueryString["board_id"].ToString();
            //Response.Write(board_id);
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
                string sql = string.Format("SELECT CONVERT(INT, ROWNUM) AS [ROWNUM], BOARD_ID, BOARD_TITLE, BOARD_HITCOUNT, CONVERT(VARCHAR(8), BOARD_DATE, 112) AS [BOARD_DATE], BOARD_CONTENT, U_NAME FROM BOARD_LIST_VIEW WHERE BOARD_ID = {0}", board_id);
                
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
                    for (int j = 0; j < ds.Tables.Count; j++)
                    {
                        foreach (DataRow row in ds.Tables[j].Rows)
                        {
                            BoardDTO dto = new BoardDTO();


                            dto.rowNum = (int)row["ROWNUM"];

                            dto.board_id = (int)row["BOARD_ID"];
                            dto.board_title = (string)row["BOARD_TITLE"];
                            dto.board_content = (string)row["BOARD_CONTENT"];
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
                    
                    // 추출한 boardList 의 데이터 만큼 테이블의 개체로 담아주기
                    foreach (BoardDTO dto in boardList)
                    {
                        tr = new TableRow();

                        td = new TableCell();
                        td.Text = "[ " + dto.rowNum.ToString() + " ]";
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = "[ " + dto.board_title + " ]";
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = "[ " + dto.u_name + " ]";
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = "[ " + dto.board_date + " ]"; 
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = "[ " + dto.board_hitCount.ToString() + " ]";
                        tr.Cells.Add(td);

                        tr.BackColor = Color.FromName("#ccccff");

                        textarea.Text = dto.board_content;
                        Board_Detail.Rows.Add(tr);
                    }

                }
                else
                {
                    // 값이 없다면 리턴..
                    conn.Close();
                }


                //Console.WriteLine(result);

                sc = new SqlCommand();
                sc.Connection = conn;
                string sql2 = string.Format("SELECT CONVERT(INT, ROW_NUMBER() OVER (ORDER BY REPLY_ID)) AS [ROWNUM]" +
                                   ", REPLY_ID, REPLY_CONTENT, CONVERT(VARCHAR(8), REPLY_DATE, 112) AS [REPLY_DATE]" +
                                   ", BOARD_ID, U_NAME" +
                                   " FROM REPLY_LIST_VIEW" +
                                   " WHERE BOARD_ID = {0}", board_id);

                sc.CommandText = sql2;

                // commandtype 정의
                sc.CommandType = CommandType.Text;

                // sqlDataAdapter 선언
                SqlDataAdapter da2 = new SqlDataAdapter();

                // SqlDataAdapter 객체의 Command 정의
                da2.SelectCommand = sc;

                // 결과 담기 ▼

                // DataSet 생성
                DataSet ds2 = new DataSet();

                // DataSet 에 테이블 담기
                da2.Fill(ds2, "[REPLY_LIST_VIEW]");

                // DataTable로 가져오기
                //DataTable dt = new DataTable();

                // DataSet 에 담긴 table 을 dt에 set해줌 === 정의
                //dt.TableName = ds.DataSetName;

                // List 생성
                List<BoardDetailDTO> replyList = new List<BoardDetailDTO>();

                // ds 테이블에 담긴 행 추출
                // 조건문 : 값을 얻어 왔다면 -- DataSet 의 count 가 0보다 크다면
                if (ds2.Tables.Count > 0)
                {
                    for (int j = 0; j < ds2.Tables.Count; j++)
                    {
                        foreach (DataRow row in ds2.Tables[j].Rows)
                        {
                            BoardDetailDTO dto = new BoardDetailDTO();


                            dto.reply_number = (int)row["ROWNUM"];
                            dto.reply_id = (int)row["REPLY_ID"];
                            dto.reply_content = (string)row["REPLY_CONTENT"];
                            dto.reply_date = (string)row["REPLY_DATE"];
                            dto.reply_user = (string)row["U_NAME"];

                            replyList.Add(dto);


                        }
                    }
                    // 값을 추출하자


                    // 테이블의 첫줄
                    // <%-- 번호 / 제목(댓글) / 작성자 / 작성일 / 조회수 --%>
                    TableRow tr;
                    TableCell td;

                    // 추출한 boardList 의 데이터 만큼 테이블의 개체로 담아주기
                    foreach (BoardDetailDTO dto in replyList)
                    {
                        tr = new TableRow();

                        td = new TableCell();
                        td.Text = dto.reply_number.ToString();
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = dto.reply_content;
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = dto.reply_user;
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = dto.reply_date;
                        tr.Cells.Add(td);

                        tr.BackColor = Color.FromName("#a9f5f2s");

                        
                        Board_Reply.Rows.Add(tr);
                    }

                }
                else
                {
                    // 값이 없다면 리턴..
                    conn.Close();
                }






                // db 클로즈
                conn.Close();


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

           

        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("BoardList.aspx");
        }
    }
}